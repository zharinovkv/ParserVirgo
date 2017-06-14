using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParserAvito
{
    public class HtmlDownloadHelper
    {
        // 2 создаем статический метод
        public static string DownloadHtml(Request _request)
        {
            return DownloadHtml(_request, Encoding.UTF8);
        }

        public static string DownloadHtml(Request _request, Encoding encoding)
        {
            // 3 это формирует запрос, который уходит на сервер и обрабатывается там и выдает ответ.
            HttpWebRequest request = WebRequest.Create(_request.Url) as HttpWebRequest;

            WebProxy wp = new WebProxy(_request.ProxyIP);
            request.Proxy = wp;

            UserAgent userAgent = new UserAgent();
            request.UserAgent = _request.UserAgent;

            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*;q=0.8";
            request.KeepAlive = true;
            request.AllowAutoRedirect = true;
            request.Timeout = 60000;
            request.Method = "GET";
            request.Referer = _request.UrlReferer;
            
            request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            request.Headers["Accept-Language"] = "ru-RU";

            // 4 получаем ответ
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            // 5 поток данных получаемых с сервера
            StreamReader sr = new StreamReader(response.GetResponseStream(), encoding);
            sr.ReadLine();
            string html = sr.ReadToEnd();

            // 6 получаем чтмл
            return html;
        }
    }
}