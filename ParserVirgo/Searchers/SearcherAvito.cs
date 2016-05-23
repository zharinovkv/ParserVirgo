using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace ParserVirgo
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
        private List<Image> _cover;
        private string _url;

        public Image Cover
        {
            get
            {
                //if (_cover == null)
                //    throw new ParserException("Изображение не загружено");
                return _cover;
            }
        }
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
            _cover = null;
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

        public bool FindCover()
        {             
            if (string.IsNullOrEmpty(_html))
                throw new ParserException("Код не был загружен. Сначала выполните Download Html");
            TextSearcher ts = new TextSearcher(_html);

            //ts.GoTo("b-gallery");
            //ts.Skip("gallery-list");
            //ts.Skip("gallery-link\" href=\"//");
            //string imageFilmUri = "https://" + ts.ReadTo("\" id");

            string[] imageFilmUriRelative = _html.Substrings("gallery-link\" href=\"//", "\" data-fallback", 0);
            var imageFilmUri = from q in imageFilmUriRelative
                               let q1 = "https://" + q
                               select q1;   

            foreach (var imageUri in imageFilmUri)
            {
                try
                {
                    _cover.Add(HtmlDownloadHelper.DownLoadImage(imageUri));
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
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
            return string.Format("{0} \t  {1} \t {2}", Title, ImagePath, Url, Environment.NewLine);
        }
    }
}
