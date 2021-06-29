using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.VisitorDTO;
using TSTB.BLL.Services.Settings;
using TSTB.BLL.ViewModel;
using TSTB.DAL.Models.Ip;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.VisitorsService
{
    public class VisitorsService : IVisitorsService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ISettingsService _settingsService;
        public VisitorsService(ApplicationDbContext dbContext,IMapper mapper, ISettingsService settingsService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _settingsService = settingsService;
        }
        public async Task AddVisitor(CreateVisitorDTO v)
        {          
                await _dbContext.Visitors.AddAsync(_mapper.Map<Visitors>(v));            
                _dbContext.SaveChanges();
        }

        public async Task DeleteRange(int year, int month)
        {
            IEnumerable<Visitors> res = _dbContext.Visitors.Where(p=>p.VisitDate.Year == year && p.VisitDate.Month == month);
            _dbContext.RemoveRange(res);
            await _dbContext.SaveChangesAsync();
        }

        public AchivementsViewModel GetAchivements()
        {

            List<TSTB.DAL.Models.Settings.Settings> settings = new List<TSTB.DAL.Models.Settings.Settings>(_settingsService.GetAllSettings());
            AchivementsViewModel res = new AchivementsViewModel();
            res.Entreprenuers = settings.Find(x => x.Name == "Entreprenuers").Value;
            res.Completed_projects = settings.Find(x => x.Name == "Completed_projects").Value;
            res.Trained_Entreprenuers = settings.Find(x => x.Name == "Trained_Entreprenuers").Value;
            res.Years_with_you = settings.Find(x => x.Name == "Years_with_you").Value;

            return res;
        }

        public ICollection<Visitors> GetAllVisitors()
        {
            return (new List<Visitors>(_dbContext.Visitors));
        }

        public ICollection<CountryCount> GetCountriesByCount()
        {
            List<CountryCount> query = new List<CountryCount>(_dbContext.Visitors
                   .GroupBy(p => p.Country)
                   .Select(g => new CountryCount { Country = g.Key, Count = g.Count() }).ToList());
            return query;

        }

        public ICollection<CountryCount> GetGeneral()
        {
            List<CountryCount> query = new List<CountryCount>(_dbContext.Visitors
                  .GroupBy(p => p.VisitDate)
                  .Select(g => new CountryCount { Country = DateTimeFormatInfo.InvariantInfo.GetAbbreviatedMonthName(g.Key.Month)+g.Key.ToString("yy"), Count = g.Count() }).ToList());
            return query;
        }

        public ICollection<CountryCount> GetMonthlyCount()
        {
            List<CountryCount> query = new List<CountryCount>(_dbContext.Visitors
                  .GroupBy(p => p.VisitDate.Month)
                  .Select(g => new CountryCount { Country = DateTimeFormatInfo.InvariantInfo.GetAbbreviatedMonthName(g.Key) , 
                      Count = g.Count() }).ToList());
            return query;
        }

        public ICollection<YearlyCount> GetYearlyCounts()
        {
           
            List<YearlyCount> query = new List<YearlyCount>(_dbContext.Visitors
                   .GroupBy(p => p.VisitDate.Year).OrderByDescending(p=>p.Count())
                   .Select(g => new YearlyCount { Year = g.Key, Count = g.Count() }).ToList());
            return query;
        }
    }
}
