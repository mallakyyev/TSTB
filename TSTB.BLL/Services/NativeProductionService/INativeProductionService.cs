using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.NativeProductionsDTO;

namespace TSTB.BLL.Services.NativeProductionService
{
    public interface INativeProductionService
    {
        Task CreateNativeProduction(CreateNativeProductionDTO model);
        Task EditNativeProduction(EditNativeProductionDTO model);
        IEnumerable<NativeProdutionDTO> GetAllNativeProductions();
        Task<NativeProdutionDTO> GetNativeProdutionById(int id);
        Task<EditNativeProductionDTO> GetNativeProductionForEditById(int id);
        Task DeleteNativeProductionById(int id);

        IEnumerable<NativeProdutionDTO> GetSevenPublishNativeProduct();
    }
}
