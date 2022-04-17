using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg.adnovum.keyboard.assist
{
    public class MinimumLengthValidationRule : IValidationRule
    {
        private readonly int minLength;

        public MinimumLengthValidationRule(int minLength)
        {
            this.minLength=minLength;
        }

        public bool IsValid(string line)
        {
            return !(line.Length<=minLength);
           
        }
    }
}
