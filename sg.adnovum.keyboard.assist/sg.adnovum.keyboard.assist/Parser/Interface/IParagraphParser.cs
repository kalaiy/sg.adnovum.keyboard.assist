using sg.adnovum.keyboard.assist.model;
using System.Collections.Generic;

namespace sg.adnovum.keyboard.assist
{
    public interface IParagraphParser
    {
        List<ParserResult> Parse(string line);
    }
}