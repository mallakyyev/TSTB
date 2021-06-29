using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.CharityModelDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.BLL.ViewModel;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.Charity
{
    public class CharityService : ICharityService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _appEnvironment;
        public CharityService(ApplicationDbContext applicationDbContext, IMapper mapper, IImageService imageService, IWebHostEnvironment appEnvironment)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
            _imageService = imageService;
            _appEnvironment = appEnvironment;
        }
        public async  Task CreateCharity(CreateCharityDTO modelDTO)
        {
            DAL.Models.Charity.Charity ch = _mapper.Map<DAL.Models.Charity.Charity>(modelDTO);
            if (modelDTO.FormFile != null)
            {
                ch.Image = await _imageService.UploadImage(modelDTO.FormFile, "Charities");
            }
            await _dbContext.Charities.AddAsync(ch);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditCharity(EditCharityDTO modelDTO)
        {
            DAL.Models.Charity.Charity ch = _mapper.Map<DAL.Models.Charity.Charity>(modelDTO);

            ch.Image = modelDTO.Picture;
            if (modelDTO.FormFile != null)
            {
                _imageService.DeleteImage(ch.Image, "Charities");
                ch.Image = await _imageService.UploadImage(modelDTO.FormFile, "Charities");
            }

            _dbContext.Charities.Update(ch);
            await _dbContext.SaveChangesAsync();
        }
        private double CalculateSum(int id)
        {
            double d = _dbContext.PaymentCharity.Where(o => o.CharityId == id).Sum(o => o.Amount);
            return d;
        }

        public ICollection<CharityDTO> GetAllCharities()
        {
            ICollection<CharityDTO> result = _mapper.Map<ICollection<CharityDTO>>(_dbContext.Charities);
            foreach(CharityDTO t in result)
            {
                t.Collected = CalculateSum(t.Id)*1.0/100;
            }
            return result;
        }

        public ICollection<CharityDTO> GetAllPublishCharities()
        {
            return _mapper.Map<ICollection<CharityDTO>>(_dbContext.Charities.Where(o => o.IsPublish == true));
        }

        public async Task<CharityDTO> GetCharityById(int id)
        {
            return _mapper.Map<CharityDTO>(await _dbContext.Charities.FindAsync(id));
        }

        public async Task<EditCharityDTO> GetCharityForEditById(int id)
        {
            var ch = await _dbContext.Charities.FindAsync(id);
            EditCharityDTO edCh = _mapper.Map<EditCharityDTO>(ch);
            edCh.Picture = ch.Image;
            return edCh;

        }

        public async Task RemoveCharityById(int id)
        {
            DAL.Models.Charity.Charity ch= await _dbContext.Charities.FindAsync(id);

            if (!string.IsNullOrEmpty(ch.Image))
            {
                _imageService.DeleteImage(ch.Image, "Charities");
            }
            _dbContext.Charities.Remove(ch);
            await _dbContext.SaveChangesAsync();
        }


    }
}
