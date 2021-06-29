using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.Tariff
{
    public class TariffService : ITariffService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
       
        public TariffService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateTariff(DAL.Models.Billing.Tariff t)
        {
            await _dbContext.AddAsync(t);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTariffById(int id)
        {
            var tar = await _dbContext.Tariffs.FindAsync(id);
            if (tar != null)
            {
                _dbContext.Tariffs.Remove(tar);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditTariff(TSTB.DAL.Models.Billing.Tariff value)
        {
           
            if(value!= null) {
                _dbContext.Tariffs.Update(value);
                await _dbContext.SaveChangesAsync();
            }

        }

        public ICollection<DAL.Models.Billing.Tariff> getAllTariffs()
        {
            return _mapper.Map< ICollection<DAL.Models.Billing.Tariff> >(_dbContext.Tariffs);
        }
    }
}
