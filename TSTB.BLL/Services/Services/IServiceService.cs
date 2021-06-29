using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.MenuModelDTO;
using TSTB.BLL.DTOs.ServicesDTO;
using TSTB.BLL.ViewModel;

namespace TSTB.BLL.Services.Services
{
    public interface IServiceService
    {
        IEnumerable<ServiceDTO> GetAllServices();
        IEnumerable<ServiceDTO> GetAllPublishServices();
        Task CreateService(CreateServiceDTO modelDTO);
        Task EditService(EditServiceDTO modelDTO);
        Task RemoveService(int id);
        Task RemoveAllServices();
        Task<EditServiceDTO> GetServiceForEditById(int id);
        Task<ServiceDTO> GetServicebyId(int id);
        IEnumerable<SearchResultModel> SearchByNameAndDesc(string searchText);
    }
}
