using System;
using System.Collections.Generic;
using System.Text;

namespace sg.adnovum.keyboard.assist
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    internal class BaseParserAttribute : Attribute
    {

        public int ParserType { get; set; }

        internal BaseParserAttribute(int parserType)
        {

            this.ParserType = parserType;
        }

    }

}
