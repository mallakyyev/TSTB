using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.TradingHousesDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.TradingHouses
{
    public class TradingHousesService : ITradingHouseService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public TradingHousesService(ApplicationDbContext applicationDbContext, IMapper iMapper, IImageService imageService)
        {
            _dbContext = applicationDbContext;
            _mapper = iMapper;
            _imageService = imageService;

        }
        public async Task CreateTradingHouse(CreateTradingHouseDTO modelDTO)
        {
            DAL.Models.TradingHouse.TradingHouses tradingH = _mapper.Map<DAL.Models.TradingHouse.TradingHouses>(modelDTO);
            if (modelDTO.FormFile != null)
            {
                tradingH.Image = await _imageService.UploadImage(modelDTO.FormFile, "TradingHouse");
            }
            await _dbContext.TradingHouses.AddAsync(tradingH);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditTradingHouse(EditTradingHousesDTO modelDTO)
        {
            DAL.Models.TradingHouse.TradingHouses tradingH = _mapper.Map<DAL.Models.TradingHouse.TradingHouses>(modelDTO);
            if (modelDTO.FormFile != null)
            {
                if(modelDTO.Image != null)
                {
                    _imageService.DeleteImage(modelDTO.Image, "TradingHouse");
                }                
                tradingH.Image = await _imageService.UploadImage(modelDTO.FormFile, "TradingHouse");
            }
            _dbContext.TradingHouses.Update(tradingH);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<TradingHouseDTO> GetAllPublishTradingHouses()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var tr = _dbContext.TradingHouses.Where(k=>k.IsPublish == true);
            var result = _dbContext.TradingHousesTranslates
                .Where(p => p.LanguageCulture == culture).Join(tr, p => p.TradingHouseId, k => k.Id,
                    (p, k) => new TradingHouseDTO
                    {
                        Id = k.Id,
                        Description = p.Description,
                        Name = p.Name,
                        Person = k.Person,
                        Phone = k.Phone,
                        Email = k.Email,
                        Address = k.Address,
                        Site = k.Site,
                        IsPublish = k.IsPublish,
                        Image = k.Image
                    }) ;

            return result;
        }

        public IEnumerable<TradingHouseDTO> GetAllTradingHouses()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var tr = _dbContext.TradingHouses;
            var result = _dbContext.TradingHousesTranslates
                .Where(p => p.LanguageCulture == culture).Join(tr, p => p.TradingHouseId, k => k.Id,
                    (p, k) => new TradingHouseDTO
                    {
                        Id = k.Id,
                        Description = p.Description,
                        Name = p.Name,
                        Person = k.Person,
                        Phone = k.Phone,
                        Email = k.Email,
                        Address = k.Address,
                        Site = k.Site,
                        IsPublish = k.IsPublish,
                        Image = k.Image
                    });

            return result;
        }

        public async Task<TradingHouseDTO> GetTradingHouseByIdAsync(int trId)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var tr = await _dbContext.TradingHouses.SingleOrDefaultAsync(k => k.Id == trId);

            var translate = await _dbContext.TradingHousesTranslates
                .Where(p => p.LanguageCulture == culture).SingleOrDefaultAsync(p => p.TradingHouseId == tr.Id);
            TradingHouseDTO result = new TradingHouseDTO
            {
                Id = tr.Id,
                Description = translate.Description,
                Name = translate.Name,
                Person = tr.Person,
                Phone = tr.Phone,
                Email = tr.Email,
                Address = tr.Address,
                Site = tr.Site,
                IsPublish = tr.IsPublish,
                Image = tr.Image
            };

            return result;
        }

        public async Task<EditTradingHousesDTO> GetTradingHouseForEditById(int id)
        {
            var tr = await _dbContext.TradingHouses
              .Include(i => i.TradingHousesTranslates)
              .SingleOrDefaultAsync(k => k.Id == id);
            EditTradingHousesDTO editTH = _mapper.Map<EditTradingHousesDTO>(tr);
            
            return editTH;
        }

        public async Task RemoveAllTradingHouses()
        {
            IEnumerable<DAL.Models.TradingHouse.TradingHouses> tr = _dbContext.TradingHouses;
            _dbContext.TradingHouses.RemoveRange(tr);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveTradingHouse(int id)
        { 
            DAL.Models.TradingHouse.TradingHouses tr = await _dbContext.TradingHouses.FindAsync(id);
            if (!string.IsNullOrEmpty(tr.Image))
            {
                _imageService.DeleteImage(tr.Image, "TradingHouse");
            }
            _dbContext.TradingHouses.Remove(tr);
            await _dbContext.SaveChangesAsync();
        }
    }
}
