using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TSTB.BLL.Services.Settings
{
    public interface ISettingsService
    {
        IEnumerable<DAL.Models.Settings.Settings> GetAllSettings();
        IEnumerable<DAL.Models.Settings.Settings> GetAllCashSettings();

        Task CreateSettings(DAL.Models.Settings.Settings modelDTO);

        Task EditSettings(DAL.Models.Settings.Settings modelDTO);

        Task RemoveSettings(int id);        
        Task<DAL.Models.Settings.Settings> GetSettingsById(int id);
    }
}
