using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.SayingsDTO;
using TSTB.Web.Data;
using TSTB.DAL.Models.Sayings;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TSTB.BLL.Services.Sayings
{
    public class SayingsService : ISayingsService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public SayingsService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper; 

        }
        public async Task CreateSayings(CreateSayingsDTO model)
        {
            TSTB.DAL.Models.Sayings.Sayings s = _mapper.Map<TSTB.DAL.Models.Sayings.Sayings>(model);
            await _dbContext.Sayings.AddAsync(s);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditSayings(EditSayingsDTO model)
        {
            TSTB.DAL.Models.Sayings.Sayings s = _mapper.Map<TSTB.DAL.Models.Sayings.Sayings>(model);
             _dbContext.Sayings.Update(s);
            await _dbContext.SaveChangesAsync();
        }

        public  IEnumerable<SayingsDTO> GetAllPublishSayingsAsync()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var s =  _dbContext.Sayings.Where(k => k.IsPublish == true);
            var result =   _dbContext.SayingsTranslates
                .Where(p => p.LanguageCulture == culture).Join(s, p => p.SayingsId, k => k.Id,
                    (p, k) => new SayingsDTO
                    {
                        Id = k.Id,
                        Author = p.Author,
                        AuthorPosition = p.AuthorPosition,
                        IsPublish = k.IsPublish,
                        SayingsText = p.SayingsText
                    });

            return result;
        }

        public IEnumerable<SayingsDTO> GetAllSayingsAsync()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var s = _dbContext.Sayings;
            var result = _dbContext.SayingsTranslates
                .Where(p => p.LanguageCulture == culture).Join(s, p => p.SayingsId, k => k.Id,
                    (p, k) => new SayingsDTO
                    {
                        Id = k.Id,
                        Author = p.Author,
                        AuthorPosition = p.AuthorPosition,
                        IsPublish = k.IsPublish,
                        SayingsText = p.SayingsText
                    });

            return result;
        }

        public async Task<SayingsDTO> GetSayingsByIdAsync(int id)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var s = await _dbContext.Sayings.FindAsync(id);
            var tr = _dbContext.SayingsTranslates
                .SingleOrDefault(p => p.LanguageCulture == culture && p.SayingsId == id);

            SayingsDTO result = new SayingsDTO ()
                    {
                        Id = s.Id,
                        Author = tr.Author,
                        AuthorPosition = tr.AuthorPosition,
                        IsPublish = s.IsPublish,
                        SayingsText = tr.SayingsText
                    };

            return result;
        }

        public async Task<EditSayingsDTO> GetSayingsForEditByIdAsync(int id)
        {
            var s = await _dbContext.Sayings
             .Include(i => i.SayingsTranslates)
             .SingleOrDefaultAsync(k => k.Id == id);
            EditSayingsDTO editDTO = _mapper.Map<EditSayingsDTO>(s);
                       
            return editDTO;
        }

        public async Task RemoveSayings(int id)
        {
            TSTB.DAL.Models.Sayings.Sayings s = await _dbContext.Sayings.FindAsync(id);
            if (s != null)
                _dbContext.Sayings.Remove(s);
            _dbContext.SaveChanges();
        }
    }
}
