using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.IndustryModelDTO;
using TSTB.BLL.ViewModel;

namespace TSTB.BLL.Services.Industry
{
    public interface  IIndustryService
    {
        IEnumerable<IndustryDTO> GetAllIndustry();
        IEnumerable<IndustryDTO> GetAllPublishIndustry();

        Task CreateIndustry(CreateIndustryDTO modelDTO);

        Task EditIndustry(EditIndustryDTO modelDTO);

        Task RemoveIndustry(int id);
        Task<IndustryDTO> GetIndustryByIdAsync(int indId);
        public  Task<EditIndustryDTO> GetIndustryForEditById(int id);
        Task RemoveAllINdustries();
        IEnumerable<SearchResultModel> SearchByNameAndDesc(string searchText);
    }
}
