using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.CallBackModelDTO;

namespace TSTB.BLL.Services.CallBacks
{
    public interface ICityService
    {
        IEnumerable<CitiesDTO> GetAllCities();

        Task CreateCity(CreateCityDTO modelDTO);

        Task EditCity(EditCityDTO modelDTO);

        Task RemoveCity(int id);
        Task<EditCityDTO> GetCityForEditById(int id);
        Task<CitiesDTO> GetCityById(int id);
    }
}
