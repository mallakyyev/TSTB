using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TSTB.BLL.DTOs.DepartmentModelDTO;
using TSTB.BLL.DTOs.MenuModelDTO;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentsService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DepartmentService(ApplicationDbContext applicationDbContext, IMapper iMapper)
        {
            _dbContext = applicationDbContext;
            _mapper = iMapper;

        }

        public async Task CreateDeparment(CreateDepartmentDTO modelDTO)
        {
            DAL.Models.Departments.Departments departments = _mapper.Map<DAL.Models.Departments.Departments>(modelDTO);
            await _dbContext.Departments.AddAsync(departments);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditDepartment(EditDepartmentDTO modelDTO)
        {
            DAL.Models.Departments.Departments departments = _mapper.Map<DAL.Models.Departments.Departments>(modelDTO);
            _dbContext.Departments.Update(departments);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var departments = _dbContext.Departments;
            var result = _dbContext.DepartmentsTranslates
                .Where(p => p.LanguageCulture == culture).Join(departments, p => p.DepartmentId, k => k.Id,
                    (p, k) => new DepartmentDTO
                    {
                        Id = k.Id,
                        Description = p.Description,
                        Name = p.Name,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public IEnumerable<DepartmentDTO> GetAllPublishDepartments()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var departments = _dbContext.Departments.Where(k=>k.IsPublish == true);
            var result = _dbContext.DepartmentsTranslates
                .Where(p => p.LanguageCulture == culture).Join(departments, p => p.DepartmentId, k => k.Id,
                    (p, k) => new DepartmentDTO
                    {
                        Id = k.Id,
                        Description = p.Description,
                        Name = p.Name,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public async Task<DepartmentDTO> GetDepartmentByIdAsync(int id)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var department = await _dbContext.Departments.SingleOrDefaultAsync(k => k.Id == id);

            var translate = await _dbContext.DepartmentsTranslates
                .Where(p => p.LanguageCulture == culture).SingleOrDefaultAsync(p => p.DepartmentId == department.Id);
            DepartmentDTO result = new DepartmentDTO
            {
                Id = department.Id,
                IsPublish = department.IsPublish,
                Description = translate.Description,
                Name = translate.Name
            };

            return result;
        }

        public async Task<EditDepartmentDTO> GetDepartmentForEditByIdAsync(int id)
        {
            var department = await _dbContext.Departments
                .Include(i => i.DepartmentsTranslates)
                .SingleOrDefaultAsync(k => k.Id == id);
            EditDepartmentDTO editDepartmentDTO = _mapper.Map<EditDepartmentDTO>(department);
            return editDepartmentDTO;
        }

        public async Task RemoveDepartment(int id)
        {
            DAL.Models.Departments.Departments departments = await _dbContext.Departments.FindAsync(id);
            _dbContext.Departments.Remove(departments);
            await _dbContext.SaveChangesAsync();
        }
    }
}
