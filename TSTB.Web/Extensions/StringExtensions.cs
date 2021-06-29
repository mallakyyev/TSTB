using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TSTB.Web.Extensions
{
    public static class StringExtensions
    {
        public static string SkipImgTags(this string html)
        {
            string strWithoutImgTags = Regex.Replace(html, @"(<img\/?[^>]+>)", @"", RegexOptions.IgnoreCase);

            return strWithoutImgTags.Substring(0, strWithoutImgTags.Length);
        }
    }
}
