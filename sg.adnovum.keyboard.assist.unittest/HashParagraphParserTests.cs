using Xunit;
using System.Linq;
namespace sg.adnovum.keyboard.assist.unittest
{

    public class HashParagraphParserTests
    {
        [Theory]
        [InlineData("helloworld")]
        public void ParseTest_Success(string line)
        {
            IParagraphParser parser = new HashParagraphParser();
            var results = parser.Parse(line);
            Assert.True(results.Count>0);
            Assert.Equal(3, results.First().Count);
        }

        [Theory]
        [InlineData("")]
        public void ParseTest_EmptyString(string line)
        {
            IParagraphParser parser = new HashParagraphParser();
            var results = parser.Parse(line);
            Assert.Empty(results);
        }

        [Theory]
        [InlineData("madam")]
        public void ParseTest_ExceptedCount(string line)
        {
            IParagraphParser parser = new HashParagraphParser();
            var results = parser.Parse(line);
            Assert.Equal(2, results.Count);
        }
    }
}