using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace ParserAvito
{
    public class ParserException : Exception
    {
        public ParserException(string message)
            : base(message)
        { }
    }

    public class SearcherAvito
    {
        private string _html;
        private string _title;
        private string _url;


        public string Title
        {
            get
            {
                //if (_title == null)
                //    throw new ParserException("Заголовок не загружен");
                return _title;
            }
        }
        public string Url
        {
            get
            {
                return _url;
            }
        }


        public bool DownLoadHtml(Request adress)
        {

            // 7 16.20
            try
            {
                _html = HtmlDownloadHelper.DownloadHtml(adress, Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool FindTitle()
        {
            if (string.IsNullOrEmpty(_html))
                throw new ParserException("Код не был загружен. Сначала выполните Download Html");
            TextSearcher ts = new TextSearcher(_html);

            ts.Skip("avito.item.url = '/");
            ts.Skip("<h1 itemprop=\"name\" class=\"h1\">");

            string title = ts.ReadTo("</h1>");

            try
            {
                _title = title;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool FindUrl(string url)
        {
            try
            {
                _url = url;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} \t  {1} \t {2}", Title, Url, Environment.NewLine);
        }

        private async Task<string> _parsePhone(string url, string referer)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.103 Safari/537.36";
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.Referer = referer;
            // request.Headers.Add("Accept-Charset", "windows-1251,utf-8;q=0.7,*;q=0.7");        
            request.Method = "GET";
            HttpWebResponse response;
            string _phone = "";
            try
            {
                response = (HttpWebResponse)await request.GetResponseAsync();
                StreamReader _reader = new StreamReader(response.GetResponseStream());
                _phone = _reader.ReadLine();
                _phone = _phone.Replace("{\"phone\":\"", "").Replace("\"}", "");

                Console.WriteLine(url, " ", _phone);
                response.Close();
            }
            catch (Exception ex)
            {

            }
            return _phone;
        }


    }
}
