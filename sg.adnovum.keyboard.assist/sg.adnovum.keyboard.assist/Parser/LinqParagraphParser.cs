using sg.adnovum.keyboard.assist.model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace sg.adnovum.keyboard.assist
{
    [BaseParser((int)ParserType.LINQ)]
    public class LinqParagraphParser : ParagraphParser
    {

        private List<ParserResult> ParseInternal(string line)
        {
            return line.GroupBy(x => x).
                Select(g => new ParserResult { Letter = g.Key, Count = g.Count() }).ToList();
        }

        protected override List<ParserResult> ParseParagraph(string line)
        {
            return ParseInternal(line);

        }
    }
}
