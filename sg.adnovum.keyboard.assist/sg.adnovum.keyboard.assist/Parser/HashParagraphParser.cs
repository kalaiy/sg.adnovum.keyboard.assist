using sg.adnovum.keyboard.assist.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace sg.adnovum.keyboard.assist
{
    [BaseParser((int)ParserType.HASH)]
    public class HashParagraphParser : ParagraphParser
    {
        private IDictionary<char, ParserResult> parserResults = new Dictionary<char, ParserResult>();
        private List<ParserResult> ParseInternal(string line)
        {
            line= line.ToLower();
            foreach (var letter in line)
            {
                if (parserResults.ContainsKey(letter))
                {
                    var result=parserResults[letter];
                    result.Count+=1;
                }
                else
                {
                    parserResults.Add(letter, new ParserResult() { Count=1, Letter=letter });
                }
            }
            return parserResults.Values.ToList();
        }

        protected override List<ParserResult> ParseParagraph(string line)
        {
            return ParseInternal(line);

        }
    }
}
