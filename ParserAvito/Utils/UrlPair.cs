using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserAvito.Utils
{
    public class UrlPair
    {
        public string Url1 { get; set; }
        public string Referer { get; set; }

        public UrlPair(string s, string b)
        {
            Url1 = s;
            Referer = b;
        }
    }
}
