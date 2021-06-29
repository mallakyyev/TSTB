using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.CharityModelDTO;
using TSTB.BLL.ViewModel;

namespace TSTB.BLL.Services.Charity
{
    public interface ICharityService
    {
        ICollection<CharityDTO> GetAllCharities();
        ICollection<CharityDTO> GetAllPublishCharities();
        Task CreateCharity(CreateCharityDTO modelDTO);
        Task EditCharity(EditCharityDTO modelDTO);
        Task RemoveCharityById(int id);
        Task<CharityDTO> GetCharityById(int id);
        Task<EditCharityDTO> GetCharityForEditById(int id);
        
    }
}
