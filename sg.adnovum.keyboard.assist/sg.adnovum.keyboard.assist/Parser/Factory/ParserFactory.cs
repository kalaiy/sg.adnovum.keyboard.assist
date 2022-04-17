using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace sg.adnovum.keyboard.assist
{
    public static class ParserFactory
    {
        private static Dictionary<int, IParagraphParser> _parserMap = new Dictionary<int, IParagraphParser>();

        static ParserFactory()
        {
            InitializeParser();
        }

        private static void InitializeParser()
        {
            var mapList = (from ty in typeof(ParagraphParser).Assembly.GetTypes()
                           let attr = ty.GetCustomAttributes(typeof(BaseParserAttribute), false).OfType<BaseParserAttribute>().ToArray()
                           where attr.Length > 0
                           select new ParserMap()
                           {
                               BaseType = ty,
                               ParserAttr = attr[0]
                           }).ToArray();
          
            foreach (ParserMap map in mapList)
            {
                _parserMap.Add(map.ParserAttr.ParserType, Activator.CreateInstance(map.BaseType) as IParagraphParser);
            }

        }

        public static IParagraphParser GetParser(int parserType)
        {
            if (_parserMap.ContainsKey(parserType))
            {
                return _parserMap[parserType];
            }
            else
            {
                throw new InvalidOperationException($"Parser not found for the type {parserType}");
            }
        }
    }

    internal class ParserMap
    {
        public Type BaseType { get; set; }
        public BaseParserAttribute ParserAttr { get; set; }
    }
}
