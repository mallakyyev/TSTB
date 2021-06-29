using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.ServicesDTO;
using TSTB.BLL.ViewModel;

namespace TSTB.BLL.Services.Services
{
    public interface  IServicesTypeService
    {
        IEnumerable<ServiceTypeDTO> GetAllServiceTypes();
        IEnumerable<ServiceTypeDTO> GetAllPublishServiceTypes();
        IEnumerable<ServiceTypeDTO> GetAllServiceTypesByServiceId(int serviceId);
        Task CreateServiceType(CreateServiceTypeDTO modelDTO);

        Task EditServiceType(EditServiceTypeDTO modelDTO);

        Task RemoveServiceTypes(int id);
        Task RemoveAllServiceTypes();
        Task<EditServiceTypeDTO> GetServiceTypeForEditById(int id);
        IEnumerable<SearchResultModel> SearchByNameAndDesc(string searchText);
        Task<ServiceTypeDTO> GetServiceTypeById(int id);
    }
}
