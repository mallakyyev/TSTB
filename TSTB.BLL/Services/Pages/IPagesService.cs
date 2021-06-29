using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.MenuModelDTO;

namespace TSTB.BLL.Services.Pages
{
    public interface IPagesService
    {
        IEnumerable<PagesDTO> GetAllPages();
        IEnumerable<PagesDTO> GetAllIsPublishPages();

        Task CreatePages(CreatePagesDTO modelDTO);

        Task EditPages(EditPageDTO modelDTO);

        Task RemovePages(int id);

        Task<PagesDTO> GetPageByMenuId(int menuId);
        Task<PagesDTO> GetPageById(int pageId);
        public Task<EditPageDTO> GetPagesForEditById(int id);
    }
}
