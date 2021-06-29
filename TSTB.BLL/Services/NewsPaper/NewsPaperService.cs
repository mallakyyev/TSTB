using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using TSTB.BLL.DTOs.NewsPaperModelDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.BLL.ViewModel;
using TSTB.DAL.Models.NewsPapers;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.NewsPaper
{
    public class NewsPaperService : INewsPaperService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _appEnvironment;
        public NewsPaperService(ApplicationDbContext applicationDbContext, IMapper mapper, IImageService imageService, IWebHostEnvironment appEnvironment)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
            _imageService = imageService;
            _appEnvironment = appEnvironment;
        }

        public async Task CreateNewsPaper(CreateNewsPaperDTO modelDTO)
        {
            //Adding NewsPaper to the DB 
            DAL.Models.NewsPapers.NewsPaper newsP  = _mapper.Map<DAL.Models.NewsPapers.NewsPaper>(modelDTO);
            await _dbContext.NewsPaper.AddAsync(newsP);
            await _dbContext.SaveChangesAsync();            
            //Adding NewsPaperData to the DB          
            //Adding NewsPaperFiles to the DB
           
        }

        public async Task CreateNewsPaperData(CreateNewsPaperDataDTO modelDTO)
        {
            DAL.Models.NewsPapers.NewsPaperData newsD = _mapper.Map<DAL.Models.NewsPapers.NewsPaperData>(modelDTO);
            
            if (modelDTO.FormFile != null)
            {
                newsD.Image = await _imageService.UploadImage(modelDTO.FormFile, "NewsPapers/NewsPaperDataImage");
            }

            List<NewsPaperFiles> newsPaperFiles = new List<NewsPaperFiles>();
            if (modelDTO.FormFiles != null)
            {
                foreach (IFormFile newsFile in modelDTO.FormFiles)
                {
                    string fName = await _imageService.UploadImage(newsFile, "NewsPapers/NewsPaperFiles");
                    newsPaperFiles.Add(new NewsPaperFiles()
                    {
                        NewsPaperDataId = newsD.Id,
                        Image = fName                    
                    });               
                }
            }
            newsD.NewsPaperFiles = newsPaperFiles;
            await _dbContext.NewsPaperData.AddAsync(newsD);
            await _dbContext.SaveChangesAsync();
        }
       
        public async Task EditNewsPaper(EditNewsPaperDTO modelDTO)
        {
            //Editting NewsPaper to the DB 
            DAL.Models.NewsPapers.NewsPaper newsP = _mapper.Map<DAL.Models.NewsPapers.NewsPaper>(modelDTO);
             _dbContext.NewsPaper.Update(newsP);
            await _dbContext.SaveChangesAsync();                   
        }

        private  async Task  DeleteAllFiles(int id)
        {
            var images =  _dbContext.NewsPaperFiles.Where(p => p.NewsPaperDataId == id);

            foreach(NewsPaperFiles img in images)
            {
                _imageService.DeleteImage(img.Image, "NewsPapers/NewsPaperFiles");
            }
            _dbContext.NewsPaperFiles.RemoveRange(images);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditNewsPaperData(EditNewsPaperDataDTO modelDTO)
        {
            //Editting NewsPaperData to the DB
            DAL.Models.NewsPapers.NewsPaperData newsD = _mapper.Map<DAL.Models.NewsPapers.NewsPaperData>(modelDTO);
            //Deleting previous image 
            newsD.Image = modelDTO.Image;
            if (modelDTO.FormFile != null)
            {
                _imageService.DeleteImage(newsD.Image, "NewsPapers/NewsPaperDataImage");
                newsD.Image = await _imageService.UploadImage(modelDTO.FormFile, "NewsPapers/NewsPaperDataImage");
            }


            List<NewsPaperFiles> newsPaperFiles = new List<NewsPaperFiles>();

            if (modelDTO.FormFiles != null )
                {
                    await DeleteAllFiles(modelDTO.Id);
                    foreach(IFormFile file in modelDTO.FormFiles)
                        {
                            string fileName = await _imageService.UploadImage(file, "NewsPapers/NewsPaperFiles");
                            newsPaperFiles.Add(new NewsPaperFiles()
                            {
                                NewsPaperDataId = modelDTO.Id,
                                Image = fileName
                            });
                        }
                newsD.NewsPaperFiles = newsPaperFiles;
                }

                
            _dbContext.NewsPaperData.Update(newsD);
            await _dbContext.SaveChangesAsync();
        }

      

        public IEnumerable<NewsPaperDTO> GetAllNewsPapers()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var newsP = _dbContext.NewsPaper;
            var result = _dbContext.NewsPapersTranslates
                .Where(p => p.LanguageCulture == culture).Join(newsP, p => p.NewsPaperId, k => k.Id,
                    (p, k) => new NewsPaperDTO
                    {
                        Id = k.Id,                      
                        Name = p.Name,                       
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public IEnumerable<NewsPaperDTO> GetAllPublishNewsPapers()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var newsP = _dbContext.NewsPaper.Where(k=>k.IsPublish == true);
            var result = _dbContext.NewsPapersTranslates
                .Where(p => p.LanguageCulture == culture).Join(newsP, p => p.NewsPaperId, k => k.Id,
                    (p, k) => new NewsPaperDTO
                    {
                        Id = k.Id,
                        Name = p.Name,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public async Task<NewsPaperDTO> GetNewsPaperByIdAsync(int newsId)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var newsP = await _dbContext.NewsPaper.FindAsync(newsId);
            var translate = await _dbContext.NewsPapersTranslates
                .Where(p => p.LanguageCulture == culture).SingleOrDefaultAsync(p => p.NewsPaperId == newsP.Id);
            NewsPaperDTO result = new NewsPaperDTO
            {
                Id = newsP.Id,
                Name = translate.Name,               
                IsPublish = newsP.IsPublish,

            };
            return result;
        }

        public async Task<NewsPaperData> GetNewsPaperDataByIDAsync(int newsDataId)
        {
            return await _dbContext.NewsPaperData.FindAsync(newsDataId);
        }
        

        public NewsPaperData GetNewsPaperDataAndFiles(int id)
        {
            return _dbContext.NewsPaperData.Include(o => o.NewsPaperFiles).Include(p=>p.NewsPaper).ThenInclude(p=>p.NewsPapersTranslates).SingleOrDefault(o => o.Id == id);
        }

        public async Task<EditNewsPaperDataDTO> GetNewsPaperDataForEditById(int id)
        {
            var pr = await _dbContext.NewsPaperData
              .Include(i => i.NewsPaperFiles)
              .SingleOrDefaultAsync(k => k.Id == id);
            EditNewsPaperDataDTO editNPDTO = _mapper.Map<EditNewsPaperDataDTO>(pr);
            editNPDTO.Image = pr.Image;
            return editNPDTO;
        }

        public  IEnumerable<NewsPaperFiles> GetNewsPaperFileById(int newsFileId)
        {           
            return   _dbContext.NewsPaperFiles.Where(k=>k.NewsPaperDataId == newsFileId);
        }

        public async Task<EditNewsPaperDTO> GetNewsPaperForEditById(int id)
        {
            var pr = await _dbContext.NewsPaper
               .Include(i => i.NewsPapersTranslates)
               .SingleOrDefaultAsync(k => k.Id == id);
            EditNewsPaperDTO editNPDTO = _mapper.Map<EditNewsPaperDTO>(pr);
            return editNPDTO;

        }

        public async Task RemoveAllNewsPapers()
        {
            IEnumerable<DAL.Models.NewsPapers.NewsPaper> newsP = _dbContext.NewsPaper;          
            _dbContext.NewsPaper.RemoveRange(newsP);
            string path = _appEnvironment.WebRootPath + "/NewsPapers/";

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
           
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task RemoveNewsPaperById(int id)
        {
            DAL.Models.NewsPapers.NewsPaper  newsP = await _dbContext.NewsPaper.FindAsync(id);
         
          
            //News Paper Data and Files will be deleted from DB by Cascase option
            _dbContext.NewsPaper.Remove(newsP);
            await _dbContext.SaveChangesAsync();

        }

        public IEnumerable<NewsPaperDataDTO> GetAllPublishNewsPaperData()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var newsP = _dbContext.NewsPaperData.Where(k => k.IsPublish == true);
            var result = _dbContext.NewsPapersTranslates.Where(p => p.LanguageCulture == culture)
                .Join(newsP, p => p.NewsPaperId, k => k.NewsPaperId,
                    (p, k) => new NewsPaperDataDTO
                    {
                        Id = k.Id,
                        NewsPaperName = p.Name,
                        IsPublish = k.IsPublish,
                        DataOfPublish = k.DataOfPublish,
                        Image = k.Image,
                        
                    });

            return result.OrderByDescending(o => o.Id);
        }

        public IEnumerable<NewsPaperDataDTO> GetAllNewsPaperData()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var newsP = _dbContext.NewsPaperData;
            var result = _dbContext.NewsPapersTranslates.Where(p=>p.LanguageCulture == culture)
                .Join(newsP, p => p.NewsPaperId, k => k.NewsPaperId,
                    (p, k) => new NewsPaperDataDTO
                    {
                        Id = k.Id,
                        NewsPaperName = p.Name,
                        IsPublish = k.IsPublish,
                        DataOfPublish = k.DataOfPublish,
                        Image = k.Image,

                    });

            return result;
        }

        public async Task RemoveNewsPaperData(int id)
        {
            NewsPaperData newsD = await GetNewsPaperDataByIDAsync(id);
            

            if (!string.IsNullOrEmpty(newsD.Image))
            {
                _imageService.DeleteImage(newsD.Image, "NewsPapers/NewsPaperDataImage");
            }

            IEnumerable<NewsPaperFiles> newsF = _dbContext.NewsPaperFiles.Where(p => p.NewsPaperDataId == id);

            foreach (NewsPaperFiles nF in newsF)
            {
                if (!string.IsNullOrEmpty(nF.Image))
                {
                    _imageService.DeleteImage(nF.Image, "NewsPapers/NewsPaperFiles");
                }
            }

            //News Paper Data and Files will be deleted from DB by Cascase option
            _dbContext.NewsPaperData.Remove(newsD);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveNewsPaperFileById(int id)
        {
            NewsPaperFiles newsF = await _dbContext.NewsPaperFiles.FindAsync(id);
            if (newsF != null)
            {
                _imageService.DeleteImage(newsF.Image, "NewsPapers/NewsPaperFiles");
                _dbContext.NewsPaperFiles.Remove(newsF);
                await _dbContext.SaveChangesAsync();
            }


        }

        public IEnumerable<SearchResultModel> SearchByNameAndDesc(string searchText)
        {
            List<SearchResultModel> result = new List<SearchResultModel>();
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            List<NewsPapersTranslate> newsPapersTranslates = new List<NewsPapersTranslate>(_dbContext.NewsPapersTranslates.Include(o => o.NewsPaper));
            string[] texts = searchText.Split(' ');
            foreach (string t in texts)
            {
                var temp = newsPapersTranslates.Where(o => o.Name.Contains(t) );
                foreach (NewsPapersTranslate n in temp)
                {
                    if (n.NewsPaper.IsPublish)
                    {
                        SearchResultModel title = new SearchResultModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            ResultType = DAL.Models.Enums.SearchResultType.NewsPaper,
                            SearchResultId = n.NewsPaperId,
                            SearchResultTextinTitle = newsPapersTranslates.FirstOrDefault(o => o.LanguageCulture == culture && o.NewsPaperId == n.NewsPaperId).Name,
                            Count = 1
                        };
                        var c = result.SingleOrDefault(o => o.SearchResultId == title.SearchResultId);
                        if(c!= null)
                        {
                            c.Count += 1;                            
                        }else { 
                            result.Add(title);
                        }
                    }
                }

            }
            return result;
        }

        public IEnumerable<NewsPaperDataDTO> GetNewsPaperDataByNewsPaperId(int id)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var newsP = _dbContext.NewsPaperData.Where(o => o.NewsPaperId == id && o.IsPublish == true);
            var result = _dbContext.NewsPapersTranslates.Where(p => p.LanguageCulture == culture)
                .Join(newsP, p => p.NewsPaperId, k => k.NewsPaperId,
                    (p, k) => new NewsPaperDataDTO
                    {
                        Id = k.Id,
                        NewsPaperName = p.Name,
                        IsPublish = k.IsPublish,
                        DataOfPublish = k.DataOfPublish,
                        Image = k.Image,

                    });

            return result;
        }
    }
}
