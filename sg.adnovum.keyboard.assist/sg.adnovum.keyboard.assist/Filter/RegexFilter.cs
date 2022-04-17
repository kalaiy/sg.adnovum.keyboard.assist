using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace sg.adnovum.keyboard.assist.filter
{
    public static class RegexFilter
    { 
        public static string ScanInput(string pattern,string line)
        {
            var matches = Regex.Matches(line, pattern);
            if (matches?.Count>0)
            {
                return string.Join("", matches.Cast<Match>().Select(o => o.Value).ToArray());

            }
            return "";
        }
    }
}
