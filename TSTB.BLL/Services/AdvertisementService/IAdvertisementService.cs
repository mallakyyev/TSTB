using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.AdvertisementDTO;
using TSTB.DAL.Models.Advertisement;

namespace TSTB.BLL.Services.AdvertisementService
{
    public interface IAdvertisementService
    {
        Task CreateAdvertisement(CreateAdvertisementDTO model);
        Task EditAdvertisement(EditAdvertisementDTO model);
        IEnumerable<AdvertisementDTO> GetAllAdvertisements();
        IEnumerable<AdvertisementDTO> GetAllPublishAdvertisements();
        Task<EditAdvertisementDTO> GetAdvertisementForEditById(int id);
        Task DeleteAdvertisementsById(int id);
    }
}
