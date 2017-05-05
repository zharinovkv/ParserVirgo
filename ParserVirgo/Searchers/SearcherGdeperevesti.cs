using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserAvito
{
    // класс поиск по Авито 
    // делает всю рабту - поиск, обработка, картинка

    public class SearcherGdeperevesti
    {
        // полученный html
        private string _html;

        // поле
        private string _title;
        private string _phone;
        private string _fax;
        private string _adress;
        private string _email;
        private string _site;
        private string _str;

        // свойства
        public string Title
        {
            get
            {
                return _title;
            }
        }
        public string Phone
        {
            get
            {
                return _phone;
            }
        }
        public string Fax
        {
            get
            {
                return _fax;
            }
        }
        public string Adress
        {
            get
            {
                return _adress;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
        }
        public string Site
        {
            get
            {
                return _site;
            }
        }
        public string Url
        {
            get
            {
                return Url;
            }
            set
            {

            }
        }

        public string Str
        {
            get
            {
                return _str;
            }
        }

        // получать чтмл
        // тру - успешло, фалс - ошибка
        public bool DownLoadHtml(string adress, List<string> goodUrlsList)
        {
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
            //29.00 
            if (string.IsNullOrEmpty(_html))
                throw new ParserException("Код не был загружен. Сначала выполните Download Html");

            // 47.39,  написав 3 метода
            TextSearcher ts = new TextSearcher(_html);

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip("<td width=\"*\" style=\"padding-left: 20px; padding-right: 26px; padding-top: 14px; padding-bottom: 80px; \">");

            ts.Skip("<a class=\"h1\"");
            ts.Skip("/\">");
            //ts.GoTo("\">");

            string title = ts.ReadTo("</a>");


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

        public bool FindPhone()
        {
            //29.00 
            if (string.IsNullOrEmpty(_html))
                throw new ParserException("Код не был загружен. Сначала выполните Download Html");

            // 47.39,  написав 3 метода
            TextSearcher ts = new TextSearcher(_html);

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip(">Телефон<");
            ts.Skip("color:#727596;\">");
            string phone = ts.ReadTo("</td>");

            try
            {
                _phone = phone;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool FindFax()
        {
            //29.00 
            if (string.IsNullOrEmpty(_html))
                throw new ParserException("Код не был загружен. Сначала выполните Download Html");

            // 47.39,  написав 3 метода
            TextSearcher ts = new TextSearcher(_html);

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip(">Факс<");
            ts.Skip("color:#727596;\">");
            string fax = ts.ReadTo("</td>");

            try
            {
                _fax = fax;
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool FindAdress()
        {
            //29.00 
            if (string.IsNullOrEmpty(_html))
                throw new ParserException("Код не был загружен. Сначала выполните Download Html");

            // 47.39,  написав 3 метода
            TextSearcher ts = new TextSearcher(_html);

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip(">Адрес<");
            ts.Skip("color:#727596;\">");
            string adress = ts.ReadTo("</td>");


            try
            {
                _adress = adress;
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool FindEmail()
        {
            //29.00 
            if (string.IsNullOrEmpty(_html))
                throw new ParserException("Код не был загружен. Сначала выполните Download Html");

            // 47.39,  написав 3 метода
            TextSearcher ts = new TextSearcher(_html);

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip(">E-mail:<");
            ts.Skip("color:#727596;\">");
            string email = ts.ReadTo("</td>");


            try
            {
                _email = email;
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool FindSite()
        {
            //29.00 
            if (string.IsNullOrEmpty(_html))
                throw new ParserException("Код не был загружен. Сначала выполните Download Html");

            // 47.39,  написав 3 метода
            TextSearcher ts = new TextSearcher(_html);

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip(">Сайт:<");
            ts.Skip("color:#727596;\">");
            string site = ts.ReadTo("</td>");

            try
            {
                _site = site;
                return true;
            }
            catch
            {
                return false;
            }
        }


        public string FindString()
        {
            if (string.IsNullOrEmpty(_html))
                throw new ParserException("Код не был загружен. Сначала выполните Download Html");

            // 47.39,  написав 3 метода
            TextSearcher ts = new TextSearcher(_html);

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip("<td width=\"*\" style=\"padding-left: 20px; padding-right: 26px; padding-top: 14px; padding-bottom: 80px; \">");

            ts.Skip("<a class=\"h1\"");
            ts.Skip("/\">");
            //ts.GoTo("\">");

            string title = ts.ReadTo("</a>");


            try
            {
                _title = title;
            }
            catch
            {
            }

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip(">Телефон<");
            ts.Skip("color:#727596;\">");
            string phone = ts.ReadTo("</td>");

            try
            {
                _phone = phone;
            }
            catch
            {
            }

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip(">Факс<");
            ts.Skip("color:#727596;\">");
            string fax = ts.ReadTo("</td>");

            try
            {
                _fax = fax;
            }
            catch
            {
            }

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip(">Адрес<");
            ts.Skip("color:#727596;\">");
            string adress = ts.ReadTo("</td>");

            try
            {
                _adress = adress;
            }
            catch
            {
            }

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip(">E-mail:<");
            ts.Skip("color:#727596;\">");
            string email = ts.ReadTo("</td>");

            try
            {
                _email = email;
            }
            catch
            {
            }

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip(">Сайт:<");
            ts.Skip("color:#727596;\">");
            string site = ts.ReadTo("</td>");

            try
            {
                _site = site;
            }
            catch
            {
            }

            _str = _title + ";" + _phone + ";" + _fax + ";" + _adress + ";" + _email + ";" + _site + ";";
            return _str;
        }
    }
}
