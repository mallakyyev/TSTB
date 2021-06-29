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
using Microsoft.Extensions.Caching.Memory;
using TSTB.BLL.DTOs.CallBackModelDTO;
using TSTB.BLL.DTOs.NewsModelDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.DAL.Models.CallBacks;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.CallBacks
{
    public class CallBackService : ICallBackService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IMemoryCache _memoryCache;

        public CallBackService(ApplicationDbContext applicationDbContext, IMapper mapper, IImageService imageService, 
            IWebHostEnvironment appEnvironment, IMemoryCache memoryCache)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
            _imageService = imageService;
            _appEnvironment = appEnvironment;
            _memoryCache = memoryCache;
        }
        public IEnumerable<CallBackDTO> GetAllCallBacks()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var callBacks = _dbContext.CallBacks.Include(p=>p.CallBackTranslates);
            var result = _dbContext.CitiesTranslates
                .Where(p => p.LanguageCulture == culture).Join(callBacks, p => p.CityId, k => k.CityId,
                    (p, k) => new CallBackDTO
                    {
                        Id = k.Id,
                        Image = k.Image,
                        Address = k.CallBackTranslates.SingleOrDefault(l=>l.LanguageCulture == culture).Address,
                        Phone = k.Phone,
                        Facks = k.Facks,
                        Email = k.Email,
                        StartTime = k.StartTime,
                        StartWeekDate = k.StartWeekDate,
                        EndTime = k.EndTime,
                        EndWeekDate = k.EndWeekDate,
                        City = p.Name,
                        IsPublish = k.IsPublish
                    });

            return result;
        }

        public IEnumerable<CallBackDTO> GetAllCashCallBacks()
        {
            IEnumerable<CallBackDTO> result = null;
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            if (!_memoryCache.TryGetValue($"callBack{culture}", out result))
            {
                var callBacks = _dbContext.CallBacks.Include(p => p.CallBackTranslates);
                result = _dbContext.CitiesTranslates
                    .Where(p => p.LanguageCulture == culture).Join(callBacks, p => p.CityId, k => k.CityId,
                        (p, k) => new CallBackDTO
                        {
                            Id = k.Id,
                            Image = k.Image,
                            Address = k.CallBackTranslates.SingleOrDefault(l => l.LanguageCulture == culture).Address,
                            Phone = k.Phone,
                            Facks = k.Facks,
                            Email = k.Email,
                            StartTime = k.StartTime,
                            StartWeekDate = k.StartWeekDate,
                            EndTime = k.EndTime,
                            EndWeekDate = k.EndWeekDate,
                            City = p.Name,
                            IsPublish = k.IsPublish
                        });
                if (result != null)
                {
                    _memoryCache.Set($"callBack{culture}", result,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }

            return result;
        }

        public IEnumerable<CallBackDTO> GetAllPublishcallBacks()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var callBacks = _dbContext.CallBacks.Where(k=>k.IsPublish == true).Include(t => t.CallBackTranslates);
            var result = _dbContext.CitiesTranslates
                .Where(p => p.LanguageCulture == culture).Join(callBacks, p => p.CityId, k => k.CityId,
                    (p, k) => new CallBackDTO
                    {
                        Id = k.Id,
                        Image = k.Image,
                        Address = k.CallBackTranslates.SingleOrDefault(l => l.LanguageCulture == culture).Address,
                        Phone = k.Phone,
                        Facks = k.Facks,
                        Email = k.Email,
                        StartTime = k.StartTime,
                        StartWeekDate = k.StartWeekDate,
                        EndTime = k.EndTime,
                        EndWeekDate = k.EndWeekDate,
                        City = p.Name,
                        IsPublish = k.IsPublish
                    }) ;

            return result;
        }

        public async Task CreateCallBack(CreateCallBackDTO modelDTO)
        {
            DAL.Models.CallBacks.CallBack callBack = _mapper.Map<DAL.Models.CallBacks.CallBack>(modelDTO);
            if (modelDTO.FormFile != null)
            {
                string fileName = await _imageService.UploadImage(modelDTO.FormFile, "CallBacks");
                callBack.Image = fileName;
            }
            await _dbContext.CallBacks.AddAsync(callBack);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditCallBack(EditCallBackDTO modelDTO)
        {
            /*
            DAL.Models.CallBacks.CallBack callBack = _mapper.Map < DAL.Models.CallBacks.CallBack> (modelDTO);
            DAL.Models.CallBacks.CallBack prevCallBack = _dbContext.CallBacks.SingleOrDefault(k => k.Id == callBack.Id);
            if (!string.IsNullOrEmpty(prevCallBack.Image))
            {
                _imageService.DeleteImage(prevCallBack.Image, "CallBacks");
            }

            if(modelDTO.FormFile != null)
                callBack.Image = await _imageService.UploadImage(modelDTO.FormFile, "CallBacks");
            */
            DAL.Models.CallBacks.CallBack callBack = _mapper.Map<DAL.Models.CallBacks.CallBack>(modelDTO);
            callBack.Image = modelDTO.PictureName;
            if (modelDTO.FormFile != null)
            {
                _imageService.DeleteImage(callBack.Image, "CallBacks");
                callBack.Image = await _imageService.UploadImage(modelDTO.FormFile, "CallBacks");
            }


            _dbContext.CallBacks.Update(callBack);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveCallBack(int id)
        {
            DAL.Models.CallBacks.CallBack callBack = await _dbContext.CallBacks.FindAsync(id);

            if (!string.IsNullOrEmpty(callBack.Image))
            {
                _imageService.DeleteImage(callBack.Image, "CallBacks");
            }
            _dbContext.CallBacks.Remove(callBack);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAllCallBacks()
        {
            IEnumerable<DAL.Models.CallBacks.CallBack> callBacks = _dbContext.CallBacks;
            string path = _appEnvironment.WebRootPath + "/images/CallBacks/" ;


            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            _dbContext.CallBacks.RemoveRange(callBacks);
            await _dbContext.SaveChangesAsync();
        }

       

        public async Task<CallBackDTO> getCallBackById(int callBackId)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var callBack = await _dbContext.CallBacks.Include(p=>p.CallBackTranslates).SingleOrDefaultAsync(k => k.Id == callBackId);

            var translate = await _dbContext.CitiesTranslates
                .Where(p => p.LanguageCulture == culture).SingleOrDefaultAsync(p => p.CityId == callBack.CityId);
            CallBackDTO result = new CallBackDTO
            {
                Id = callBack.Id,
                Image = callBack.Image,
                Address = callBack.CallBackTranslates.SingleOrDefault(l=>l.LanguageCulture == culture).Address,
                Phone = callBack.Phone,
                Facks = callBack.Facks,
                Email = callBack.Email,
                StartTime = callBack.StartTime,
                StartWeekDate = callBack.StartWeekDate,
                EndTime = callBack.EndTime,
                EndWeekDate = callBack.EndWeekDate,
                City = translate.Name,
                IsPublish = callBack.IsPublish
            };

            return result;
        }

        public async Task<EditCallBackDTO> GetCallBackForEditById(int id)
        {
            var city = await _dbContext.CallBacks.Include(p=>p.CallBackTranslates)
                .Include(p=>p.Cities.CitiesTranslates)
                .SingleOrDefaultAsync(k => k.Id == id);
            EditCallBackDTO editCB = _mapper.Map<EditCallBackDTO>(city);
            editCB.PictureName = city.Image;
            return editCB;
        }
    }
}
