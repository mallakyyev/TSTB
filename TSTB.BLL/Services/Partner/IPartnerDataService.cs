using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.PartnersModelDTO;
using TSTB.DAL.Models.Partners;

namespace TSTB.BLL.Services.Partner
{
    public interface IPartnerDataService
    {
        IEnumerable<PartnerDataDTO> GetAllPartnersData();
        Task<PartnerDataDTO> GetPartnerDataDTOByPartnerId(int partnerId);
        Task<PartnersData> GetPartnerDataByPartnerId(int partnerId);
        IEnumerable<PartnerDataDTO> GetAllPublishPartnersData();

        Task CreatePartnerData(CreatePartnerDataDTO modelDTO);

        Task EditPartnerData(EditPartnerDataDTO modelDTO);

        Task RemovePartnerData(int id);
    
        Task RemoveAllPartnersData();
        public Task<EditPartnerDataDTO> GetPartnerDataForEditById(int id);

    }
}
