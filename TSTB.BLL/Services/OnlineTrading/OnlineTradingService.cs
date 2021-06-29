using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.OnlineTradeDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.BLL.ViewModel;
using TSTB.DAL.Models.OnlineTrade;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.OnlineTrading
{
    public class OnlineTradingService : IOnlineTradingService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public OnlineTradingService(ApplicationDbContext dbContext, IMapper mapper, IImageService imageService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _imageService = imageService;
        }
        public async Task CreateOnlineTrading(CreateOnlineTradingDTO modelDTO)
        {
            DAL.Models.OnlineTrade.OnlineTrading tr = _mapper.Map<DAL.Models.OnlineTrade.OnlineTrading>(modelDTO);
            foreach(string number in modelDTO.PhoneNumbers)
            {
                tr.PhoneNumber += number + " ";
            }
            if (modelDTO.FormFile != null)
            {
                tr.Image = await _imageService.UploadImage(modelDTO.FormFile, "OnlineTrading");
            }
          
            _dbContext.OnlineTradings.Add(tr);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateOnlineTradingActivityType(CreateOnlineTradingActivityTypeDTO modelDTO)
        {
            DAL.Models.OnlineTrade.OnlineTradingActivityType trA = _mapper.Map<DAL.Models.OnlineTrade.OnlineTradingActivityType>(modelDTO);
            await _dbContext.OnlineTradingActivityTypes.AddAsync(trA);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateOnlineTradingCategory(CreateOnlineTradingCategoryDTO modelDTO)
        {
            DAL.Models.OnlineTrade.OnlineTradingCategory trC = _mapper.Map<DAL.Models.OnlineTrade.OnlineTradingCategory>(modelDTO);
            await _dbContext.OnlineTradingCategories.AddAsync(trC);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteActivityById(int id)
        {
            DAL.Models.OnlineTrade.OnlineTradingActivityType ot = await _dbContext.OnlineTradingActivityTypes.FindAsync(id);
            if (ot != null)
                _dbContext.OnlineTradingActivityTypes.Remove(ot);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteCategoryById(int id)
        {
            DAL.Models.OnlineTrade.OnlineTradingCategory ot = await _dbContext.OnlineTradingCategories.FindAsync(id);
            if (ot != null)
                _dbContext.OnlineTradingCategories.Remove(ot);
            await _dbContext.SaveChangesAsync();
        }

  

        public async Task DeleteOnlineTradingById(int id)
        {
            DAL.Models.OnlineTrade.OnlineTrading nt = await _dbContext.OnlineTradings.FindAsync(id);
            
            if (!string.IsNullOrEmpty(nt.Image))
            {
                _imageService.DeleteImage(nt.Image, "OnlineTrading");
            }
            _dbContext.OnlineTradings.Remove(nt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditOnlineTrading(EditOnlineTradingDTO modelDTO)
        {
            DAL.Models.OnlineTrade.OnlineTrading tr = _mapper.Map<DAL.Models.OnlineTrade.OnlineTrading>(modelDTO);
            foreach(string number in modelDTO.PhoneNumbers)
            {
                tr.PhoneNumber += number + " ";
            }
            tr.Image = modelDTO.PictureName;
            if (modelDTO.FormFile != null)
            {
                _imageService.DeleteImage(tr.Image, "OnlineTrading");
                tr.Image = await _imageService.UploadImage(modelDTO.FormFile, "OnlineTrading");
            }

            _dbContext.OnlineTradings.Update(tr);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditOnlineTradingActivityType(EditOnlineTradingActivityTypeDTO modelDTO)
        {
            DAL.Models.OnlineTrade.OnlineTradingActivityType trA = _mapper.Map<DAL.Models.OnlineTrade.OnlineTradingActivityType>(modelDTO);
            _dbContext.OnlineTradingActivityTypes.Update(trA);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditOnlineTradingCategory(EditOnlineTradingCategoryDTO modelDTO)
        {
            DAL.Models.OnlineTrade.OnlineTradingCategory trC = _mapper.Map<DAL.Models.OnlineTrade.OnlineTradingCategory>(modelDTO);
            _dbContext.OnlineTradingCategories.Update(trC);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<OnlineTradingActivityTypeDTO> GetAllOnlineTradingActivityTypes()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var trA = _dbContext.OnlineTradingActivityTypes.Include(p => p.OnlineTradingCategory).ThenInclude(p => p.OnlineTradingCategoryTranslates);
            var result = _dbContext.OnlineTradingActivityTypeTranslates
                .Where(p => p.LanguageCulture == culture).Join(trA, p => p.OnlineTradingActivityTypeId, k => k.Id,
                    (p, k) => new OnlineTradingActivityTypeDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        CategoryName = k.OnlineTradingCategory.OnlineTradingCategoryTranslates.FirstOrDefault(p => p.LanguageCulture == culture).Name
                    });

            return result;
        }

        public IEnumerable<OnlineTradingActivityTypeDTO> GetAllOnlineTradingActivityTypesByCategoryId(int categoryId)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var trA = _dbContext.OnlineTradingActivityTypes.Where(p=>p.OnlineTradingCategoryId == categoryId).Include(p => p.OnlineTradingCategory).ThenInclude(p => p.OnlineTradingCategoryTranslates);
            var result = _dbContext.OnlineTradingActivityTypeTranslates
                .Where(p => p.LanguageCulture == culture).Join(trA, p => p.OnlineTradingActivityTypeId, k => k.Id,
                    (p, k) => new OnlineTradingActivityTypeDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        CategoryName = k.OnlineTradingCategory.OnlineTradingCategoryTranslates.FirstOrDefault(p => p.LanguageCulture == culture).Name
                    });

            return result;
        }

        public IEnumerable<OnlineTradingCategoryDTO> GetAllOnlineTradingCategories()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var trA = _dbContext.OnlineTradingCategories;
            var result = _dbContext.OnlineTradingCategoryTranslates
                .Where(p => p.LanguageCulture == culture).Join(trA, p => p.OnlineTradingCategoryId, k => k.Id,
                    (p, k) => new OnlineTradingCategoryDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public IEnumerable<OnlineTradingDTO> GetAllOnlineTradings()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var trA = _dbContext.OnlineTradings.Include(p => p.OnlineTradingActivityType).ThenInclude(p=>p.OnlineTradingActivityTypeTranslates).Include(p=>p.Cities).ThenInclude(p=>p.CitiesTranslates).Include(p=>p.OnlineTradingTranslates);
            var result = _dbContext.OnlineTradingTranslates
                .Where(p => p.LanguageCulture == culture).Join(trA, p => p.OnlineTradingId, k => k.Id,
                    (p, k) => new OnlineTradingDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        IsPublish = k.IsPublish,
                        PhoneNumber = k.PhoneNumber,
                        Address = k.Address,
                        CityId = k.CityId,
                        Description = p.Description,
                        Image = k.Image,
                        OnlineTradingActivityTypeId = k.OnlineTradingActivityTypeId,
                        Site = k.Site,
                        CityName = k.Cities.CitiesTranslates.SingleOrDefault(p=>p.LanguageCulture == culture).Name,
                        ActivityTypeName = k.OnlineTradingActivityType.OnlineTradingActivityTypeTranslates.FirstOrDefault(p => p.LanguageCulture == culture).Name,
                        ActivityName = k.OnlineTradingTranslates.SingleOrDefault(p=>p.LanguageCulture == culture).Name
                    }) ;

            return result;
        }

        public IEnumerable<OnlineTradingModel> GetAllOnlineTrading_Categories()
        {
            List<OnlineTradingModel> result = new List<OnlineTradingModel>();
            var cat = GetAllOnlineTradingCategories();
            foreach(OnlineTradingCategoryDTO c in cat)
            {
                OnlineTradingModel model = new OnlineTradingModel()
                {
                    OnlineTradingCategoryName = c.Name,
                    OnlineTradings = GetOnlineTradingByCategory(c.Id)
                };
                result.Add(model);
            }
            return result;
        }

        public IEnumerable<OnlineTradingModel> GetAllOnlineTrading_Regions()
        {
            throw new NotImplementedException();
        }

        public async Task<OnlineTradingActivityTypeDTO> GetOnlineTradingActivityTypeById(int id)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var trA = await _dbContext.OnlineTradingActivityTypes.Include(p => p.OnlineTradingCategory).ThenInclude(p => p.OnlineTradingCategoryTranslates).SingleOrDefaultAsync(p=>p.Id == id);
            var translate = await _dbContext.OnlineTradingActivityTypeTranslates
                .Where(p => p.LanguageCulture == culture).SingleOrDefaultAsync(p => p.OnlineTradingActivityTypeId == trA.Id);
            OnlineTradingActivityTypeDTO result = new OnlineTradingActivityTypeDTO
            {
                Id = trA.Id,
                OnlineTradingCategoryId = trA.OnlineTradingCategoryId,
                Name = translate.Name,
                CategoryName = trA.OnlineTradingCategory.OnlineTradingCategoryTranslates.FirstOrDefault(p => p.LanguageCulture == culture).Name              
            };
            return result;
        }

        public async Task<EditOnlineTradingActivityTypeDTO> GetOnlineTradingActivityTypeForEditById(int id)
        {
            var otA = await _dbContext.OnlineTradingActivityTypes
             .Include(i => i.OnlineTradingActivityTypeTranslates)
             .SingleOrDefaultAsync(k => k.Id == id);
            EditOnlineTradingActivityTypeDTO edit_otADTO = _mapper.Map<EditOnlineTradingActivityTypeDTO>(otA);

            return edit_otADTO;
        }

        public IEnumerable<OnlineTradingDTO> GetOnlineTradingByCategory(int onlineTradingCategoryId)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var trA = _dbContext.OnlineTradings.Include(p => p.OnlineTradingActivityType).ThenInclude(p => p.OnlineTradingActivityTypeTranslates);
            var tr = trA.Where(p => p.OnlineTradingActivityType.OnlineTradingCategoryId == onlineTradingCategoryId);
            var result = _dbContext.OnlineTradingTranslates
                .Where(p => p.LanguageCulture == culture).Join(tr, p => p.OnlineTradingId, k => k.Id,
                    (p, k) => new OnlineTradingDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        IsPublish = k.IsPublish,
                        PhoneNumber = k.PhoneNumber,
                        Address = k.Address,
                        CityId = k.CityId,
                        Description = p.Description,
                        Image = k.Image,
                        OnlineTradingActivityTypeId = k.OnlineTradingActivityTypeId,
                        Site = k.Site,
                        ActivityName = k.OnlineTradingActivityType.OnlineTradingActivityTypeTranslates.FirstOrDefault(p => p.LanguageCulture == culture).Name
                    });

            return result;
        }

        public async Task<OnlineTradingDTO> GetOnlineTradingById(int id)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var k = await _dbContext.OnlineTradings.Include(p=>p.OnlineTradingActivityType).ThenInclude(p=>p.OnlineTradingActivityTypeTranslates).FirstOrDefaultAsync(p => p.Id == id);

            var p = _dbContext.OnlineTradingTranslates.FirstOrDefault(p => p.OnlineTradingId == id && p.LanguageCulture == culture);

            OnlineTradingDTO result = new OnlineTradingDTO()
                    {
                        Id = k.Id,
                        Name = p.Name,
                        IsPublish = k.IsPublish,
                        PhoneNumber = k.PhoneNumber,
                        Address = k.Address,
                        CityId = k.CityId,
                        Description = p.Description,
                        Image = k.Image,
                        OnlineTradingActivityTypeId = k.OnlineTradingActivityTypeId,
                        Site = k.Site,
                        ActivityName = k.OnlineTradingActivityType.OnlineTradingActivityTypeTranslates.FirstOrDefault(p => p.LanguageCulture == culture).Name
                    };

            return result;
        }

        public async Task<OnlineTradingCategoryDTO> GetOnlineTradingCategoryById(int id)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var trC = await _dbContext.OnlineTradingCategories.FindAsync(id);
            var translate = _dbContext.OnlineTradingCategoryTranslates.FirstOrDefault(p => p.LanguageCulture == culture && p.OnlineTradingCategoryId == id);
            OnlineTradingCategoryDTO result = new OnlineTradingCategoryDTO()
            {
                Id = trC.Id,
                IsPublish = trC.IsPublish,
                Name = translate.Name

            };
            return result;
        }

        public async Task<EditOnlineTradingCategoryDTO> GetOnlineTradingCategoryForEditById(int id)
        {
            var otA = await _dbContext.OnlineTradingCategories
             .Include(i => i.OnlineTradingCategoryTranslates)
             .SingleOrDefaultAsync(k => k.Id == id);
            EditOnlineTradingCategoryDTO edit_otADTO = _mapper.Map<EditOnlineTradingCategoryDTO>(otA);

            return edit_otADTO;
        }

        public async Task<EditOnlineTradingDTO> GetOnlineTradingForEditById(int id)
        {
            var oT = await _dbContext.OnlineTradings
             .Include(i => i.OnlineTradingTranslates).Include(p => p.OnlineTradingActivityType)
             .SingleOrDefaultAsync(k => k.Id == id);
            EditOnlineTradingDTO edit_OtDTO = _mapper.Map<EditOnlineTradingDTO>(oT);
            edit_OtDTO.PhoneNumbers = new List<string>(oT.PhoneNumber.Split(" "));
            edit_OtDTO.PictureName = oT.Image;
            
            return edit_OtDTO;
        }
    }
}
