using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.NewsPaperModelDTO;
using TSTB.BLL.ViewModel;
using TSTB.DAL.Models.NewsPapers;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.NewsPaper
{
    public interface  INewsPaperService
    {
        IEnumerable<NewsPaperDTO> GetAllNewsPapers();
        IEnumerable<NewsPaperDTO> GetAllPublishNewsPapers();
        IEnumerable<NewsPaperDataDTO> GetAllNewsPaperData();
        IEnumerable<NewsPaperDataDTO> GetAllPublishNewsPaperData();
       

        Task CreateNewsPaper(CreateNewsPaperDTO modelDTO);

        Task EditNewsPaper(EditNewsPaperDTO modelDTO);
        Task EditNewsPaperData(EditNewsPaperDataDTO modelDTO);
        
        Task RemoveNewsPaperById(int id);
        Task RemoveNewsPaperData(int id);
        Task RemoveAllNewsPapers();
        Task RemoveNewsPaperFileById(int id);
        Task<NewsPaperData> GetNewsPaperDataByIDAsync(int newsDataId);
        Task<NewsPaperDTO> GetNewsPaperByIdAsync(int newsId);
        Task<EditNewsPaperDTO> GetNewsPaperForEditById(int id);
        Task<EditNewsPaperDataDTO> GetNewsPaperDataForEditById(int id);
        public IEnumerable<NewsPaperFiles> GetNewsPaperFileById(int newsFileId);
        Task CreateNewsPaperData(CreateNewsPaperDataDTO newsPaperDataDTO);

        IEnumerable<SearchResultModel> SearchByNameAndDesc(string searchText);
        IEnumerable<NewsPaperDataDTO> GetNewsPaperDataByNewsPaperId(int id);
        NewsPaperData GetNewsPaperDataAndFiles(int id);
    }
}
