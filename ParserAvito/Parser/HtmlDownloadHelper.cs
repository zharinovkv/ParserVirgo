using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParserVirgo
{
    public class HtmlDownloadHelper
    {
        // 2 создаем статический метод
        public static string DownloadHtml(string uri, List<string> goodUrlsList)
        {
            return DownloadHtml(uri, Encoding.UTF8, goodUrlsList);
        }

        public static string DownloadHtml(string uri, Encoding encoding, List<string> goodUrlsList)
        {
            //WebProxy wp = ParserVirgo.Proxi.WebanetLabsNet.ExecuteProxi(goodUrlsList);
            //WebProxy wp = new WebProxy("178.215.111.70", 9999); 

            // 3 это формирует запрос, который уходит на сервер и обрабаотывается там и выдае ответ.
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;

            //request.Proxy = wp;

            UserAgent userAgent = new UserAgent();
            request.UserAgent = userAgent.getListUserAgents()[1];
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*;q=0.8";
            request.KeepAlive = true;
 

            //request.AllowAutoRedirect = true;
            //request.Timeout = 60000;
            //request.Method = "GET";

            //request.Referer = SiteSettings.siteurl + SiteSettings.suburl;
            //request.Referer = http://professorweb.ru/my/csharp/web/level7/7_1.php;

            //request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            //request.Headers["Accept-Language"] = "en-US";

            // 4 получаем ответ
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            // 5 поток данных получаемых с сервера
            StreamReader sr = new StreamReader(response.GetResponseStream(), encoding);
            sr.ReadLine();
            string html = sr.ReadToEnd();

            // 6 получаем чтмл
            return html;
        }

        //52.00
        public static Image DownLoadImage(string uri)
        {
            //WebProxy wp = new WebProxy("178.215.111.70", 9999);

            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            // 3 это формирует запрос, который уходит на сервер и обрабаотывается там и выдае ответ.
            //request.Proxy = wp;
            UserAgent userAgent = new UserAgent();
            request.UserAgent = userAgent.getListUserAgents()[2];
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*;q=0.8";
            request.KeepAlive = true;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return Image.FromStream(response.GetResponseStream());
        }
    }
}