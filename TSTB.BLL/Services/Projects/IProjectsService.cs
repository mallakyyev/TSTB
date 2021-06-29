using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.ProjectsModelDTO;
using TSTB.DAL.Models.Projects;

namespace TSTB.BLL.Services.Projects
{
    public interface  IProjectsService
    {
        IEnumerable<ProjectDTO> GetAllProjects();
        IEnumerable<ProjectDTO> GetAllPublishProjects();

        Task CreateProject(CreateProjectDTO modelDTO);

        Task EditProject(EditProjectsDTO modelDTO);

        Task RemoveProject(int id);
        IEnumerable<ProjectDTO> GetAllActiveProjects();
        IEnumerable<ProjectDTO> GetAllCompletedProjects();
        public Task<ProjectDTO> GetProjectByIdAsync(int prId);
        Task RemoveAllProjects();

        public Task<Project> GetPictureURL(int id);
        Task RemoveProjectPictureById(int id);
        public Task<EditProjectsDTO> GetProjectForEditById(int id);


    }
}
