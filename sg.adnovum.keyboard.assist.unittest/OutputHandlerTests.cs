using Xunit;
using System.Linq;
using sg.adnovum.keyboard.assist.model;
using System.Collections.Generic;
using sg.adnovum.keyboard.assist.filter;

namespace sg.adnovum.keyboard.assist.unittest
{
  
    public class OutputHandlerTests
    {


        [Theory]
        [InlineData(30)]
        public void HandleOutputTest_HelloWorld(int maxPercent)
        {
            //List<ParserResult> GetParserResults
            IHandler handler = new OutputHandler(maxPercent);
            string input = "helloworld";
            List<ParserResult> parserResults = new List<ParserResult>();
            parserResults.Add(new ParserResult() { Letter='l', Count=3 });
            parserResults.Add(new ParserResult() { Letter='o', Count=2 });
            Assert.Equal("l", handler.HandleOutput(input.Length, parserResults));
            
        }

        [Theory]
        [InlineData(30)]
        public void HandleOutputTest_InputGreaterThanMaximumPercent(int maxPercent)
        {
            //List<ParserResult> GetParserResults
            IHandler handler = new OutputHandler(maxPercent);
            string input = "madam";
            List<ParserResult> parserResults = new List<ParserResult>();
            parserResults.Add(new ParserResult() { Letter='a', Count=2 });
            parserResults.Add(new ParserResult() { Letter='m', Count=2 });
            Assert.Equal("", handler.HandleOutput(input.Length, parserResults));

        }

        [Theory]
        [InlineData(30)]
        public void HandleOutputTest_SameOccuranceCheck(int maxPercent)
        {
            //List<ParserResult> GetParserResults
            IHandler handler = new OutputHandler(maxPercent);
            string input = @"To us on Earth, the sun is a smiling orange-yellow circle among the cottony clouds. But the fiery
ball of fire out in space is so much more than that.The Sun is the star, the center of our solar
system.It is the most important source of energy for life on earth.With its humongous size and
heavy composition of chemicals, this blazing star has a magnified gravitational force, compelling
all the planets, including the earth to revolve around it.Due to its importance in our lives, man
since prehistoric times has considered it a deity and I personally believe it is nothing less than
that.";
            input = RegexFilter.ScanInput(@"[a-zA-Z]+", input);
            IParagraphParser parser = new LinqParagraphParser();
          
            var result = parser.Parse(input);
            var output = handler.HandleOutput(input.Length, result);
            Assert.Equal(string.Join("",new string[] {
                "e",System.Environment.NewLine.ToString(),"t"}), output);

        }


    }
}