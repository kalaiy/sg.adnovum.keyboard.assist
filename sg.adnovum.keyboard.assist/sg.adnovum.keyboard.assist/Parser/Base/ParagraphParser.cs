using sg.adnovum.keyboard.assist.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace sg.adnovum.keyboard.assist
{
    public abstract class ParagraphParser : IParagraphParser
    {

        public List<ParserResult> Parse(string line)
        {
            line=  line.ToLower();
            var parserResults = ParseParagraph(line);
            return parserResults.Where(o => o.Count>1).OrderByDescending(o => o.Count).ToList();
        }

        protected abstract List<ParserResult> ParseParagraph(string line);

    }
}
