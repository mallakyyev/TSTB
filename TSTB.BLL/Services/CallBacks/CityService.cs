using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.CallBackModelDTO;
using TSTB.DAL.Models.CallBacks;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.CallBacks
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CityService(ApplicationDbContext applicationDbContext, IMapper iMapper)
        {
            _dbContext = applicationDbContext;
            _mapper = iMapper;

        }
        public async Task CreateCity(CreateCityDTO modelDTO)
        {
            DAL.Models.CallBacks.Cities city = _mapper.Map<DAL.Models.CallBacks.Cities>(modelDTO);
            await _dbContext.Cities.AddAsync(city);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditCity(EditCityDTO modelDTO)
        {
            DAL.Models.CallBacks.Cities city = _mapper.Map< DAL.Models.CallBacks.Cities> (modelDTO);
            _dbContext.Cities.Update(city);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<CitiesDTO> GetAllCities()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var cities = _dbContext.Cities;
            var result = _dbContext.CitiesTranslates
                .Where(p => p.LanguageCulture == culture).Join(cities, p => p.CityId, k => k.Id,
                    (p, k) => new CitiesDTO
                    {
                        Id = k.Id,               
                        Name = p.Name,
 
                    });

            return result;
        }

        public async Task<CitiesDTO> GetCityById(int id)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            Cities city = await _dbContext.Cities.FindAsync(id);
            CitiesTranslate tr = _dbContext.CitiesTranslates.SingleOrDefault(p => p.CityId == id && p.LanguageCulture == culture);
            CitiesDTO result = new CitiesDTO
            {
                Id = city.Id,
                Name = tr.Name
            };
            return result;

        }

        public async Task<EditCityDTO> GetCityForEditById(int id)
        {
            var city = await _dbContext.Cities
            .Include(i => i.CitiesTranslates)
            .SingleOrDefaultAsync(k => k.Id == id);
            EditCityDTO editCity= _mapper.Map<EditCityDTO>(city);   
            return editCity;

        }

        public async Task RemoveCity(int id)
        {
            DAL.Models.CallBacks.Cities city = await _dbContext.Cities.FindAsync(id);
            _dbContext.Cities.Remove(city);
            await _dbContext.SaveChangesAsync();
        }
    }
}
