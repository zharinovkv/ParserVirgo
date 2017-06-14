using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using xNet;

namespace spb24ParserContent
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Web\spb24.net_companies_\spb24.net\resultUrls.txt";
            string[] file1;

            using (var sr = new StreamReader(filePath, Encoding.GetEncoding(1251)))
            {
                file1 = sr.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.None);
            }


            var listAncor = file1.Distinct<string>().ToArray<string>();



            List<string> listParser = new List<string>();

            int c = 0;
            foreach (var path in file1)
            {
                listParser.Add(GetContent(path));
                Console.WriteLine(c++);
            }


            StringBuilder sb = new StringBuilder();
            foreach (var item in listParser)
            {
                sb.Append(item).AppendLine();
            }

            string result = sb.ToString();
            string filePathResult = @"D:\Web\spb24.net_companies_\spb24.net\resultContent.txt";
            File.WriteAllText(filePathResult, result);

            Console.WriteLine("OK");
            Console.ReadKey();
        }

        public static string GetContent(string path)
        {
            string result = "";

            try
            {
                using (var Request = new HttpRequest())
                {
                    string SourcePage;

                    Request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; ru; rv:1.9.2) Gecko/20100115 Firefox/3.6 GTB7.1";
                    Request.KeepAlive = true;
                    //Request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

                    SourcePage = Request.Get(path).ToString();

                    // переменные

                    string title = "";
                    string about = "";
                    string service = "";
                    string napravlenie = "";
                    string podkategory = "";
                    string sity = "";
                    string adress = "";
                    string phone = "";
                    string email = "";
                    string site = "";
                    string contactPerson = "";                    

                    title = FindField(SourcePage, "<H1>", "</H1>", 0); 
                    about = StripHtmlTagsUsingRegex(FindField(SourcePage, "<p><b>О компании ", "</p>", 0));
                    service = StripHtmlTagsUsingRegex(FindField(SourcePage, "<p><span class=\"bold\">Предлагаемая продукция/услуги:</span><br>", "</p>", 0));
                    napravlenie = StripHtmlTagsUsingRegex(FindField(SourcePage, "<p><span class=\"bold\">Направление:</span>", "</a><br><br>", 0));
                    podkategory = StripHtmlTagsUsingRegex(FindField(SourcePage, "Подкатегории:</b><br>", "</a><br></p>", 0));
                    sity = FindField(SourcePage, "Город: ", "<br>", 0);
                    adress = FindField(SourcePage, "Адрес: ", "<br>", 0);
                    phone = FindField(SourcePage, "Телефон: ", "<br>", 0);
                    email = FindField(SourcePage, "mailto:", "?", 0);
                    site = FindField(SourcePage, "Сайт: <a href=\"http://spb24.net/goto/?url=", " target=\"_blank", 0);
                    contactPerson = FindField(SourcePage, "Контактное лицо:", "</p>", 0);

                    result = path + "||||" + title + "||||" + about + "||||" + service + "||||" + napravlenie + "||||" + podkategory + "||||" + sity + "||||" + adress + "||||" + phone + "||||" + email + "||||" + site + "||||" + contactPerson;

                    result = Regex.Replace(result, @"[\s\r\n]+", " ").Trim();
                }
            }

            catch
            {

            }

            return result;
        }


        static string StripHtmlTagsUsingRegex(string inputString)
        {
            return Regex.Replace(inputString, @"<[^>]*>", String.Empty);
        }

        static string FindField(string SourcePage, string start, string end, int x)
        {
            string y = SourcePage.Substring(start, end, x);

            if (y != null)
            {
                return y;
            }

            return "";
        }

    }
}

