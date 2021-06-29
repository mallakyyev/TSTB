using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.VisitorDTO;
using TSTB.BLL.ViewModel;
using TSTB.DAL.Models.Ip;

namespace TSTB.BLL.Services.VisitorsService
{
    public interface IVisitorsService
    {
        Task AddVisitor(CreateVisitorDTO v);
        ICollection<Visitors> GetAllVisitors();
        Task DeleteRange(int year, int month);
        ICollection<CountryCount> GetCountriesByCount();
        ICollection<YearlyCount> GetYearlyCounts();
        ICollection<CountryCount> GetMonthlyCount();
        ICollection<CountryCount> GetGeneral();
        AchivementsViewModel GetAchivements();
    }
}
