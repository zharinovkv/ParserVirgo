using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Threading;
using System.Windows.Forms;

namespace ParserAvito.Phone
{
    public class ParserPhone
    {
        public string AvitoUrl { get; set; } = "https://m.avito.ru";
        public event Action<string> Logger;
        Random x = new Random();
        List<bool> error = new List<bool>();

        StringBuilder stringBuilder = new StringBuilder();
        int counter = 5027;

        // этот метод парсит обхявление
        public async void ParseArticles(Request[] refs)
        {
            foreach (var item in refs)
            {
                int time1 = x.Next(2000, 6000);
                Thread.Sleep(time1);

                try
                {
                    //NetworkCredential credentials = new NetworkCredential();
                    Task<HtmlAgilityPack.HtmlDocument> _task = new Task<HtmlAgilityPack.HtmlDocument>(() => { return new HtmlWeb().Load(item.Url, "GET"); }); _task.Start();
                    HtmlAgilityPack.HtmlDocument doc = await _task.ConfigureAwait(false);

                    // 3 это формирует запрос, который уходит на сервер и обрабатывается там и выдает ответ.
                    //HttpWebRequest request = WebRequest.Create(item.Url) as HttpWebRequest;



                    ////// Obtain the 'Proxy' of the  Default browser.  
                    ////IWebProxy proxy = request.Proxy;

                    ////WebProxy myProxy = new WebProxy();
                    ////string proxyAddress;

                    ////try
                    ////{
                    ////    proxyAddress = "http://201.55.46.6:80";

                    ////    if (proxyAddress.Length > 0)
                    ////    {
                    ////        Uri newUri = new Uri(proxyAddress);
                    ////        // Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
                    ////        myProxy.Address = newUri;
                    ////        // Create a NetworkCredential object and associate it with the 
                    ////        // Proxy property of request object.
                    ////        request.Proxy = myProxy;
                    ////    }
                    ////}
                    ////catch (Exception ex)
                    ////{
                    ////    ex.ToString(); 
                    ////}


                    ////request.Proxy = new WebProxy("87.98.147.195", 3128);


                    //request.UserAgent = item.UserAgent;
                    //request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*;q=0.8";
                    //request.KeepAlive = true;
                    //request.AllowAutoRedirect = true;
                    //request.Timeout = 60000;
                    //request.Method = "POST";
                    //request.Referer = item.UrlReferer;
                    //request.Headers["Accept-Language"] = "ru-RU";

                    //// 4 получаем ответ
                    //HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                    //// 5 поток данных получаемых с сервера
                    //StreamReader sr = new StreamReader(response.GetResponseStream());
                    //sr.ReadLine();
                    //string html = sr.ReadToEnd();

                    //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    //doc.LoadHtml(html);

                    int time2 = x.Next(2000, 6000);
                    Thread.Sleep(time2);

                    //парсим номер телефона
                    var _phone = await _parsePhone(AvitoUrl + doc.DocumentNode.SelectSingleNode("//a[@title='Телефон продавца']").Attributes["href"].Value + "?async", item.Url, item.UserAgent);


                    //Articles _article = new Articles();
                    //_article.Url = item.Url;
                    //_article.Phone = _phone;
                    //Console.WriteLine(_article.Url + " " + _article.Phone);

                    int time3 = time1 + time2;
                    stringBuilder.Append(item.Url + "; " + _phone + "; " + time3).AppendLine();
                    counter++;

                    SaveAs saveAs = new SaveAs();
                    saveAs.SaveAsCSV(stringBuilder, counter.ToString());
                    stringBuilder.Clear();

                    //if (counter > 100)
                    //{ 
                    if (counter % 10 == 0)
                    {
                        Thread.Sleep(x.Next(counter / 2, counter));

                        //SaveAs saveAs = new SaveAs();
                        //saveAs.SaveAsCSV(stringBuilder, counter);
                        //MessageBox.Show(stringBuilder.ToString());
                    }
                    //}
                }
                catch (Exception ex)
                {
                    counter++;
                    StringBuilder sb = new StringBuilder();
                    sb.Append(item.Url + "/r/n" + ex.ToString());
                    SaveAs saveAs = new SaveAs();
                    saveAs.SaveAsCSV(sb, counter.ToString() + " error");
                    sb.Clear();
                    Thread.Sleep(x.Next(counter * 5, counter * 20));

                    error.Add(true);
                    if (error.Count > 2)
                    {
                        Thread.Sleep(x.Next(counter * 10, counter * 20));
                        //error.Clear();
                    }
                }

            }
        }

        private async Task<string> _parsePhone(string url, string referer, string useragent)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.UserAgent = useragent;
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
                Logger.Invoke(ex.ToString());
            }
            return _phone;
        }



        #region Singlton

        public ParserPhone()
        {
        }


        private static ParserPhone _instance;

        public static ParserPhone Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ParserPhone();
                }
                return _instance;
            }
            private set { }
        }

        #endregion
    }
}


