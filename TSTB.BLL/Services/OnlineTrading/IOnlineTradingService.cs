using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.OnlineTradeDTO;
using TSTB.BLL.ViewModel;

namespace TSTB.BLL.Services.OnlineTrading
{
    public interface IOnlineTradingService
    {
        Task CreateOnlineTrading(CreateOnlineTradingDTO modelDTO);
        Task EditOnlineTrading(EditOnlineTradingDTO modelDTO);
    
        Task CreateOnlineTradingCategory(CreateOnlineTradingCategoryDTO modelDTO);
        Task EditOnlineTradingCategory(EditOnlineTradingCategoryDTO modelDTO);
        Task CreateOnlineTradingActivityType(CreateOnlineTradingActivityTypeDTO modelDTO);
        Task EditOnlineTradingActivityType(EditOnlineTradingActivityTypeDTO modelDTO);
        Task<OnlineTradingDTO> GetOnlineTradingById(int id);
        IEnumerable<OnlineTradingDTO> GetOnlineTradingByCategory(int onlineTradingCategoryId);
        IEnumerable<OnlineTradingDTO> GetAllOnlineTradings();
        IEnumerable<OnlineTradingModel> GetAllOnlineTrading_Categories();
        IEnumerable<OnlineTradingModel> GetAllOnlineTrading_Regions();
        Task<OnlineTradingCategoryDTO> GetOnlineTradingCategoryById(int id);
        IEnumerable<OnlineTradingCategoryDTO> GetAllOnlineTradingCategories();
        Task<OnlineTradingActivityTypeDTO> GetOnlineTradingActivityTypeById(int id);
        IEnumerable<OnlineTradingActivityTypeDTO> GetAllOnlineTradingActivityTypes();
        IEnumerable<OnlineTradingActivityTypeDTO> GetAllOnlineTradingActivityTypesByCategoryId(int categoryId);
        Task<EditOnlineTradingCategoryDTO> GetOnlineTradingCategoryForEditById(int id);
        Task<EditOnlineTradingActivityTypeDTO> GetOnlineTradingActivityTypeForEditById(int id);
        Task<EditOnlineTradingDTO> GetOnlineTradingForEditById(int id);

        Task DeleteCategoryById(int id);
        Task DeleteActivityById(int id);
        Task DeleteOnlineTradingById(int id);

    }
}
