using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TSTB.BLL.DTOs.PartnersModelDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.DAL.Models.Partners;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.Partner
{
    public class PartnerService : IPartnerService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IPartnerDataService _partnerData;
        private readonly IWebHostEnvironment _appEnvironment;
        public PartnerService(ApplicationDbContext dbContext, IMapper mapper, IImageService imageService, IPartnerDataService pData, IWebHostEnvironment appEnvironment)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _imageService = imageService;
            _partnerData = pData;
            _appEnvironment = appEnvironment;
        }
        public IEnumerable<PartnersDTO> GetAllPartners()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var partner = _dbContext.Partners;
            var result = _dbContext.PartnerTranslates
                .Where(p => p.LanguageCulture == culture).Join(partner, p => p.PartnerId, k => k.Id,
                    (p, k) => new PartnersDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        Order = k.Order,
                        Logo = k.Logo,
                        IsPublish = k.IsPublish,
                        LogoFullPath = "/images/Partners/Logo/" + k.Logo

                    }) ;

            return result;
        }

        public IEnumerable<PartnersDTO> GetAllPublishPartners()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var partner = _dbContext.Partners.Where(k=>k.IsPublish == true);
            var result = _dbContext.PartnerTranslates
                .Where(p => p.LanguageCulture == culture).Join(partner, p => p.PartnerId, k => k.Id,
                    (p, k) => new PartnersDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        Order = k.Order,
                        Logo = k.Logo,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public async Task<int> CreatePartner(CreatePartnerDTO modelDTO)
        {
            DAL.Models.Partners.Partners partner = _mapper.Map<DAL.Models.Partners.Partners>(modelDTO);
            if (modelDTO.FormFile != null)
            {
                string fileName = await _imageService.UploadImage(modelDTO.FormFile, "Partners/Logo");
                partner.Logo = fileName;
            }
            await _dbContext.Partners.AddAsync(partner);
            await _dbContext.SaveChangesAsync();
            return partner.Id;
        }

        public async Task EditPartner(EditPartnerDTO modelDTO)
        {
            DAL.Models.Partners.Partners partner = _mapper.Map<DAL.Models.Partners.Partners>(modelDTO);

            partner.Logo = modelDTO.LogoName;
            if (modelDTO.FormFile != null)
            {
                _imageService.DeleteImage(partner.Logo, "Partners/Logo");
                partner.Logo = await _imageService.UploadImage(modelDTO.FormFile, "Partners/Logo");
            }

          
            /*
            DAL.Models.Partners.Partners partner = _mapper.Map<DAL.Models.Partners.Partners>(modelDTO);
            DAL.Models.Partners.Partners prevPartner = _dbContext.Partners.SingleOrDefault(k => k.Id == partner.Id);
            if (!string.IsNullOrEmpty(prevPartner.Logo))
            {
                _imageService.DeleteImage(prevPartner.Logo, "Partners/Logo");
            }
            if (modelDTO.Image != null)
                partner.Logo = await _imageService.UploadImage(modelDTO.FormFile, "Partners/Logo");
                */
            _dbContext.Partners.Update(partner);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemovePartner(int id)
        {
            DAL.Models.Partners.Partners partner = await _dbContext.Partners.FindAsync(id);
          
                DAL.Models.Partners.PartnersData partnersData = await  _partnerData.GetPartnerDataByPartnerId(id);

                if (partnersData != null && !string.IsNullOrEmpty(partnersData.Image))
                {
                    _imageService.DeleteImage(partnersData.Image, "Partners/Image");
                }
                if (!string.IsNullOrEmpty(partner.Logo))
                {
                    _imageService.DeleteImage(partner.Logo, "Partners/Logo");
                }

                _dbContext.Partners.Remove(partner);
                await _dbContext.SaveChangesAsync();
            
        }

        public async Task RemoveAllPartners()
        {
            IEnumerable<DAL.Models.Partners.Partners> partners = _dbContext.Partners;
            string path = _appEnvironment.WebRootPath + "/images/Partners/Logo";

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            _dbContext.Partners.RemoveRange(partners);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EditPartnerDTO> GetPartnerForEditById(int id)
        {
            var partner = await _dbContext.Partners
            .Include(i => i.PartnerTranslates)
            .SingleOrDefaultAsync(k => k.Id == id);
            EditPartnerDTO editPartnerDTO = _mapper.Map<EditPartnerDTO>(partner);
            editPartnerDTO.LogoName = partner.Logo;
         
            return editPartnerDTO;
        }

        public async Task<PartnersDTO> GetPublishPartnerByIdAsync(int id)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var partner = await _dbContext.Partners.FindAsync(id);
            var translate = await _dbContext.PartnerTranslates
                .Where(p => p.LanguageCulture == culture).SingleOrDefaultAsync(p => p.PartnerId == partner.Id);
            PartnersDTO result = new PartnersDTO
            {
                Id = partner.Id,
                Order = partner.Order,
                Name = translate.Name,
                Logo = partner.Logo,
                IsPublish = partner.IsPublish

            };
            return result;
        }
    }
}
