using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.DAL.Models.CurrencyRate;

namespace TSTB.BLL.Services.CurrencyRateService
{
    public interface ICuurencyRateService
    {
        public Task UpdateDataBaseForCurrencyRate();
        public Task<ICollection<CurrencyRate>> GetCurrentCurrencyRate();
    }
}
