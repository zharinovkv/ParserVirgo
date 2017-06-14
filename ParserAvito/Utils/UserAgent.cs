using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserAvito.Properties;

namespace ParserAvito
{
    public class UserAgent
    {
        public string[] getListUserAgents()
        {
            string[] listUserAgents = Resources.useragents.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            return listUserAgents;
        }
    }
}
