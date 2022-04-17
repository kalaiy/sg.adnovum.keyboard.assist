using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sg.adnovum.keyboard.assist;
using sg.adnovum.keyboard.assist.filter;

namespace sg.adnovum.keyboard.assist.console
{
    public class KeyBoardAssist
    {
        public string Process(string input,
            string pattern,int minimumLength,
            int maxPercent, int parserType)
        {

            try
            {
                var validationRules = new List<IValidationRule>();

                validationRules.Add(new MinimumLengthValidationRule(minimumLength));

                if (validationRules.All(o => o.IsValid(input)))
                {
                    input = RegexFilter.ScanInput(pattern, input);
                    if (!String.IsNullOrEmpty(input))
                    {
                        IParagraphParser parser = ParserFactory.GetParser(parserType);
                        var result = parser.Parse(input);
                        IHandler handler = new OutputHandler(maxPercent);
                        return handler.HandleOutput(input.Length, result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured while processing input {ex.Message}");
               
            }
            return "";
        }
    }
}
