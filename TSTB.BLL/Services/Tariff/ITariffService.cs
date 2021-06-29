using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TSTB.BLL.Services.Tariff
{
    public interface ITariffService
    {
        Task DeleteTariffById(int id);
        ICollection<TSTB.DAL.Models.Billing.Tariff> getAllTariffs();
        Task EditTariff(TSTB.DAL.Models.Billing.Tariff t);
        Task CreateTariff(TSTB.DAL.Models.Billing.Tariff t);
    }
}
