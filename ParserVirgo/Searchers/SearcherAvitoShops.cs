using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserVirgo.Utils;
using xNet;
using System.Drawing;
using ParserAvito;

namespace ParserVirgo.Searchers
{
    class SearcherAvitoShops
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
        public string ImagePath { get; set; }

        public bool DownLoadHtml(string adress, List<string> goodUrlsList)
        {
            //_title = null;

            // 7 16.20
            try
            {
                _html = HtmlDownloadHelper.DownloadHtml(string.Format(adress), Encoding.UTF8, goodUrlsList);
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
                throw new Utils.ParserException("Код не был загружен. Сначала выполните Download Html");
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
            return string.Format("{0} \t  {1} \t {2}", Title, ImagePath, Url, Environment.NewLine);
        }
    }
}
