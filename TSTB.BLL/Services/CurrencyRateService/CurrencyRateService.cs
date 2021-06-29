using Hangfire;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TSTB.BLL.ViewModel;
using TSTB.DAL.Models.CurrencyRate;
using TSTB.Web.Data;

namespace TSTB.BLL.Services.CurrencyRateService
{
    public class CurrencyRateService : ICuurencyRateService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CurrencyRateService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ICollection<CurrencyRate>> GetCurrentCurrencyRate()
        {
            List<CurrencyRate> result = new List<CurrencyRate>();
            result.Add(await _applicationDbContext.CurrencyRates.FindAsync("USD"));
            result.Add(await _applicationDbContext.CurrencyRates.FindAsync("EUR"));
            result.Add(await _applicationDbContext.CurrencyRates.FindAsync("GBP"));
            return result;
        }

        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await UpdateDataBaseForCurrencyRate();
        }
        public async Task UpdateDataBaseForCurrencyRate()
        {
            DateTime date = DateTime.Now;
            XmlSerializer serializer = new XmlSerializer(typeof(ListCurrency));
            ListCurrency dezerializedList;
            using HttpClient client = new HttpClient();
            var result = await client.PostAsync("https://www.cbt.tm/kurs/" + date.Year + "/" + date.Day + "" + date.Month + "" + date.Year + ".xml", null);
            var response = await result.Content.ReadAsStringAsync();
            try
            {
                using (TextReader reader = new StringReader(response))
                {
                    dezerializedList = (ListCurrency)serializer.Deserialize(reader);

                    if (dezerializedList != null)
                    {
                        foreach (CurrencyRate rate in dezerializedList.CurrencyRates)
                        {
                            CurrencyRate res = await _applicationDbContext.CurrencyRates.FindAsync(rate.code);
                            if (res == null)
                                await _applicationDbContext.CurrencyRates.AddAsync(rate);
                            else
                                _applicationDbContext.CurrencyRates.Update(rate);
                            await _applicationDbContext.SaveChangesAsync();
                        }
                    }
                }
            }catch(Exception e)
            {

            }
          
          
        }
    }
}
