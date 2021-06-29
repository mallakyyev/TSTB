using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TSTB.BLL.DTOs.ServicesDTO;
using TSTB.BLL.ViewModel;
using TSTB.DAL.Models.Services;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.Services
{
    public class ServiceTypeService :IServicesTypeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServiceTypeService(ApplicationDbContext applicationDbContext, IMapper iMapper)
        {
            _dbContext = applicationDbContext;
            _mapper = iMapper;

        }

        public async Task CreateServiceType(CreateServiceTypeDTO modelDTO)
        {
            DAL.Models.Services.ServiceType serviceType = _mapper.Map<DAL.Models.Services.ServiceType>(modelDTO);
            await _dbContext.ServiceTypes.AddAsync(serviceType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditServiceType(EditServiceTypeDTO modelDTO)
        {
            DAL.Models.Services.ServiceType serviceType = _mapper.Map<DAL.Models.Services.ServiceType>(modelDTO);
            _dbContext.ServiceTypes.Update(serviceType);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<ServiceTypeDTO> GetAllPublishServiceTypes()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var serviceTypes = _dbContext.ServiceTypes.Where(k=>k.IsPublish == true);
            var result = _dbContext.ServiceTypeTranslates
                .Where(p => p.LanguageCulture == culture).Join(serviceTypes, p => p.ServiceTypeId, k => k.Id,
                    (p, k) => new ServiceTypeDTO
                    {
                        Id = k.Id,
                        ServiceId = k.ServiceId,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public IEnumerable<ServiceTypeDTO> GetAllServiceTypes()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var serviceTypes = _dbContext.ServiceTypes;
            var result = _dbContext.ServiceTypeTranslates
                .Where(p => p.LanguageCulture == culture).Join(serviceTypes, p => p.ServiceTypeId, k => k.Id,
                    (p, k) => new ServiceTypeDTO
                    {
                        Id = k.Id,
                        ServiceId = k.ServiceId,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish,
                        ServiceCategoryName = _dbContext.ServiceTranslates.Where(t => t.LanguageCulture == culture).FirstOrDefault(t => t.ServiceId == k.ServiceId).Name,
                    });

            return result;
        }

        public IEnumerable<ServiceTypeDTO> GetAllServiceTypesByServiceId(int serviceId)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var serviceTypes = _dbContext.ServiceTypes.Where(k => k.ServiceId == serviceId);
            var result = _dbContext.ServiceTypeTranslates
                .Where(p => p.LanguageCulture == culture).Join(serviceTypes, p => p.ServiceTypeId, k => k.Id,
                    (p, k) => new ServiceTypeDTO
                    {
                        Id = k.Id,
                        ServiceId = k.ServiceId,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public async Task<ServiceTypeDTO> GetServiceTypeById(int id)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var serviceTypes = await _dbContext.ServiceTypes.SingleOrDefaultAsync(k => k.Id == id);

            var p = await _dbContext.ServiceTypeTranslates.Where(p => p.LanguageCulture == culture).SingleOrDefaultAsync(p => p.ServiceTypeId == id);

                    ServiceTypeDTO result = new ServiceTypeDTO()
                    {
                        Id = serviceTypes.Id,
                        ServiceId = serviceTypes.ServiceId,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = serviceTypes.IsPublish,
                        
                    };

            return result;
        }

        public async Task<EditServiceTypeDTO> GetServiceTypeForEditById(int id)
        {
            var serviceType = await _dbContext.ServiceTypes
             .Include(i => i.ServiceTypeTranslates)
             .SingleOrDefaultAsync(k => k.Id == id);
            EditServiceTypeDTO editServiceTypeDTO = _mapper.Map<EditServiceTypeDTO>(serviceType);
            return editServiceTypeDTO;
        }

        public async Task RemoveAllServiceTypes()
        {
            _dbContext.ServiceTypes.RemoveRange(_dbContext.ServiceTypes);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveServiceTypes(int id)
        {
            DAL.Models.Services.ServiceType serviceType = await _dbContext.ServiceTypes.FindAsync(id);
            _dbContext.ServiceTypes.Remove(serviceType);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<SearchResultModel> SearchByNameAndDesc(string searchText)
        {
            List<SearchResultModel> result = new List<SearchResultModel>();
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (searchText != null)
            {
                string[] texts = searchText.Split(' ');
                List<ServiceTypeTranslate> serviceTypeTranslates = new List<ServiceTypeTranslate>(_dbContext.ServiceTypeTranslates.Include(o => o.ServiceType).AsQueryable());
                foreach (string t in texts)
                {
                    var temp = serviceTypeTranslates.Where(o => o.Name.Contains(t) || o.Description.Contains(t));

                    foreach (ServiceTypeTranslate n in temp)
                    {
                        if (n.ServiceType.IsPublish)
                        {
                            SearchResultModel title = new SearchResultModel();

                            title.Id = Guid.NewGuid().ToString();
                            title.ResultType = DAL.Models.Enums.SearchResultType.ServiceType;
                            title.SearchResultId = n.ServiceTypeId;
                            title.SearchResultTextinTitle = serviceTypeTranslates.Where(o => o.LanguageCulture == culture).SingleOrDefault(o => o.ServiceTypeId == n.ServiceTypeId).Name;
                            title.SearchResultTextinDescription = serviceTypeTranslates.Where(o => o.LanguageCulture == culture).SingleOrDefault(o => o.ServiceTypeId == n.ServiceTypeId).Description;
                            title.Count = 1;

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
            else
                return null;

        }

    }
}
