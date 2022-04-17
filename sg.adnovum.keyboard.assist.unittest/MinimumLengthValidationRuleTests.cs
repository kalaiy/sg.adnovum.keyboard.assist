using Xunit;

namespace sg.adnovum.keyboard.assist.unittest
{
   
    public class MinimumLengthValidationRuleTests
    {
        [Theory]
        [InlineData("Hello World",3)]
        public void MinimumLengthValidationRule_IsValidTest(string input, int minimumLength)
        {
            IValidationRule rule = new MinimumLengthValidationRule(minimumLength);
            Assert.True(rule.IsValid(input));
        }

        [Theory]
        [InlineData("Hello", 15)]
        public void MinimumLengthValidationRule_IsNotValidTest(string input, int minimumLength)
        {
            IValidationRule rule = new MinimumLengthValidationRule(minimumLength);
            Assert.False(rule.IsValid(input));
        }
    }
}