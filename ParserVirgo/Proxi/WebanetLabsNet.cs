using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace ParserVirgo.Proxi
{
    class WebanetLabsNet
    {        
        public static List<string> GetProxi()
        {
            List<string> proxiesList = new List<string>();

            try
            {
                using (var Request = new HttpRequest())
                {
                    UserAgent userAgent = new UserAgent();                    
                    
                    Request.UserAgent = userAgent.userAgent();
                    Request.KeepAlive = true;

                    string sourcePage = Request.Get("http://webanetlabs.net/publ/24").ToString();
                    string[] row = sourcePage.Substrings("<!--ust--><a class=\"link\" href=\"", "\"", 0);
                    string url = "http://webanetlabs.net" + row[0];

                    // переменная для страницы
                    // указываем ссылку на страницу, в которй хранится кол-во старниц
                    string source = Request.Get(url).ToString().TrimStart('п', '»', 'ї');
                    //string str = source.Substring("", "");
                    proxiesList = source.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
            } catch{}
           
            return proxiesList;
        }

        public static WebProxy ExecuteProxi(List<string> proxiesList)
        {
            string proxi = "";
            Random r = new Random();
            int z = r.Next(0, proxiesList.Count - 1);

            try
            {
                proxi = proxiesList[z];
            }
            catch { }

            string[] proxies = proxi.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            WebProxy wp = new WebProxy(proxies[0], Convert.ToInt32(proxies[1]));            

            return wp;

        }

    }
}