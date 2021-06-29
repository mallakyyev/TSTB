using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.BannerModelDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.DAL.Models.Banner;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.Banner
{
    public class BannerService : IBannerService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public BannerService(ApplicationDbContext applicationDbContext, IMapper mapper, IImageService imageService)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task CreateBanner(CreateBannerDTO createBanner)
        {
            foreach (BannerTranslateDTO tr in createBanner.BannerTranslate)
            {
                if (tr.FormFile != null)
                {
                    tr.Image = await _imageService.UploadImage(tr.FormFile, "Banner");
                }
            }
            DAL.Models.Banner.Banner banner = _mapper.Map<DAL.Models.Banner.Banner>(createBanner);

            await _dbContext.Banners.AddAsync(banner);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditBanner(EditBannerDTO editModel)
        {
            foreach (BannerTranslateDTO tr in editModel.BannerTranslate)
            {
                if (tr.FormFile != null)
                {
                    _imageService.DeleteImage(tr.Image, "Banner");
                    tr.Image = await _imageService.UploadImage(tr.FormFile, "Banner");
                }
            }

            DAL.Models.Banner.Banner banner = _mapper.Map<DAL.Models.Banner.Banner>(editModel);
            _dbContext.Banners.Update(banner);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<BannerDTO> GetAllBanners()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var departments = _dbContext.Banners;
            var result = _dbContext.BannerTranslates
                .Where(p => p.LanguageCulture == culture).Join(departments, p => p.BannerId, k => k.Id,
                    (p, k) => new BannerDTO
                    {
                        Id = k.Id,
                        Title = p.Title,
                        ShortDescription = p.ShortDescription,
                        IsPublish = k.IsPublish,
                        EndDate = k.EndDate,
                        Image = p.Image,
                        Link = k.Link,
                        StartDate = k.StartDate
                    });

            return result;
        }

        public IEnumerable<BannerDTO> GetAllPublishBanners()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var departments = _dbContext.Banners.Where(k => k.IsPublish == true);
            var result = _dbContext.BannerTranslates
                .Where(p => p.LanguageCulture == culture).Join(departments, p => p.BannerId, k => k.Id,
                    (p, k) => new BannerDTO
                    {
                        Id = k.Id,
                        Title = p.Title,
                        ShortDescription = p.ShortDescription,
                        IsPublish = k.IsPublish,
                        EndDate = k.EndDate,
                        Image = p.Image,
                        Link = k.Link,
                        StartDate = k.StartDate
                    }).OrderByDescending(o => o.Id);

            return result;
        }

        public async Task<BannerDTO> GetBannerByIdAsync(int id)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var banner = await _dbContext.Banners.SingleOrDefaultAsync(k => k.Id == id);

            var translate = await _dbContext.BannerTranslates
                .Where(p => p.LanguageCulture == culture).SingleOrDefaultAsync(p => p.BannerId == banner.Id);
            BannerDTO result = new BannerDTO
            {
                Id = banner.Id,
                IsPublish = banner.IsPublish,
                ShortDescription = translate.ShortDescription,
                Title = translate.Title,
                EndDate = banner.EndDate,
                StartDate = banner.StartDate,
                Image = translate.Image,
                Link = banner.Link
            };

            return result;
        }

        public async Task<EditBannerDTO> GetBannerForEditByIdAsync(int id)
        {
            var banner = await _dbContext.Banners
               .Include(i => i.BannerTranslate)
               .SingleOrDefaultAsync(k => k.Id == id);
            EditBannerDTO editBannerDTO = _mapper.Map<EditBannerDTO>(banner);
            return editBannerDTO;
        }

        public async Task RemoveBannerById(int id)
        {
            DAL.Models.Banner.Banner banner = await _dbContext.Banners.FindAsync(id);
            var bannerTranslates = _dbContext.BannerTranslates.Where(k => k.BannerId == id);
            foreach (BannerTranslate img in bannerTranslates)
            {
                if (!string.IsNullOrEmpty(img.Image))
                {
                    _imageService.DeleteImage(img.Image, "Banner");
                }
            }
            _dbContext.Banners.Remove(banner);
            await _dbContext.SaveChangesAsync();
        }
    }
}
