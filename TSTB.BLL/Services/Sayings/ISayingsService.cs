using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.SayingsDTO;

namespace TSTB.BLL.Services.Sayings
{
    public interface ISayingsService
    {
        Task CreateSayings(CreateSayingsDTO model);
        Task EditSayings(EditSayingsDTO model);
        IEnumerable<SayingsDTO> GetAllSayingsAsync();
        IEnumerable<SayingsDTO> GetAllPublishSayingsAsync();
        Task<EditSayingsDTO> GetSayingsForEditByIdAsync(int id);
        Task<SayingsDTO> GetSayingsByIdAsync(int id);

        Task RemoveSayings(int id);

    }
}
