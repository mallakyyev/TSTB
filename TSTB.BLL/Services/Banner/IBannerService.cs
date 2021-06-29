using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.BannerModelDTO;

namespace TSTB.BLL.Services.Banner
{
    public interface IBannerService
    {
        IEnumerable<BannerDTO> GetAllBanners();
        IEnumerable<BannerDTO> GetAllPublishBanners();
        Task<BannerDTO> GetBannerByIdAsync(int id);
        Task EditBanner(EditBannerDTO editModel);

        Task CreateBanner(CreateBannerDTO createBanner);
        Task RemoveBannerById(int id);
        Task<EditBannerDTO> GetBannerForEditByIdAsync(int id);
    }
}
