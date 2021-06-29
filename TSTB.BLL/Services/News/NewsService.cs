﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using TSTB.BLL.DTOs.MenuModelDTO;
using TSTB.BLL.DTOs.NewsModelDTO;
using TSTB.Web.Data;
using TSTB.BLL.Services.ImageService;
using Microsoft.EntityFrameworkCore;
using TSTB.DAL.Models.News;
using TSTB.BLL.ViewModel;

namespace TSTB.BLL.Services.News
{
    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _appEnvironment;
        public NewsService(ApplicationDbContext applicationDbContext, IMapper mapper, IImageService imageService,IWebHostEnvironment appEnvironment)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
            _imageService = imageService;
            _appEnvironment = appEnvironment;
        }
        public IEnumerable<NewsDTO> GetAllNews()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var news = _dbContext.News;
            var result = _dbContext.NewsTranslates
                .Where(p => p.LanguageCulture == culture).Join(news, p => p.NewsId, k => k.Id,
                    (p, k) => new NewsDTO
                    {
                        Id = k.Id,
                        NewsCategoryID = k.NewsCategoryID,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish,
                        Image = k.Image,
                        DatePublished = k.DatePublished,
                        NewsCategoryName = _dbContext.NewsCategoryTranslates.Where(t => t.LanguageCulture == culture).FirstOrDefault(t => t.NewsCategoryId == k.NewsCategoryID).Name,
                    });

            return result;
        }

        public IEnumerable<NewsDTO> GetAllPublishNews()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var news = _dbContext.News.Where(k=>k.IsPublish == true);
            var result = _dbContext.NewsTranslates
                .Where(p => p.LanguageCulture == culture).Join(news, p => p.NewsId, k => k.Id,
                    (p, k) => new NewsDTO
                    {
                        Id = k.Id,
                        NewsCategoryID = k.NewsCategoryID,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish,
                        Image = k.Image,
                        DatePublished = k.DatePublished
                    }).OrderByDescending(o => o.Id);

            return result;
        }

        public async Task CreateNews(CreateNewsDTO modelDTO)
        {
            DAL.Models.News.News news = _mapper.Map<DAL.Models.News.News>(modelDTO);
            if (modelDTO.FormFile != null)
            {
                news.Image = await _imageService.UploadImage(modelDTO.FormFile,"News");
            }
            await _dbContext.News.AddAsync(news);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditNews(EditNewsDTO modelDTO)
        {
            DAL.Models.News.News news = _mapper.Map<DAL.Models.News.News>(modelDTO);

            news.Image = modelDTO.PictureName;
            if (modelDTO.FormFile != null)
            {
                _imageService.DeleteImage(news.Image, "News");
                news.Image = await _imageService.UploadImage(modelDTO.FormFile, "News");
            }
            
            _dbContext.News.Update(news);
            await _dbContext.SaveChangesAsync();
            /*
            DAL.Models.News.News news = _mapper.Map<DAL.Models.News.News>(modelDTO);
            DAL.Models.News.News prevNews = _dbContext.News.SingleOrDefault(k => k.Id == news.Id);
            if (!string.IsNullOrEmpty(prevNews.Image))
            {
                 _imageService.DeleteImage(prevNews.Image, $"News/{prevNews.NewsCategoryID}");
            }
            if (modelDTO.FormFile != null)
            { 
                news.Image = await _imageService.UploadImage(modelDTO.FormFile, $"News/{modelDTO.NewsCategoryID}"); 
            }
            _dbContext.News.Update(news);
            await _dbContext.SaveChangesAsync();*/
        }

        public async Task RemoveNews(int id)
        {
            DAL.Models.News.News news = await _dbContext.News.FindAsync(id);
            
            if (!string.IsNullOrEmpty(news.Image))
            {
                _imageService.DeleteImage(news.Image, $"News/{news.NewsCategoryID}");
            }
            _dbContext.News.Remove(news);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAllNews(int categoryId)
        {
            IEnumerable<DAL.Models.News.News> newsById = _dbContext.News.Where(k => k.NewsCategoryID == categoryId);
            string path = _appEnvironment.WebRootPath + "/images/News/" + categoryId;


            if (Directory.Exists(path))
            {
                Directory.Delete(path,true);
            }
            _dbContext.News.RemoveRange(newsById);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<NewsDTO> GetNewsByCategory(int categoryID)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var news = _dbContext.News.Where(k => k.NewsCategoryID == categoryID).OrderByDescending(o => o.Id);
            var result = _dbContext.NewsTranslates
                .Where(p => p.LanguageCulture == culture).Join(news, p => p.NewsId, k => k.Id,
                    (p, k) => new NewsDTO
                    {
                        Id = k.Id,
                        NewsCategoryID = k.NewsCategoryID,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish,
                        Image = k.Image,
                        DatePublished = k.DatePublished
                    }).OrderByDescending(o => o.Id);

            return result;
        }

        public IEnumerable<NewsDTO> SortNewsByDate(bool @ascending = false)
        {
            IEnumerable<DAL.Models.News.News> news;
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (ascending)
            {
                 news = _dbContext.News.OrderBy(k => k.DatePublished);
            }
            else
            {
                 news = _dbContext.News.OrderByDescending(k => k.DatePublished);
            }
            var result = _dbContext.NewsTranslates
                .Where(p => p.LanguageCulture == culture).Join(news, p => p.NewsId, k => k.Id,
                    (p, k) => new NewsDTO
                    {
                        Id = k.Id,
                        NewsCategoryID = k.NewsCategoryID,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish,
                        Image = k.Image,
                        DatePublished = k.DatePublished
                    });

            return result;
        }

        public IEnumerable<NewsDTO> SortNewsByDate(int categoryId, bool @ascending = false)
        {
            IEnumerable<DAL.Models.News.News> news;
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (ascending)
            {
                news = _dbContext.News.Where(k=>k.NewsCategoryID == categoryId).OrderBy(k => k.DatePublished);
            }
            else
            {
                news = _dbContext.News.Where(k => k.NewsCategoryID == categoryId).OrderByDescending(k => k.DatePublished);
            }
            var result = _dbContext.NewsTranslates
                .Where(p => p.LanguageCulture == culture).Join(news, p => p.NewsId, k => k.Id,
                    (p, k) => new NewsDTO
                    {
                        Id = k.Id,
                        NewsCategoryID = k.NewsCategoryID,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish,
                        Image = k.Image,
                        DatePublished = k.DatePublished
                    });

            return result;
        }

        public IEnumerable<NewsDTO> GetNewsByDate(DateTime date)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var news = _dbContext.News.Where(k => k.DatePublished == date).OrderByDescending(o => o.Id);
            var result = _dbContext.NewsTranslates
                .Where(p => p.LanguageCulture == culture).Join(news, p => p.NewsId, k => k.Id,
                    (p, k) => new NewsDTO
                    {
                        Id = k.Id,
                        NewsCategoryID = k.NewsCategoryID,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish,
                        Image = k.Image,
                        DatePublished = k.DatePublished
                    }).OrderByDescending(o => o.Id);

            return result;
        }

        public IEnumerable<NewsDTO> GetNewsByDateAndCategory(DateTime date, int categoryId)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var news = _dbContext.News.Where(k => k.DatePublished == date && k.NewsCategoryID == categoryId).OrderByDescending(o => o.Id);
            var result = _dbContext.NewsTranslates
                .Where(p => p.LanguageCulture == culture).Join(news, p => p.NewsId, k => k.Id,
                    (p, k) => new NewsDTO
                    {
                        Id = k.Id,
                        NewsCategoryID = k.NewsCategoryID,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish,
                        Image = k.Image,
                        DatePublished = k.DatePublished
                    }).OrderByDescending(o => o.Id);

            return result;
        }

        public async Task<NewsDTO> GetNewsByIdAsync(int id)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var menu = await _dbContext.News.FindAsync(id);
            var translate = await _dbContext.NewsTranslates
                .Where(p => p.LanguageCulture == culture).SingleOrDefaultAsync(p => p.NewsId == menu.Id);
            NewsDTO result = new NewsDTO
            {
                Id = menu.Id,
                NewsCategoryID = menu.NewsCategoryID,
                Name = translate.Name,
                Description = translate.Description,
                IsPublish = menu.IsPublish,
                Image = menu.Image,
                DatePublished = menu.DatePublished

            };
            return result;
        }

        public async Task<EditNewsDTO> GetNewsForEditById(int id)
        {
            var news = await _dbContext.News
             .Include(i => i.NewsTranslates)
             .SingleOrDefaultAsync(k => k.Id == id);
            EditNewsDTO editNewsDTO = _mapper.Map<EditNewsDTO>(news);
            editNewsDTO.PictureName = news.Image;
            editNewsDTO.DeleteImage = false;
            return editNewsDTO;
        }

        public  IEnumerable<SearchResultModel> SearchByNameAndDesc(string searchText)
        {
            List<SearchResultModel> result = new List<SearchResultModel>();
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (searchText != null) { 
            string[] texts = searchText.Split(' ');
                List<NewsTranslate> newsTranslate = new List<NewsTranslate>(_dbContext.NewsTranslates.Include(o => o.News).AsQueryable());
                foreach (string t in texts)
                {
                    var temp = newsTranslate.Where(o => o.Name.ToLower().Contains(t.ToLower()) || o.Description.ToLower().Contains(t.ToLower()) );
                    
                    foreach (NewsTranslate n in temp)
                    {                        
                        if (n.News.IsPublish)
                        {
                            SearchResultModel title = new SearchResultModel();

                            title.Id = Guid.NewGuid().ToString();
                            title.ResultType = DAL.Models.Enums.SearchResultType.News;
                            title.SearchResultId = n.NewsId;
                            title.SearchResultTextinTitle = newsTranslate.Where(o => o.LanguageCulture == culture).SingleOrDefault(o => o.NewsId == n.NewsId).Name;
                            title.SearchResultTextinDescription = newsTranslate.Where(o => o.LanguageCulture == culture).SingleOrDefault(o => o.NewsId == n.NewsId).Description;
                            title.Count = 1;
                            
                            var c = result.SingleOrDefault(o => o.SearchResultId == title.SearchResultId);
                            if (c != null)
                            {
                                c.Count += 1;
                            }else
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

        public IEnumerable<NewsDTO> GetFourPublishNews()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var news = _dbContext.News.Where(k => k.IsPublish == true).OrderByDescending(o => o.Id).Take(4);
            var result = _dbContext.NewsTranslates
                .Where(p => p.LanguageCulture == culture).Join(news, p => p.NewsId, k => k.Id,
                    (p, k) => new NewsDTO
                    {
                        Id = k.Id,
                        NewsCategoryID = k.NewsCategoryID,
                        Name = p.Name,
                        Description = p.Description,
                        IsPublish = k.IsPublish,
                        Image = k.Image,
                        DatePublished = k.DatePublished
                    }).OrderByDescending(o => o.Id);

            return result;
        }
    }
}
