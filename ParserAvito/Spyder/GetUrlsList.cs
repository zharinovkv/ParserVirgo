using ParserAvito.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;


// в этом классе получаем 
namespace ParserVirgo
{
    public class GetUrlsList
    {
        public List<string> GetListings(int Num)
        {
            List<UrlPair> Url = new List<UrlPair>();

            try
            {
                using (var Request = new HttpRequest())
                {
                    string sourcePage;

                    UserAgent userAgent = new UserAgent();
                    Request.UserAgent = userAgent.getListUserAgents()[2];
                    Request.KeepAlive = true;

                    // это загружает ОДНУ "навигационную" страницу, в которой находятся ссылки на страницы контента (объявлений)
                    // затем, в методе Work() это выполняется в цикле, с кол-вом итераций (int Num)

                    // это шаблон для страниц Авито
                    string referer = SiteSettings.siteurl + SiteSettings.suburl + SiteSettings.sourcePageSubstringsSecond + Num;
                    sourcePage = Request.Get(referer).ToString();


                    // переменная для хранения строк
                    // это массив, в который загружаются УРЛЫ страниц объявлений,
                    // чтобы правильно найти - надо 
                    string[] row;
                    row = sourcePage.Substrings(SiteSettings.sourcePageSubstringsFoure, SiteSettings.sourcePageSubstringsFive, 0);

                    for (int i = 1; i < row.Length; i++)
                    {
                        Url.Add(new UrlPair(UrlPair.Url1 = (SiteSettings.siteurl + row[i]).ToString(), UrlPair.referer);
                    }
                }
            }

            catch
            {

            }

            return url;
        }

    }
}
