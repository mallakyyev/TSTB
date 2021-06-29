using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.TradingHousesDTO;

namespace TSTB.BLL.Services.TradingHouses
{
    public interface ITradingHouseService
    {
        IEnumerable<TradingHouseDTO> GetAllTradingHouses();
        IEnumerable<TradingHouseDTO> GetAllPublishTradingHouses();

        Task CreateTradingHouse(CreateTradingHouseDTO modelDTO);

        Task EditTradingHouse(EditTradingHousesDTO modelDTO);

        Task RemoveTradingHouse(int id);
        Task RemoveAllTradingHouses();
        Task<TradingHouseDTO> GetTradingHouseByIdAsync(int trId);
        Task<EditTradingHousesDTO> GetTradingHouseForEditById(int id);
    }
}
