using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.PartnersModelDTO;
using TSTB.DAL.Models.Partners;

namespace TSTB.BLL.Services.Partner
{
    public interface  IPartnerService
    {
        IEnumerable<PartnersDTO> GetAllPartners();
        IEnumerable<PartnersDTO> GetAllPublishPartners();

        Task<PartnersDTO> GetPublishPartnerByIdAsync(int id);

        Task<int> CreatePartner(CreatePartnerDTO modelDTO);

        Task EditPartner(EditPartnerDTO modelDTO); 

        Task RemovePartner(int id);
        Task RemoveAllPartners();
        Task<EditPartnerDTO> GetPartnerForEditById(int id);
    }
}
