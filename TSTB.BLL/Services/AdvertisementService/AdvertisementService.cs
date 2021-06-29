using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.AdvertisementDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.DAL.Models.Advertisement;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.AdvertisementService
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public AdvertisementService(ApplicationDbContext dbContext, IMapper mapper, IImageService imageService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _imageService = imageService;
        }
        public async Task CreateAdvertisement(CreateAdvertisementDTO model)
        {
            DAL.Models.Advertisement.Advertisement adv = _mapper.Map<DAL.Models.Advertisement.Advertisement>(model);
            if (model.FormFileBig != null)
            {
                adv.ImageBig = await _imageService.UploadImage(model.FormFileBig, "Advertisement");
            }
            if (model.FormFileSmall != null)
            {
                adv.ImageSmall = await _imageService.UploadImage(model.FormFileSmall, "Advertisement");
            }

            await _dbContext.Advertisements.AddAsync(adv);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAdvertisementsById(int id)
        {
            DAL.Models.Advertisement.Advertisement adv = await _dbContext.Advertisements.FindAsync(id);

            if (!string.IsNullOrEmpty(adv.ImageBig))
            {
                _imageService.DeleteImage(adv.ImageBig, "Advertisement");
            }
            if (!string.IsNullOrEmpty(adv.ImageSmall))
            {
                _imageService.DeleteImage(adv.ImageSmall, "Advertisement");
            }
            _dbContext.Advertisements.Remove(adv);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAdvertisement(EditAdvertisementDTO model)
        {
            DAL.Models.Advertisement.Advertisement adv = _mapper.Map<DAL.Models.Advertisement.Advertisement>(model);

            adv.ImageBig = model.PictureNameBig;
            adv.ImageSmall = model.PictureNameSmall;

            if (model.FormFileBig != null)
            {
                _imageService.DeleteImage(adv.ImageBig, "Advertisement");
                adv.ImageBig = await _imageService.UploadImage(model.FormFileBig, "Advertisement");
            }

            if (model.FormFileSmall != null)
            {
                _imageService.DeleteImage(adv.ImageSmall, "Advertisement");
                adv.ImageSmall = await _imageService.UploadImage(model.FormFileSmall, "Advertisement");
            }

            _dbContext.Advertisements.Update(adv);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EditAdvertisementDTO> GetAdvertisementForEditById(int id)
        {
            var adv = await _dbContext.Advertisements.FindAsync(id);
            EditAdvertisementDTO editDTO = _mapper.Map<EditAdvertisementDTO>(adv);
            editDTO.PictureNameBig = adv.ImageBig;
            editDTO.PictureNameSmall = adv.ImageSmall;            
            return editDTO;
        }

        public IEnumerable<AdvertisementDTO> GetAllAdvertisements()
        {
            
            return  _mapper.Map<IEnumerable<AdvertisementDTO>>(_dbContext.Advertisements);
           
        }

        public IEnumerable<AdvertisementDTO> GetAllPublishAdvertisements()
        {
            return _mapper.Map<IEnumerable<AdvertisementDTO>>(_dbContext.Advertisements
                .Where(p => p.IsPublish == true && DateTime.Now.Date >= p.StartDate.Date && DateTime.Now.Date <= p.EndDate.Date));
        }
    }
}
