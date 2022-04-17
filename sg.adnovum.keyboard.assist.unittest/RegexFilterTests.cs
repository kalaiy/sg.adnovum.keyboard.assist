using Xunit;
using System.Linq;
using sg.adnovum.keyboard.assist.filter;

namespace sg.adnovum.keyboard.assist.unittest
{

    public class RegexFilterTests
    {
        [Theory]
        [InlineData(@"[a-zA-Z]+","Hello World")]
        public void ScanInputTest_IsAlpha(string pattern, string line)
        {
            string str = RegexFilter.ScanInput(pattern, line);
            Assert.True(str.ToCharArray().All(o => char.IsLetter(o)));
           
        }

        [Theory]
        [InlineData(@"[a-zA-Z]+", "342 34")]
        public void ScanInputTest_IsNotAlpha(string pattern, string line)
        {
            string str = RegexFilter.ScanInput(pattern, line);
            Assert.Empty(str);

        }
    }
}