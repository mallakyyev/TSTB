using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.MenuModelDTO;
using TSTB.BLL.DTOs.NewsModelDTO;

namespace TSTB.BLL.Services.NewsCategory
{
    public interface INewsCategoryService
    {
        IEnumerable<NewsCategoryDTO> GetAllNewsCategory();
       

        Task CreateNewsCategory(CreateNewsCategoryDTO modelDTO);

        Task EditNewsCategory(EditNewsCategoryDTO modelDTO);

        Task RemoveNewsCategory(int id);
        Task<EditNewsCategoryDTO> GetNewsCategoryForEditById(int id);
        Task<NewsCategoryDTO> GetNewsCategoryByIdAsync(int id);
    }
}
