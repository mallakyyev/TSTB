using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TSTB.BLL.DTOs.ServicesDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.BLL.ViewModel;
using TSTB.DAL.Models.Services;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.Services
{
    public class ServiceService : IServiceService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IServicesTypeService _servicesTypeService;

        public ServiceService(ApplicationDbContext applicationDbContext, IMapper iMapper, IImageService imageService,
            IServicesTypeService servicesTypeService)
        {
            _dbContext = applicationDbContext;
            _mapper = iMapper;
            _imageService = imageService;
            _servicesTypeService = servicesTypeService;

        }
        public async Task CreateService(CreateServiceDTO modelDTO)
        {
            DAL.Models.Services.Services services = _mapper.Map<DAL.Models.Services.Services>(modelDTO);
            
           

            if (modelDTO.SVG != null)
            {
                XDocument document = XDocument.Load(modelDTO.SVG.OpenReadStream());
                services.Logo = document.ToString();
            }
            await _dbContext.Services.AddAsync(services);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditService(EditServiceDTO modelDTO)
        {
            DAL.Models.Services.Services services = _mapper.Map<DAL.Models.Services.Services>(modelDTO);
            services.Logo = modelDTO.LogoName;
            if (modelDTO.SVG != null)
            {
                XDocument document = XDocument.Load(modelDTO.SVG.OpenReadStream());
                services.Logo = document.ToString();
            }

            _dbContext.Services.Update(services);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<ServiceDTO> GetAllPublishServices()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var services = _dbContext.Services.Where(k=>k.IsPublish == true);
            var result = _dbContext.ServiceTranslates
                .Where(p => p.LanguageCulture == culture).Join(services, p => p.ServiceId, k => k.Id,
                    (p, k) => new ServiceDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Logo = k.Logo,
                        VideoLink = k.VideoLink,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public IEnumerable<ServiceDTO> GetAllServices()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var services = _dbContext.Services;
            var result = _dbContext.ServiceTranslates
                .Where(p => p.LanguageCulture == culture).Join(services, p => p.ServiceId, k => k.Id,
                    (p, k) => new ServiceDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Logo = k.Logo,
                        VideoLink = k.VideoLink,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public async Task<ServiceDTO> GetServicebyId(int id)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var services = await _dbContext.Services.Include(i => i.ServiceTypes).ThenInclude(t => t.ServiceTypeTranslates)
                .SingleOrDefaultAsync(s => s.Id == id);
            if (services != null) {
                var tr = _dbContext.ServiceTranslates.Where(p => p.LanguageCulture == culture).FirstOrDefault(o => o.ServiceId == services.Id);                   

                        ServiceDTO result = new ServiceDTO
                        {
                            Id = services.Id,
                            Name = tr.Name,
                            Description = tr.Description,
                            Logo = services.Logo,
                            IsPublish = services.IsPublish,
                            VideoLink = services.VideoLink,
                            ServiceTypes = _servicesTypeService.GetAllServiceTypesByServiceId(services.Id)
                        };

                return result;
            }
            return null;
        }

        public async Task<EditServiceDTO> GetServiceForEditById(int id)
        {
            var service = await _dbContext.Services
              .Include(i => i.ServiceTranslates)
              .SingleOrDefaultAsync(k => k.Id == id);
            EditServiceDTO editServiceDTO = _mapper.Map<EditServiceDTO>(service);
            editServiceDTO.LogoName = service.Logo;
            return editServiceDTO;
        }

        public async Task RemoveAllServices()
        {
            _dbContext.Services.RemoveRange(_dbContext.Services);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveService(int id)
        {
            DAL.Models.Services.Services services = await _dbContext.Services.FindAsync(id);
            _dbContext.Services.Remove(services);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<SearchResultModel> SearchByNameAndDesc(string searchText)
        {
            List<SearchResultModel> result = new List<SearchResultModel>();
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            string[] texts = searchText.Split(' ');
            List<ServiceTranslate> serviceTranslates = new List<ServiceTranslate>(_dbContext.ServiceTranslates.Include(o => o.Services));
            foreach (string t in texts)
            {
                var temp = serviceTranslates.Where(o => o.Name.Contains(t) || o.Description.Contains(t));
                foreach (ServiceTranslate n in temp)
                {
                    if (n.Services.IsPublish)
                    {
                        SearchResultModel title = new SearchResultModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            ResultType = DAL.Models.Enums.SearchResultType.Services,
                            SearchResultId = n.ServiceId,
                            SearchResultTextinTitle = serviceTranslates.SingleOrDefault(o => o.LanguageCulture == culture && o.ServiceId == n.ServiceId).Name,
                            SearchResultTextinDescription = serviceTranslates.SingleOrDefault(o => o.LanguageCulture == culture && o.ServiceId == n.ServiceId).Description
                        };
                        var c = result.SingleOrDefault(o => o.SearchResultId == title.SearchResultId);
                        if (c != null)
                        {
                            c.Count += 1;
                        }
                        else
                        {
                            result.Add(title);
                        }
                    }
                }

            }
            return result;
        }
    }
}
