using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.MenuModelDTO;
using TSTB.BLL.DTOs.RepresentativesModelDTO;

namespace TSTB.BLL.Services.Representative
{
    public interface IRepresentativeService
    {
        IEnumerable<RepresentativeDTO> GetAllRepresentatives();
        IEnumerable<RepresentativeDTO> GetAllPublishRepresentatives();

        Task CreateRepresentative(CreateRepresentativeDTO modelDTO);

        Task EditRepresentative(EditRepresentativeDTO modelDTO);

        Task RemoveRepresentative(int id);
        Task<RepresentativeDTO> GetRepresentativeByIdAsync(int id);
        IEnumerable<RepresentativeDTO> SearchRepresentativeByName(string name);
        Task<EditRepresentativeDTO> GetRepresentativeForEditById(int id);
    }
}
