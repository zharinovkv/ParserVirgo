using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserAvito
{
    public class UserAgent
    {
        public string userAgent()
        {
            string[] userAgents = Properties.Resources.useragents.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            Random r = new Random();
            string userAgent = userAgents[r.Next(0, userAgents.Length-1)];
            return userAgent;
        }
    }
}
