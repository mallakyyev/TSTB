using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.CharityModelDTO;
using TSTB.DAL.Models.Charity;
using TSTB.DAL.Models.Enums;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.Charity
{
    public class PaymentCharityService : IPaymentCharityService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public PaymentCharityService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        } 
        public async Task<int> CreatePaymentCharity(CreatePaymentCharityDTO model)
        {
            var pr = _mapper.Map<TSTB.DAL.Models.Charity.PaymentCharity>(model);
            await  _dbContext.PaymentCharity.AddAsync(pr);
            await _dbContext.SaveChangesAsync();
            return pr.Id;


        }

        public async Task DeleteByPaymentNumber(string id)
        {
            var pn = await _dbContext.PaymentCharity.SingleOrDefaultAsync(o => o.PaymentNumber == id);
            _dbContext.PaymentCharity.Remove(pn);
            _dbContext.SaveChanges();
        }

        public async Task EditCharityService(EditPaymentCharityDTO model)
        {
            var pr = _mapper.Map<TSTB.DAL.Models.Charity.PaymentCharity>(model);
            if(pr!= null)
                _dbContext.PaymentCharity.Update(pr);
            await _dbContext.SaveChangesAsync();

        }

        public IEnumerable<PaymentCharity> GetAllCharityByUser(string userId)
        {
            var res = _dbContext.PaymentCharity.Where(o =>  o.ApplicationtUserId == userId);
            foreach (PaymentCharity p in res)
            {
                p.Amount = p.Amount * 1.0 / 100;
            }
            return res;
        }

        public ICollection<EditPaymentCharityDTO> GetAllPaymentCharity()
        {
            return _mapper.Map<ICollection<EditPaymentCharityDTO>>(_dbContext.PaymentCharity);
        }

        public async Task<EditPaymentCharityDTO> GetCharityById(int id)
        {
            var pr = await _dbContext.PaymentCharity.FindAsync(id);
            return _mapper.Map<EditPaymentCharityDTO>(pr); 
        }

        public IEnumerable<PaymentCharity> GetCharityDerails(int charId, string userId)
        {
            var res = _dbContext.PaymentCharity.Where(o => o.CharityId == charId && o.ApplicationtUserId == userId);
            foreach(PaymentCharity p in res)
            {
                p.Amount = p.Amount * 1.0 / 100;
            }
            return res;
        }

        public async Task GetPaymentByPaymentNumberforEdit(string id, string bid, StatusPayment st)
        {
            var ed = await _dbContext.PaymentCharity.SingleOrDefaultAsync(o => o.PaymentNumber == id);
            ed.BankPaymentId = bid;
            ed.PaymentStatus = st;
            _dbContext.PaymentCharity.Update(ed);
            _dbContext.SaveChanges();
        }

        public async Task RemovePaymentCharity(int id)
        {
            var pr = await _dbContext.PaymentCharity.FindAsync(id);
            if (pr != null)
                _dbContext.PaymentCharity.Remove(pr);
            await _dbContext.SaveChangesAsync();
        }
    }
}
