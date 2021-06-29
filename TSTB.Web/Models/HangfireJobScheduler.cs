using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSTB.BLL.Services.CurrencyRateService;

namespace TSTB.Web.Models
{
    public class HangfireJobScheduler
    {
        public static void ScheduleRecurringJobs()
        {
            RecurringJob.RemoveIfExists(nameof(CurrencyRateService));
            RecurringJob.AddOrUpdate<CurrencyRateService>(nameof(CurrencyRateService),
                job => job.Run(JobCancellationToken.Null), Cron.Weekly(DayOfWeek.Monday), TimeZoneInfo.Local);
        }
    }
}
