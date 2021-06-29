using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TSTB.BLL.DTOs.IndustryModelDTO;
using TSTB.BLL.ViewModel;
using TSTB.DAL.Models.Industry;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.Industry
{
    public class IndustryService : IIndustryService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public IndustryService(ApplicationDbContext applicationDbContext, IMapper iMapper)
        {
            _dbContext = applicationDbContext;
            _mapper = iMapper;

        }
        public async Task CreateIndustry(CreateIndustryDTO modelDTO)
        {
            DAL.Models.Industry.Industry ind = _mapper.Map<DAL.Models.Industry.Industry>(modelDTO);

            if (modelDTO.SVG != null)
            {
                XDocument document = XDocument.Load(modelDTO.SVG.OpenReadStream());
                ind.Logo = document.ToString();
            }

            await _dbContext.Industries.AddAsync(ind);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditIndustry(EditIndustryDTO modelDTO)
        {
            DAL.Models.Industry.Industry ind = _mapper.Map<DAL.Models.Industry.Industry>(modelDTO);
            ind.Logo = modelDTO.LogoName;
            if (modelDTO.SVG != null)
            {
                XDocument document = XDocument.Load(modelDTO.SVG.OpenReadStream());
                ind.Logo = document.ToString();
            }
            _dbContext.Industries.Update(ind);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<IndustryDTO> GetAllIndustry()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var ind = _dbContext.Industries;
            var result = _dbContext.IndustryTranslates
                .Where(p => p.LanguageCulture == culture).Join(ind, p => p.IndustryId, k => k.Id,
                    (p, k) => new IndustryDTO
                    {
                        Id = k.Id,                      
                        Name = p.Name,
                        Description = p.Description,
                        Logo = k.Logo,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public IEnumerable<IndustryDTO> GetAllPublishIndustry()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var ind = _dbContext.Industries.Where(k=>k.IsPublish == true);
            var result = _dbContext.IndustryTranslates
                .Where(p => p.LanguageCulture == culture).Join(ind, p => p.IndustryId, k => k.Id,
                    (p, k) => new IndustryDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Logo = k.Logo,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public async Task<IndustryDTO> GetIndustryByIdAsync(int indId)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var ind = await _dbContext.Industries.FindAsync(indId);
            var translate = await _dbContext.IndustryTranslates
                .Where(p => p.LanguageCulture == culture).SingleOrDefaultAsync(p => p.IndustryId == ind.Id);
            IndustryDTO result = new IndustryDTO
            {
                Id = ind.Id,
                Name = translate.Name,              
                Description = translate.Description,
                IsPublish = ind.IsPublish,               

            };
            return result;
        }

        public async Task RemoveAllINdustries()
        {
            IEnumerable<DAL.Models.Industry.Industry> ind =  _dbContext.Industries;
            _dbContext.Industries.RemoveRange(ind);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveIndustry(int id)
        {
            DAL.Models.Industry.Industry ind = await _dbContext.Industries.FindAsync(id);
            _dbContext.Industries.Remove(ind);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EditIndustryDTO> GetIndustryForEditById(int id)
        {
            var industry = await _dbContext.Industries
              .Include(i => i.IndustryTranslates)
              .SingleOrDefaultAsync(k => k.Id == id);
            EditIndustryDTO editIndustryDTO = _mapper.Map<EditIndustryDTO>(industry);
            editIndustryDTO.LogoName = industry.Logo;
            return editIndustryDTO;
        }

        public IEnumerable<SearchResultModel> SearchByNameAndDesc(string searchText)
        {
            List<SearchResultModel> result = new List<SearchResultModel>();
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (searchText != null)
            {
                string[] texts = searchText.Split(' ');
                List<IndustryTranslate> indTranslate = new List<IndustryTranslate>(_dbContext.IndustryTranslates.Include(o => o.Industry).AsQueryable());
                foreach (string t in texts)
                {
                    var temp = indTranslate.Where(o => o.Name.ToLower().Contains(t.ToLower()) || o.Description.ToLower().Contains(t.ToLower()));

                    foreach (IndustryTranslate n in temp)
                    {
                        if (n.Industry.IsPublish)
                        {
                            SearchResultModel title = new SearchResultModel();

                            title.Id = Guid.NewGuid().ToString();
                            title.ResultType = DAL.Models.Enums.SearchResultType.Industry;
                            title.SearchResultId = n.IndustryId;
                            title.SearchResultTextinTitle = indTranslate.Where(o => o.LanguageCulture == culture).SingleOrDefault(o => o.IndustryId == n.IndustryId).Name;
                            title.SearchResultTextinDescription = indTranslate.Where(o => o.LanguageCulture == culture).SingleOrDefault(o => o.IndustryId == n.IndustryId).Description;
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
