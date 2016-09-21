using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Threading;

namespace ParserAvito.Phone
{
    public class Parser
    {
        public string AvitoUrl { get; set; } = "https://m.avito.ru";

        public event Action<string> Logger;

        // этот метод запускает метод полоучениясписка урлов страниц с объявлениями,
        // а затем парсит эти урлы 
        public async void ParseAll(string url, int pageNumber = 0)
        {
            //var _refs = await ParseRefs(url, pageNumber);
            // Logger("Найдено " + _refs.Length + " объявлений!");
            //ParseArticles(_refs);
        }

        #region Private Methods

        // этот метод получает список урлов страниц с объявлениями,
        public async Task<string[]> ParseRefs(string url, int pageNumber = 0)
        {
            List<string> _urls = new List<string>();
            int _pageNum = pageNumber > 0 ? pageNumber - 1 : pageNumber;
            bool _flag = true;
            while (_flag)
            {
                _pageNum++;
                try
                {
                    Task<HtmlDocument> _task = new Task<HtmlDocument>(() => { return new HtmlWeb().Load(url + "?p=" + _pageNum); }); _task.Start();
                    HtmlDocument _doc = await _task.ConfigureAwait(false);
                    HtmlNodeCollection _hrefs = _doc.DocumentNode.SelectNodes("//a[@class='item-link']");
                    foreach (var item in _hrefs)
                    {
                        var _url = AvitoUrl + item.Attributes["href"].Value;
                        var _ref = _url; // AvitoDb.Articles.FirstOrDefault(art => art.Url == _url);


                        if (_ref == null)
                        {
                            _urls.Add(_url);
                        }
                    }
                    HtmlNodeCollection _nextPageRef = _doc.DocumentNode.SelectNodes("//li[@class='page page-next']");
                    if (_nextPageRef == null) _flag = false;

                }
                catch (Exception ex)
                {
                    Logger.Invoke(ex.ToString());
                }
            }

            return _urls.ToArray();
        }

        // этот метод парсит обхявление
        public async void ParseArticles(params string[] refs)
        {
            foreach (var url in refs)
            {
                try
                {
                    //Articles _article = AvitoDb.Articles.FirstOrDefault(art => art.Url == url);

                    //if (_article != null)
                    //{
                    //    continue;
                    //}

                    Articles _article = new Articles();

                    //асинхронно загружаем содержание url
                    Task<HtmlDocument> _task = new Task<HtmlDocument>(() => { return new HtmlWeb().Load(url); }); _task.Start();
                    HtmlDocument _doc = await _task.ConfigureAwait(false);
                                       

                    //парсим содержание
                    var _info = _doc.DocumentNode.SelectSingleNode("//div[@class='description-preview-wrapper']");
                    HtmlNode _info2 = null;
                    string _infoStr = "";
                    if (_info == null)
                    {
                        _info = _doc.DocumentNode.SelectSingleNode("//div[@class='description-preview-wrapper description-with-html']");
                        _info2 = _doc.DocumentNode.SelectSingleNode("//div[@class='shop-description']");

                    }

                    _infoStr = _info.InnerText.Replace("\n", "");//.Remove(0, 1).Remove(_infoStr.Length - 3, 3);
                    if (_info2 != null) _infoStr += _info2.InnerText.Replace("\n", "");//.Remove(0, 1).Remove(_infoStr.Length - 3, 3);

                    //парсим номер объявления
                    //var _number = _doc.DocumentNode.SelectSingleNode("//div[@class='item-id']").InnerHtml.Replace("Объявление №", "");

                    //парсим номер телефона
                    var _phone = await _parsePhone(AvitoUrl + _doc.DocumentNode.SelectSingleNode("//a[@title='Телефон продавца']").Attributes["href"].Value + "?async", url);

                    _article = new Articles();
                    _article.Url = url;
                    _article.Phone = _phone;

                    Console.WriteLine(_article.Url + " " + _article.Phone);

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
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
                //_phone = _phone./*Remove(_phone.Length - 4, 4).*/Replace(" ", "").Replace("-", "");
                _phone = _phone.Replace("{\"phone\":\"", "").Replace("\"}", "");

                Console.WriteLine(_phone);
                response.Close();
            }
            catch (Exception ex)
            {
                Logger.Invoke(ex.ToString());
            }
            return _phone;
        }
        #endregion

        #region Singlton
        private Parser()
        {
        }


        private static Parser _instance;

        public static Parser Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Parser();
                }
                return _instance;
            }
            private set { }
        }

        #endregion
    }
}


