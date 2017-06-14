using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace spb24Parser
{
    public class HtmlDownloadHelper
    {
        // 2 создаем статический метод
        public static string DownloadHtml(string uri)
        {
            return DownloadHtml(uri, Encoding.UTF8);
        }

        public static string DownloadHtml(string uri, Encoding encoding)
        {
            //WebProxy wp = ParserVirgo.Proxi.WebanetLabsNet.ExecuteProxi(goodUrlsList);
            //WebProxy wp = new WebProxy("178.215.111.70", 9999); 

            // 3 это формирует запрос, который уходит на сервер и обрабаотывается там и выдае ответ.
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;

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