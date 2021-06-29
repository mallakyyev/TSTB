using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TSTB.Web.Extensions
{
    public static class DateCultureExtensions
    {
        public static string ToDateFormat(this DateTime date)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if(culture == "tk")
            {
                string[] months = { "ýanwar", "fewral", "mart", "aprel", "maý", "iýun", "iýul", "awgust", "sentýabt", "oktýabr", "noýabr", "dekabr" };
                return $"{date.Day} {months[date.Month - 1]} {date.Year}";
            }
            return date.ToString("dd MMMM yyyy");
        }
    }
}
