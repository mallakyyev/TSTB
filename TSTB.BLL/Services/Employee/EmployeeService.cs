using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.BillingModelDTO;
using TSTB.BLL.Services.ImageService;
using TSTB.BLL.ViewModel;
using TSTB.DAL.Models.Billing;
using TSTB.Web.Data;


namespace TSTB.BLL.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly UserManager<TSTB.DAL.Models.User.ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _appEnvironment;
        public EmployeeService(ApplicationDbContext dbContext, IMapper mapper, UserManager<TSTB.DAL.Models.User.ApplicationUser> userManager, IWebHostEnvironment appEnvironment, IImageService imageService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
            _appEnvironment = appEnvironment;
            _imageService = imageService;
        }
        public async Task CreateDeclaration(CreateDeclarationDTO modelDTO, string userId)
        {
            Declaration dec = _mapper.Map<Declaration>(modelDTO);
            List<DeclarationImage> decImages = new List<DeclarationImage>();
            if (modelDTO.FormFiles != null)
            {
                foreach(IFormFile decFile in modelDTO.FormFiles)
                {
                    string fName = await _imageService.UploadImage(decFile, "Declarations");
                    decImages.Add(new DeclarationImage()
                    {
                        DeclarationId = dec.Id,
                        Name = fName
                    });
                }
            }
            dec.DeclarationImages = decImages;

            dec.ApplicationUserId = userId;
            dec.DateCreateDeclaration = DateTime.Now;
            dec.StatusDeclaration = DAL.Models.Enums.StatusDeclaration.Pending;
            await _dbContext.Declarations.AddAsync(dec);
            await _dbContext.SaveChangesAsync();                
        }

        public async Task CreatePayment(CreatePaymentDTO modelDTO)
        {
            var pay = _mapper.Map<Payment>(modelDTO);
            await _dbContext.Payments.AddAsync(pay);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDeclarationById(int id)
        {
            var dec = await _dbContext.Declarations.FindAsync(id);
            if(dec != null)
            {
                await DeleteAllDeclarationImages(id);
                _dbContext.Declarations.Remove(dec);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task DeleteDeclartionFiles(int id)
        {
            var decFiles =  _dbContext.DeclarationImages.Where(p => p.DeclarationId == id);
             _dbContext.DeclarationImages.RemoveRange(decFiles);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDeclartionFilesById(int id)
        {
            var decImage = await _dbContext.DeclarationImages.FindAsync(id);
            if(decImage != null)
            {
                _imageService.DeleteImage(decImage.Name, "Declarations");
                _dbContext.DeclarationImages.Remove(decImage);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeletePaymentById(int id)
        {
            var pay = await _dbContext.Payments.FindAsync(id);
            if (pay != null)
            {
               
                _dbContext.Payments.Remove(pay);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task EditDeclaration(EditDeclarationDTO modelDTO)
        {
            Declaration dec = _mapper.Map<Declaration>(modelDTO);

            //Deleting previous image 
            
            List<DeclarationImage> decImages = new List<DeclarationImage>();

            if (modelDTO.FormFiles != null)
            {                
                foreach (IFormFile file in modelDTO.FormFiles)
                {
                    string fileName = await _imageService.UploadImage(file, "Declarations");
                    decImages.Add(new DeclarationImage()
                    {
                        DeclarationId = modelDTO.Id,
                        Name = fileName
                    });
                }
                dec.DeclarationImages = decImages;
            }
            _dbContext.Declarations.Update(dec);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> EditDeclarationAcc(EditDeclatarionAccountant modelDTO)
        {
            Declaration dec = _mapper.Map<Declaration>(modelDTO);
            var payForDec = _dbContext.Payments.SingleOrDefault(p => p.DeclarationId == dec.Id);
            if (modelDTO.StatusDeclaration == DAL.Models.Enums.StatusDeclaration.Confirmed)
            {               
                if (payForDec == null)
                {
                    CreatePaymentDTO payment = new CreatePaymentDTO()
                    {
                        ApplicationUserId = dec.ApplicationUserId,
                        CurrencyCode = 934,
                        Language = "ru",
                        PageView = "Desktop",
                        OrderNumber = Guid.NewGuid().ToString().Replace("-", ""),
                        Amount = modelDTO.Amount,
                        DeclarationId = dec.Id,
                        PaymentCreatedDate = DateTime.Now,
                        StatusPayment = DAL.Models.Enums.StatusPayment.NotPaid
                    };
                    Payment p = _mapper.Map<Payment>(payment);
                    await _dbContext.Payments.AddAsync(p);
                    await _dbContext.SaveChangesAsync();
                    dec.PaymentId = p.Id;                    
                    _dbContext.Declarations.Update(dec);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    if (payForDec.StatusPayment != DAL.Models.Enums.StatusPayment.CompleteAuthorizationOrderAmount)
                    {
                        payForDec.Amount = modelDTO.Amount;
                        _dbContext.Payments.Update(payForDec);
                        _dbContext.Declarations.Update(dec);
                        await _dbContext.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (payForDec != null && payForDec.StatusPayment == DAL.Models.Enums.StatusPayment.CompleteAuthorizationOrderAmount)
                    return false;
                else if(payForDec != null)
                {
                    _dbContext.Payments.Remove(payForDec);
                    _dbContext.Declarations.Update(dec);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else 
                { 
                    _dbContext.Declarations.Update(dec);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }


        }

        public async Task EditPayment(EditPaymentDTO modelDTO)
        {
            Payment pay = _mapper.Map<Payment>(modelDTO);
            _dbContext.Payments.Update(pay);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Payment> EditPayment(Payment modelDTO)
        {           
            _dbContext.Payments.Update(modelDTO);
            await _dbContext.SaveChangesAsync();
            return modelDTO;
        }

        public ICollection<DeclarationAccount> getAllDeclarationByStatus()
        {
            var decForAccountant = _mapper.Map<ICollection<DeclarationAccount>>(_dbContext.Declarations);          
            if(decForAccountant != null) {
                foreach (DeclarationAccount ac in decForAccountant) {
                    ac.DateCreateShort = ac.DateCreateDeclaration.ToShortDateString();
                    var Amount = _dbContext.Payments.SingleOrDefault(p => p.DeclarationId == ac.Id);
                    if(Amount != null)
                    {
                        ac.Amount = Amount.Amount;
                    }
                   }
            }
            return decForAccountant;            
        }

        public  ICollection<DeclarationDTO> getAllDeclarationByUserId(string id)
        {
            ICollection<DeclarationDTO> decById =  _mapper.Map < ICollection < DeclarationDTO >>(_dbContext.Declarations.Where(d => d.ApplicationUserId == id));
            foreach(DeclarationDTO d in decById)
            {
                d.Date = d.DateCreateDeclaration.ToShortDateString();
            }
            return decById;
        }

        public IEnumerable<DeclarationImage> GetAllDeclarationImageByDecId(int id)
        {
            return _dbContext.DeclarationImages.Where(p => p.DeclarationId == id).AsQueryable();

        }

        public ICollection<PaymentDTO> getAllPaymentByUserId(string id)
        {
            ICollection<PaymentDTO> payById = _mapper.Map<ICollection<PaymentDTO>>(_dbContext.Payments.Where(d => d.ApplicationUserId == id));
            foreach(PaymentDTO p in payById)
            {
                var year = _dbContext.Declarations.SingleOrDefault(o => o.PaymentId == p.Id);
                if (year != null)
                    p.YearOfPayment = year.YearDeclaration;
            }
            //foreach (PaymentDTO p in payById)
            //{
             //   if(p.DeclarationId != null)
              //  {
                 //   p.YearOfPayment = ( _dbContext.Declarations.FirstOrDefault(o => o.Id == p.DeclarationId)).YearDeclaration ;
              //  }
           // }
                return payById;
        }

        public  async Task<ICollection<TransactionViewModel>> getAllTransactions()
        {
            var payments = _dbContext.Payments
                .Include(i => i.ApplicationUser).ThenInclude(i => i.Organization)
                .Include(i => i.Declaration).AsQueryable();
          
            List<TransactionViewModel> result = new List<TransactionViewModel>();
            foreach(Payment p in payments)
            {
                TransactionViewModel temp = new TransactionViewModel();
                
                temp.FirstName = p.ApplicationUser.FirstName;
                temp.LastName = p.ApplicationUser.LastName;
                temp.Amount = p.Amount;
                temp.StatusPayment = p.StatusPayment;
             
                temp.TaxCode = p.ApplicationUser.Organization.TaxCode;
                temp.NameOrganization = p.ApplicationUser.Organization.NameOrganization;
           
                temp.Year = p.Declaration.YearDeclaration;
                result.Add(temp);
            }
            return result;

        }

        public async Task<EditDeclarationDTO> GetDeclarationForEditById(int id)
        {
            var dec = await _dbContext.Declarations
                .Include(i => i.DeclarationImages)
                .SingleOrDefaultAsync(k => k.Id == id);
            EditDeclarationDTO editDecDTO = _mapper.Map<EditDeclarationDTO>(dec);
            editDecDTO.OldYear = editDecDTO.YearDeclaration;
            return editDecDTO;
        }

        public async Task<Payment> GetPaymentById(int id)
        {

            var p = await _dbContext.Payments.FindAsync(id);
            return p;
        }

        public async Task<Payment> GetPaymentByOrderNumber(string orderNumber)
        {
            var payment = await _dbContext.Payments.SingleOrDefaultAsync(o => o.OrderNumber == orderNumber);
            return payment;
        }

        public async Task<EditPaymentDTO> GetPaymentForEditById(int id)
        {
            var pay = await _dbContext.Payments.SingleOrDefaultAsync(k => k.Id == id);
            EditPaymentDTO editPayDTO = _mapper.Map<EditPaymentDTO>(pay);
            return editPayDTO;
        }

        private async Task DeleteAllDeclarationImages(int id)
        {
            var images = _dbContext.DeclarationImages.Where(p => p.DeclarationId == id);

            foreach (DeclarationImage img in images)
            {
                _imageService.DeleteImage(img.Name, "Declarations");
            }
            _dbContext.DeclarationImages.RemoveRange(images);
            await _dbContext.SaveChangesAsync();
        }
    }
}
