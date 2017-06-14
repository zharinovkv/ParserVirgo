using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spb24Parser
{
    public class ParserException : Exception
    {
        public ParserException(string message)
            : base(message)
        { }
    }

    // класс поиск
    // делает всю рабту - поиск, обработка, картинка

    public class Searcher
    {
        // полученный html
        private string _html;

        // поля
        private string _title;
        private string _about; //
        private string _service; //
        private string _napravlenie; //
        private string _podkategory; //
        private string _sity; //
        private string _adress;
        private string _phone;
        private string _email;
        private string _site;
        private string _contactPerson;

        private string stringResult;

        // свойства
        public string Title
        {
            get
            {
                return _title;
            }
        }
        public string About
        {
            get
            {
                return _about;
            }
        }
        public string Service
        {
            get
            {
                return _service;
            }
        }
        public string Napravlenie
        {
            get
            {
                return _napravlenie;
            }
        }
        public string Podkategory
        {
            get
            {
                return _podkategory;
            }
        }

        public string Sity
        {
            get
            {
                return _sity;
            }
        }
        public string Adress
        {
            get
            {
                return _adress;
            }
        }
        public string Phone
        {
            get
            {
                return _phone;
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
        public string ContactPerson
        {
            get
            {
                return _contactPerson;
            }
        }

        // методы
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
        public bool FindAbout()
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

            string about = ts.ReadTo("</a>");

            try
            {
                _about = about;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool FindService()
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

            string service = ts.ReadTo("</a>");

            try
            {
                _service = service;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool FindNapravlenie()
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

            string napravlenie = ts.ReadTo("</a>");

            try
            {
                _napravlenie = napravlenie;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool FindPodkategory()
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

            string podkategory = ts.ReadTo("</a>");

            try
            {
                _podkategory = podkategory;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool FindSity()
        {
            //29.00 
            if (string.IsNullOrEmpty(_html))
                throw new ParserException("Код не был загружен. Сначала выполните Download Html");

            // 47.39,  написав 3 метода
            TextSearcher ts = new TextSearcher(_html);

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip(">Факс<");
            ts.Skip("color:#727596;\">");

            string sity = ts.ReadTo("</td>");

            try
            {
                _sity = sity;
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
        public bool FindContactPerson()
        {
            //29.00 
            if (string.IsNullOrEmpty(_html))
                throw new ParserException("Код не был загружен. Сначала выполните Download Html");

            // 47.39,  написав 3 метода
            TextSearcher ts = new TextSearcher(_html);

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip(">Телефон<");
            ts.Skip("color:#727596;\">");

            string contactPerson = ts.ReadTo("</td>");

            try
            {
                _contactPerson = contactPerson;
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
            ts.Skip("<td width=\"*\" style=\"padding-left: 20px; padding-right: 26px; padding-top: 14px; padding-bottom: 80px; \">");
            ts.Skip("<a class=\"h1\"");
            ts.Skip("/\">");
            //ts.GoTo("\">");
            string about = ts.ReadTo("</a>");
            try
            {
                _about = about;
            }
            catch
            {
            }

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip("<td width=\"*\" style=\"padding-left: 20px; padding-right: 26px; padding-top: 14px; padding-bottom: 80px; \">");
            ts.Skip("<a class=\"h1\"");
            ts.Skip("/\">");
            //ts.GoTo("\">");
            string service = ts.ReadTo("</a>");
            try
            {
                _service = service;
            }
            catch
            {
            }

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip("<td width=\"*\" style=\"padding-left: 20px; padding-right: 26px; padding-top: 14px; padding-bottom: 80px; \">");
            ts.Skip("<a class=\"h1\"");
            ts.Skip("/\">");
            //ts.GoTo("\">");
            string napravlenie = ts.ReadTo("</a>");
            try
            {
                _napravlenie = napravlenie;
            }
            catch
            {
            }

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip("<td width=\"*\" style=\"padding-left: 20px; padding-right: 26px; padding-top: 14px; padding-bottom: 80px; \">");
            ts.Skip("<a class=\"h1\"");
            ts.Skip("/\">");
            //ts.GoTo("\">");
            string podkategory = ts.ReadTo("</a>");
            try
            {
                _podkategory = podkategory;
            }
            catch
            {
            }

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip(">Факс<");
            ts.Skip("color:#727596;\">");
            string sity = ts.ReadTo("</td>");

            try
            {
                _sity = sity;
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

            // пропустить текст, который является уникальной меткой для начала контента
            ts.Skip(">Сайт:<");
            ts.Skip("color:#727596;\">");
            string contactPerson = ts.ReadTo("</td>");

            try
            {
                _contactPerson = contactPerson;
            }
            catch
            {
            }

            stringResult = _title + ";" + _about + ";" + _service + ";" + _napravlenie + ";" + _podkategory + ";" + _sity + ";" + _adress + ";" + _phone + ";" + _email + ";" + _site + ";" + _contactPerson + ";";
            return stringResult;
        }

        // получать чтмл
        // тру - успешло, фалс - ошибка
        public bool DownLoadHtml(string adress)
        {
            try
            {
                _html = HtmlDownloadHelper.DownloadHtml(string.Format(adress), Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
