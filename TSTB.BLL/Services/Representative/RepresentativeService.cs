using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TSTB.BLL.DTOs.NewsModelDTO;
using TSTB.BLL.DTOs.RepresentativesModelDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.DAL.Models.Representatives;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.Representative
{
    public class RepresentativeService:IRepresentativeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _appEnvironment;
        public RepresentativeService(ApplicationDbContext applicationDbContext, IMapper mapper, IImageService imageService, IWebHostEnvironment appEnvironment)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
            _imageService = imageService;
            _appEnvironment = appEnvironment;
        }
        public IEnumerable<RepresentativeDTO> GetAllRepresentatives()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var reps = _dbContext.Representatives;
            var result = _dbContext.RepresentativesTranslates
                .Where(p => p.LanguageCulture == culture).Join(reps, p => p.RepresentativeId, k => k.Id,
                    (p, k) => new RepresentativeDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        Image = k.Image,
                        Description = p.Description,
                        Person = k.Person,
                        IsPublish = k.IsPublish,
                        Address = k.Address,
                        Site = k.Site,
                        Email = k.Email,
                        Phone = k.Phone
                    });

            return result;
        }

        public IEnumerable<RepresentativeDTO> GetAllPublishRepresentatives()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var reps = _dbContext.Representatives.Where(k=>k.IsPublish == true);
            var result = _dbContext.RepresentativesTranslates
                .Where(p => p.LanguageCulture == culture).Join(reps, p => p.RepresentativeId, k => k.Id,
                    (p, k) => new RepresentativeDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        Image = k.Image,
                        Description = p.Description,
                        Person = k.Person,
                        IsPublish = k.IsPublish,
                        Address = k.Address,
                        Site = k.Site,
                        Email = k.Email,
                        Phone = k.Phone
                    });

            return result;
        }

        public async Task CreateRepresentative(CreateRepresentativeDTO modelDTO)
        {
            DAL.Models.Representatives.Representatives reps = _mapper.Map<DAL.Models.Representatives.Representatives>(modelDTO);
            if (modelDTO.FormFile != null)
            {
                reps.Image = await _imageService.UploadImage(modelDTO.FormFile, "Representatives");
            }
            await _dbContext.Representatives.AddAsync(reps);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditRepresentative(EditRepresentativeDTO modelDTO)
        {
            DAL.Models.Representatives.Representatives reps = _mapper.Map<DAL.Models.Representatives.Representatives>(modelDTO);

            if (modelDTO.FormFile != null)
            {
                if(modelDTO.Image != null)
                {
                    _imageService.DeleteImage(modelDTO.Image, "Representatives");
                }
                
                reps.Image = await _imageService.UploadImage(modelDTO.FormFile, "Representatives");
            }
           
            _dbContext.Representatives.Update(reps);
            await _dbContext.SaveChangesAsync();

        }

        public async Task RemoveRepresentative(int id)
        {
            DAL.Models.Representatives.Representatives rep = await _dbContext.Representatives.FindAsync(id);
            if (!string.IsNullOrEmpty(rep.Image))
            {
                _imageService.DeleteImage(rep.Image, "Representatives");
            }
            _dbContext.Representatives.Remove(rep);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<RepresentativeDTO> GetRepresentativeByIdAsync(int id)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            DAL.Models.Representatives.Representatives rep = await _dbContext.Representatives.FindAsync(id);
            var translate = await _dbContext.RepresentativesTranslates
                .Where(p => p.LanguageCulture == culture).SingleOrDefaultAsync(p => p.RepresentativeId == rep.Id);
            RepresentativeDTO result = new RepresentativeDTO
            {
                Id = rep.Id,
                Name = translate.Name,
                Image = rep.Image,
                Description = translate.Description,
                Person = rep.Person,
                IsPublish = rep.IsPublish,
                Address = rep.Address,
                Site = rep.Site,
                Email = rep.Email,
                Phone = rep.Phone

            };
            return result;
        }

        public IEnumerable<RepresentativeDTO> SearchRepresentativeByName(string name = "")
        {

            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var reps = _dbContext.Representatives;
            var result =_dbContext.RepresentativesTranslates
                .Where(k => k.Name.Contains(name)).Join(reps, p => p.RepresentativeId, k => k.Id,
                    (p, k) => new RepresentativeDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        Image = k.Image,
                        Description = p.Description,
                        Person = k.Person,
                        IsPublish = k.IsPublish,
                        Address = k.Address,
                        Site = k.Site,
                        Email = k.Email,
                        Phone = k.Phone
                    });

            return result;
        }

        public async Task<EditRepresentativeDTO> GetRepresentativeForEditById(int id)
        {
            var rep = await _dbContext.Representatives
              .Include(i => i.RepresentativesTranslates)
              .SingleOrDefaultAsync(k => k.Id == id);
            EditRepresentativeDTO editRepDTO = _mapper.Map<EditRepresentativeDTO>(rep);
            editRepDTO.Image = rep.Image;
            return editRepDTO;
        }
    }
}
