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
using TSTB.BLL.DTOs.WidgetModelDTO;
using TSTB.BLL.ViewModel;
using TSTB.DAL.Models.Widget;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.WidgetService
{
    public class WidgetService : IWidgetService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public WidgetService(ApplicationDbContext applicationDbContext, IMapper iMapper)
        {
            _dbContext = applicationDbContext;
            _mapper = iMapper;

        }
        public async Task CreateWidget(CreateWidgetDTO modelDTO)
        {
            DAL.Models.Widget.Widget ind = _mapper.Map<DAL.Models.Widget.Widget>(modelDTO);

            if (modelDTO.SVG != null)
            {
                XDocument document = XDocument.Load(modelDTO.SVG.OpenReadStream());
                ind.Logo = document.ToString();
            }

            await _dbContext.Widgets.AddAsync(ind);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditWidget(EditWidgetDTo modelDTO)
        {
            DAL.Models.Widget.Widget ind = _mapper.Map<DAL.Models.Widget.Widget>(modelDTO);
            ind.Logo = modelDTO.LogoName;
            if (modelDTO.SVG != null)
            {
                XDocument document = XDocument.Load(modelDTO.SVG.OpenReadStream());
                ind.Logo = document.ToString();
            }
            _dbContext.Widgets.Update(ind);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<WidgetDTO> GetAllWidgets()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var ind = _dbContext.Widgets;
            var result = _dbContext.WidgetTranslates
                .Where(p => p.LanguageCulture == culture).Join(ind, p => p.WidgetID, k => k.Id,
                    (p, k) => new WidgetDTO
                    {
                        Id = k.Id,                      
                        Name = p.Name,
                        Description = p.Description,
                        Logo = k.Logo,
                        Footer = p.Footer,
                        IsPublish = k.IsPublish,
                        Link = k.Link
                    });

            return result;
        }

        public IEnumerable<WidgetDTO> GetAllPublishWidgets()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var ind = _dbContext.Widgets.Where(k=>k.IsPublish == true);
            var result = _dbContext.WidgetTranslates
                .Where(p => p.LanguageCulture == culture).Join(ind, p => p.WidgetID, k => k.Id,
                    (p, k) => new WidgetDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Logo = k.Logo,
                        Footer = p.Footer,
                        IsPublish = k.IsPublish,
                        Link = k.Link
                    });

            return result;
        }

        public async Task<WidgetDTO> GetWidgetByIdAsync(int indId)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var ind = await _dbContext.Widgets.FindAsync(indId);
            var translate = await _dbContext.WidgetTranslates
                .Where(p => p.LanguageCulture == culture).SingleOrDefaultAsync(p => p.WidgetID == ind.Id);
            WidgetDTO result = new WidgetDTO
            {
                Id = ind.Id,
                Name = translate.Name,              
                Description = translate.Description,
                Footer = translate.Footer,
                IsPublish = ind.IsPublish,
                Link = ind.Link
            };
            return result;
        }

        public async Task RemoveAllWidgets()
        {
            IEnumerable<DAL.Models.Widget.Widget> ind =  _dbContext.Widgets;
            _dbContext.Widgets.RemoveRange(ind);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveWidget(int id)
        {
            DAL.Models.Widget.Widget ind = await _dbContext.Widgets.FindAsync(id);
            _dbContext.Widgets.Remove(ind);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EditWidgetDTo> GetWidgetForEditById(int id)
        {
            var industry = await _dbContext.Widgets
              .Include(i => i.WidgetTranslates)
              .SingleOrDefaultAsync(k => k.Id == id);
            EditWidgetDTo editDTO = _mapper.Map<EditWidgetDTo>(industry);
            editDTO.LogoName = industry.Logo;
            return editDTO;
        }

        public IEnumerable<SearchResultModel> SearchByNameAndDesc(string searchText)
        {
            List<SearchResultModel> result = new List<SearchResultModel>();
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (searchText != null)
            {
                string[] texts = searchText.Split(' ');
                List<WidgetTranslate> indTranslate = new List<WidgetTranslate>(_dbContext.WidgetTranslates.Include(o => o.Widget).AsQueryable());
                foreach (string t in texts)
                {
                    var temp = indTranslate.Where(o => o.Name.Contains(t) || o.Description.Contains(t));

                    foreach (WidgetTranslate n in temp)
                    {
                        if (n.Widget.IsPublish)
                        {
                            SearchResultModel title = new SearchResultModel();

                            title.Id = Guid.NewGuid().ToString();
                            title.ResultType = DAL.Models.Enums.SearchResultType.Industry;
                            title.SearchResultId = n.WidgetID;
                            title.SearchResultTextinTitle = indTranslate.Where(o => o.LanguageCulture == culture).SingleOrDefault(o => o.WidgetID == n.WidgetID).Name;
                            title.SearchResultTextinDescription = indTranslate.Where(o => o.LanguageCulture == culture).SingleOrDefault(o => o.WidgetID == n.WidgetID).Description;
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
