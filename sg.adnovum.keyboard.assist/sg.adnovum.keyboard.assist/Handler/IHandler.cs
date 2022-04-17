using sg.adnovum.keyboard.assist.model;
using System.Collections.Generic;

namespace sg.adnovum.keyboard.assist
{
    public interface IHandler
    {
        string HandleOutput(int length, List<ParserResult> parserResults);
    }
}