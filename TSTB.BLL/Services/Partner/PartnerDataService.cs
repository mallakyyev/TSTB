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
using TSTB.BLL.DTOs.NewsModelDTO;
using TSTB.BLL.DTOs.PartnersModelDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.DAL.Models.Partners;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.Partner
{
    public class PartnerDataService : IPartnerDataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _appEnvironment;
        public PartnerDataService(ApplicationDbContext applicationDbContext, IMapper mapper, IImageService imageService, IWebHostEnvironment appEnvironment)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
            _imageService = imageService;
            _appEnvironment = appEnvironment;
        }
        public async Task CreatePartnerData(CreatePartnerDataDTO modelDTO)
        {
            DAL.Models.Partners.PartnersData pData = _mapper.Map<DAL.Models.Partners.PartnersData>(modelDTO);
            if (modelDTO.FormFile != null)
            {
                string fileName = await _imageService.UploadImage(modelDTO.FormFile, "Partners/Image");
                pData.Image = fileName;
            }
            await _dbContext.PartnersDatas.AddAsync(pData);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditPartnerData(EditPartnerDataDTO modelDTO)
        {
            DAL.Models.Partners.PartnersData pData = _mapper.Map<DAL.Models.Partners.PartnersData>(modelDTO);

            pData.Image = modelDTO.ImageName;
            if (modelDTO.FormFile != null)
            {
                _imageService.DeleteImage(pData.Image, "Partners/Image");
                pData.Image = await _imageService.UploadImage(modelDTO.FormFile, "Partners/Image");
            }

            /*
            DAL.Models.Partners.PartnersData pData = _mapper.Map<DAL.Models.Partners.PartnersData>(modelDTO);
            DAL.Models.Partners.PartnersData prevPData = _dbContext.PartnersDatas.SingleOrDefault(k => k.Id == pData.Id);
            if (!string.IsNullOrEmpty(prevPData.Image))
            {
                _imageService.DeleteImage(prevPData.Image, "Partners/Image");
            }
            if (modelDTO.FormFile != null)
                pData.Image = await _imageService.UploadImage(modelDTO.FormFile, "Partners/Image");
                */
            _dbContext.PartnersDatas.Update(pData);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<PartnerDataDTO> GetAllPartnersData()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var pData = _dbContext.PartnersDatas;
            var result = _dbContext.PartnersDataTranslates
                .Where(p => p.LanguageCulture == culture).Join(pData, p => p.PartnersDataId, k => k.Id,
                    (p, k) => new PartnerDataDTO
                    {
                        Id = k.Id,
                        Description = p.Description,
                        PartnerId = k.PartnerId,
                        Image = k.Image,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public IEnumerable<PartnerDataDTO> GetAllPublishPartnersData()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var pData = _dbContext.PartnersDatas.Where(k => k.IsPublish == true);
            var result = _dbContext.PartnersDataTranslates
                .Where(p => p.LanguageCulture == culture).Join(pData, p => p.PartnersDataId, k => k.Id,
                    (p, k) => new PartnerDataDTO
                    {
                        Id = k.Id,
                        Description = p.Description,
                        PartnerId = k.PartnerId,
                        Image = k.Image,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public async Task<PartnersData> GetPartnerDataByPartnerId(int partnerId)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            var result = await _dbContext.PartnersDatas
                .Include(i => i.PartnersDataTranslates.Where(p => p.LanguageCulture == culture))
                .SingleOrDefaultAsync(k => k.PartnerId == partnerId);

            return result;
        }

        public async Task<PartnerDataDTO> GetPartnerDataDTOByPartnerId(int partnerId)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            var pData = await _dbContext.PartnersDatas.SingleOrDefaultAsync(k => k.PartnerId == partnerId);
            var translate = await _dbContext.PartnersDataTranslates.SingleOrDefaultAsync(p => p.LanguageCulture == culture);

            var result = new PartnerDataDTO
            {
                Id = pData.Id,
                PartnerId = pData.PartnerId,
                Image = pData.Image,
                IsPublish = pData.IsPublish,
                Description = translate.Description
            };

            return result;
        }

        public async Task<EditPartnerDataDTO> GetPartnerDataForEditById(int id)
        {
            var partnerD = await _dbContext.PartnersDatas
             .Include(i => i.PartnersDataTranslates)
             .SingleOrDefaultAsync(k => k.PartnerId == id);
            EditPartnerDataDTO editPartnerDataDTO = _mapper.Map<EditPartnerDataDTO>(partnerD);
            if(partnerD != null)
            {
                editPartnerDataDTO.ImageName = partnerD.Image;
            }
            

            return editPartnerDataDTO;
        }

        public async Task RemoveAllPartnersData()
        {
            IEnumerable<DAL.Models.Partners.PartnersData> pData = _dbContext.PartnersDatas;
            string path = _appEnvironment.WebRootPath + "/images/Partners/Image/";


            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            _dbContext.PartnersDatas.RemoveRange(pData);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemovePartnerData(int id)
        {
            DAL.Models.Partners.PartnersData pData = await _dbContext.PartnersDatas.FindAsync(id);

            if (!string.IsNullOrEmpty(pData.Image))
            {
                _imageService.DeleteImage(pData.Image, "Partners/Image");
            }
            _dbContext.PartnersDatas.Remove(pData);
            await _dbContext.SaveChangesAsync();
        }
    }
}
