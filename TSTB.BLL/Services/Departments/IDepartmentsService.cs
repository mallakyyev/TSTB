
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.DepartmentModelDTO;

namespace TSTB.BLL.Services.Departments
{
    public interface IDepartmentsService
    {
        public IEnumerable<DepartmentDTO> GetAllDepartments();

        public Task<DepartmentDTO> GetDepartmentByIdAsync(int id);

        public Task<EditDepartmentDTO> GetDepartmentForEditByIdAsync(int id);

        public Task CreateDeparment(CreateDepartmentDTO modelDTO);

        public Task EditDepartment(EditDepartmentDTO modelDTO);

        public Task RemoveDepartment(int id);
        public IEnumerable<DepartmentDTO> GetAllPublishDepartments();


    }
}
