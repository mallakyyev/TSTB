using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.IndustryModelDTO;
using TSTB.BLL.DTOs.WidgetModelDTO;
using TSTB.BLL.ViewModel;

namespace TSTB.BLL.Services.WidgetService
{
    public interface  IWidgetService
    {
        IEnumerable<WidgetDTO> GetAllWidgets();
        IEnumerable<WidgetDTO> GetAllPublishWidgets();

        Task CreateWidget(CreateWidgetDTO modelDTO);

        Task EditWidget(EditWidgetDTo modelDTO);

        Task RemoveWidget(int id);
        Task<WidgetDTO> GetWidgetByIdAsync(int indId);
        public  Task<EditWidgetDTo> GetWidgetForEditById(int id);
        Task RemoveAllWidgets();
        IEnumerable<SearchResultModel> SearchByNameAndDesc(string searchText);
    }
}
