using Xunit;
using System.Linq;
using System;

namespace sg.adnovum.keyboard.assist.unittest
{
    
    public class ParserFactoryTests
    {
        [Fact]
        public void GetParserTest_TypeCheck()
        {
            Assert.IsType<LinqParagraphParser>(ParserFactory.GetParser((int)ParserType.LINQ));
            Assert.IsType<HashParagraphParser>(ParserFactory.GetParser((int)ParserType.HASH));
        }

        [Fact]
        public void GetParserTest_TypeNotFound()
        {
            Assert.Throws<InvalidOperationException>(()=>ParserFactory.GetParser(4));
            
        }
    }
}