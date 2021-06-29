using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TSTB.BLL.DTOs.ProjectsModelDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.DAL.Models.Projects;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.Projects
{
    public class ProjectService : IProjectsService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _appEnvironment;
        public ProjectService(ApplicationDbContext dbContext, IMapper mapper, IImageService imageService,IWebHostEnvironment appEnvironment)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _imageService = imageService;
            _appEnvironment = appEnvironment;
        }
        public async Task CreateProject(CreateProjectDTO modelDTO)
        {
            DAL.Models.Projects.Project pr = _mapper.Map<DAL.Models.Projects.Project>(modelDTO);
            if (modelDTO.FormFile != null)
            {
                string fileName = await _imageService.UploadImage(modelDTO.FormFile, "Projects" );
                pr.Image = fileName;
            }
            await _dbContext.Projects.AddAsync(pr);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditProject(EditProjectsDTO modelDTO)
        {
           
            DAL.Models.Projects.Project pr = _mapper.Map<DAL.Models.Projects.Project>(modelDTO);
            
            pr.Image = modelDTO.PictureName;
            if (modelDTO.FormFile != null)
            {
                _imageService.DeleteImage(pr.Image, "Projects");
                pr.Image = await _imageService.UploadImage(modelDTO.FormFile, "Projects");
            }else
            {
                if (modelDTO.DeleteImage)
                {
                    _imageService.DeleteImage(pr.Image, "Projects");
                    pr.Image = null;
                }
            }
            
            _dbContext.Projects.Update(pr);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<ProjectDTO> GetAllActiveProjects()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var pr = _dbContext.Projects.Where(k=>!k.EndDate.HasValue);
            var result = _dbContext.ProjectTranslates
                .Where(p => p.LanguageCulture == culture).Join(pr, p => p.ProjectId, k => k.Id,
                    (p, k) => new ProjectDTO
                    {
                        Id = k.Id,
                        ShortDescription = p.ShortDescription,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish,
                        StartDate = k.StartDate,
                        Image = k.Image,
                        
                    });

            return result;
        }

        public IEnumerable<ProjectDTO> GetAllCompletedProjects()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var pr = _dbContext.Projects.Where(k => k.EndDate.HasValue);
            var result = _dbContext.ProjectTranslates
                .Where(p => p.LanguageCulture == culture).Join(pr, p => p.ProjectId, k => k.Id,
                    (p, k) => new ProjectDTO
                    {
                        Id = k.Id,
                        ShortDescription = p.ShortDescription,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish,
                        StartDate = k.StartDate,
                        EndDate = k.EndDate,
                        Image = k.Image,

                    });

            return result;
        }

        public IEnumerable<ProjectDTO> GetAllProjects()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var pr = _dbContext.Projects;
            var result = _dbContext.ProjectTranslates
                .Where(p => p.LanguageCulture == culture).Join(pr, p => p.ProjectId, k => k.Id,
                    (p, k) => new ProjectDTO
                    {
                        Id = k.Id,
                        ShortDescription = p.ShortDescription,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish,
                        StartDate = k.StartDate,
                        EndDate = k.EndDate,
                        Image = k.Image,
                    });

            return result;
        }

        public IEnumerable<ProjectDTO> GetAllPublishProjects()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var pr = _dbContext.Projects.Where(k => k.IsPublish==true);
            var result = _dbContext.ProjectTranslates
                .Where(p => p.LanguageCulture == culture).Join(pr, p => p.ProjectId, k => k.Id,
                    (p, k) => new ProjectDTO
                    {
                        Id = k.Id,
                        ShortDescription = p.ShortDescription,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish,
                        StartDate = k.StartDate,
                        EndDate = k.EndDate,
                        Image = k.Image,

                    });

            return result;
        }

        public async Task RemoveAllProjects()
        {
            string path = _appEnvironment.WebRootPath + "/images/Projects";

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            _dbContext.News.RemoveRange(_dbContext.News);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveProject(int id)
        {
            DAL.Models.Projects.Project pr = await _dbContext.Projects.FindAsync(id);

            if (!string.IsNullOrEmpty(pr.Image))
            {
                _imageService.DeleteImage(pr.Image, "Projects");
            }
            _dbContext.Projects.Remove(pr);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int prId)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var ind = await _dbContext.Projects.FindAsync(prId);
            var translate = await _dbContext.ProjectTranslates
                .Where(p => p.LanguageCulture == culture).SingleOrDefaultAsync(p => p.ProjectId == ind.Id);
            ProjectDTO result = new ProjectDTO
            {
                Id = ind.Id,
                ShortDescription = translate.ShortDescription,
                Name = translate.Name,
                Description = translate.Description,
                IsPublish = ind.IsPublish,
                StartDate = ind.StartDate,
                EndDate = ind.EndDate,
                Image = ind.Image,

            };
            return result;

        }

        public async Task<Project> GetPictureURL(int id)
        {
            Project p = await _dbContext.Projects.FindAsync(id);
            return p;
            
        }

        public async Task RemoveProjectPictureById(int id)
        {
            DAL.Models.Projects.Project pr = await _dbContext.Projects.FindAsync(id);
            _imageService.DeleteImage(pr.Image, "Projects");
        }

        public async Task<EditProjectsDTO> GetProjectForEditById(int id)
        {
            var pr = await _dbContext.Projects
                .Include(i => i.ProjectTranslates)
                .SingleOrDefaultAsync(k => k.Id == id);
            EditProjectsDTO editProjectDTO = _mapper.Map<EditProjectsDTO>(pr);
            editProjectDTO.PictureName = pr.Image;
            editProjectDTO.DeleteImage = false;
            return editProjectDTO;
        }
    }
}
