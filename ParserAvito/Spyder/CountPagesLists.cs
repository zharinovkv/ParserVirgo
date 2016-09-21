using ParserVirgo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace ParserAvito.Spyder
{
    public class CountPagesLists
    {
        // 5.50 функция возвращает  значение кол-ва страниц
        public int GetCountPages()
        {
            int counterPages = 0;

            try
            {
                // получаем исходный код страницы
                using (var Request = new HttpRequest())
                {
                    UserAgent userAgent = new UserAgent();
                    Request.UserAgent = userAgent.getListUserAgents()[2];
                    Request.KeepAlive = true;
                    Request.Referer = SiteSettings.url;

                    // переменная для страницы
                    // указываем ссылку на страницу, в которй хранится кол-во старниц
                    string SourcePage = Request.Get(SiteSettings.url).ToString();

                    // парсим кол-во старниц
                    // функция Substrings() парсит текст, находящийся между каким-либо промежутками
                    // пояснения к [4] - 10.40 - это четвертый элемент массива
                    string[] paginagionpage = SourcePage.Substrings(SiteSettings.sourcePageSubstringsStart, SiteSettings.sourcePageSubstringsEnd);
                    

                    counterPages = ExtractNumbers(paginagionpage[paginagionpage.Length - 1]);

                    //counterPages = Convert.ToInt16(paginagionpage[paginagionpage.Length - 1]);
                    //counterPages = Convert.ToInt32(SourcePage.Substrings(SiteSettings.suburl + SiteSettings.sourcePageSubstringsEnd, SiteSettings.sourcePageSubstringsThree, 0)[paginagionpage.Length - 1]);
                }

            }
            catch
            {

            }
            counterPages = 1;
            return counterPages;
        }

        private static int ExtractNumbers(string s)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection matches = regex.Matches(s);
            string sss = "";
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    sss = sss + match.Value.ToString();
                }
            }
            else
            {
            }
            return Convert.ToUInt16(sss);
        }
    }
}
