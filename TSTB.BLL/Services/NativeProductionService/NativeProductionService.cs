using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.NativeProductionsDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.NativeProductionService
{

    public class NativeProductionService : INativeProductionService
    {    
    
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public NativeProductionService(ApplicationDbContext applicationDbContext, IMapper mapper, IImageService imageService)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
            _imageService = imageService;       
        }

        public async Task CreateNativeProduction(CreateNativeProductionDTO model)
        {
            DAL.Models.NativeProduction.NativeProduction tr = _mapper.Map<DAL.Models.NativeProduction.NativeProduction>(model);
            if (model.FormFile != null)
            {
                tr.Image = await _imageService.UploadImage(model.FormFile, "NativeProduction");
            }

            await _dbContext.NativeProductions.AddAsync(tr);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNativeProductionById(int id)
        {
            DAL.Models.NativeProduction.NativeProduction nt = await _dbContext.NativeProductions.FindAsync(id);

            if (!string.IsNullOrEmpty(nt.Image))
            {
                _imageService.DeleteImage(nt.Image, "NativeProduction");
            }
            _dbContext.NativeProductions.Remove(nt);
            await _dbContext.SaveChangesAsync();
        }

        public async  Task EditNativeProduction(EditNativeProductionDTO model)
        {
            DAL.Models.NativeProduction.NativeProduction tr = _mapper.Map<DAL.Models.NativeProduction.NativeProduction>(model);

            tr.Image = model.PictureName;
            if (model.FormFile != null)
            {
                _imageService.DeleteImage(tr.Image, "NativeProduction");
                tr.Image = await _imageService.UploadImage(model.FormFile, "NativeProduction");
            }

            _dbContext.NativeProductions.Update(tr);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<NativeProdutionDTO> GetAllNativeProductions()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var trA = _dbContext.NativeProductions.Include(p => p.NativeProductionTranslates);
            var result = _dbContext.NativeProductionTranslates
                .Where(p => p.LanguageCulture == culture).Join(trA, p => p.NativeProductionId, k => k.Id,
                    (p, k) => new NativeProdutionDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        Description = p.Description,
                        CreatedDate = k.CreatedDate,
                        Image = k.Image,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public async Task<EditNativeProductionDTO> GetNativeProductionForEditById(int id)
        {
            var nt = await _dbContext.NativeProductions
             .Include(i => i.NativeProductionTranslates)
             .SingleOrDefaultAsync(k => k.Id == id);
            EditNativeProductionDTO editDTO = _mapper.Map<EditNativeProductionDTO>(nt);
            editDTO.PictureName = nt.Image;
            
            return editDTO;
        }

        public async Task<NativeProdutionDTO> GetNativeProdutionById(int id)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var menu = await _dbContext.NativeProductions.FindAsync(id);
            var translate = await _dbContext.NativeProductionTranslates
                .Where(p => p.LanguageCulture == culture).SingleOrDefaultAsync(p => p.NativeProductionId == menu.Id);
            NativeProdutionDTO result = new NativeProdutionDTO
            {
                Id = menu.Id,                
                Name = translate.Name,
                Description = translate.Description,
                IsPublish = menu.IsPublish,
                Image = menu.Image,
                CreatedDate= menu.CreatedDate,                
            };
            return result;
        }

        public IEnumerable<NativeProdutionDTO> GetSevenPublishNativeProduct()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var trA = _dbContext.NativeProductions.Where(p => p.IsPublish == true)
                .Include(p => p.NativeProductionTranslates).Take(7);
            var result = _dbContext.NativeProductionTranslates
                .Where(p => p.LanguageCulture == culture).Join(trA, p => p.NativeProductionId, k => k.Id,
                    (p, k) => new NativeProdutionDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        Description = p.Description,
                        CreatedDate = k.CreatedDate,
                        Image = k.Image,
                        IsPublish = k.IsPublish
                    }).OrderByDescending(o => o.Id);

            return result;
        }
    }
}
