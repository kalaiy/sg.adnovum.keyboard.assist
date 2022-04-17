using sg.adnovum.keyboard.assist.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg.adnovum.keyboard.assist
{
    public class OutputHandler : IHandler
    {
        private readonly int maxPercent;

        public OutputHandler(int maxPercent)
        {
            this.maxPercent=maxPercent;
        }

        private string HandleOutputInternal(int length, List<ParserResult> parserResults)
        {
            var totalPercent = 0d;
            var tempPercent = 0d;
            var isSameOccurance = false;
            List<char> output = new List<char>();
            foreach (var parserResult in parserResults)
            {
                var percent = (double)parserResult.Count/length * 100;
                totalPercent += percent;
                if (totalPercent> maxPercent)
                {
                    break;
                }
                if (!isSameOccurance)
                    isSameOccurance=(tempPercent==percent);
                if (percent > 0 && percent<=maxPercent)
                {
                    output.Add(parserResult.Letter);
                    tempPercent=percent;
                }

            }

            if (isSameOccurance)
            {
                output.Sort();
            }
            return string.Join(Environment.NewLine, output);
        }

       
        public virtual string HandleOutput(int length, List<ParserResult> parserResults)
        {
            return HandleOutputInternal(length, parserResults);
        }

    }


}
