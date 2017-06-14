using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserAvito
{
    public class Request
    {
        string url;
        string urlreferer;
        string useragent;
        string proxiip;

        public string Url { get; set; }
        public string UrlReferer { get; set; }
        public string UserAgent { get; set; }
        public string ProxyIP { get; set; }

        public Request()
        {
            Url = url;
            UrlReferer = urlreferer;
            UserAgent = useragent;
            ProxyIP = proxiip;
        }

        public Request(string url, string urlreferer, string useragent, string proxiip)
        {
            Url = url;
            UrlReferer = urlreferer;
            UserAgent = useragent;
            ProxyIP = proxiip;
        }


        public string[] CreateArray(string filePath)
        {
            string[] file;

            using (var sr = new StreamReader(filePath, Encoding.GetEncoding(1251)))
            {
                file = sr.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.None);
            }

            return file;
        }


        public Request[] CreateListRequest(string[] uri, string[] referer, string[] useragent, string[] proxilist)
        {
            Request[] listRequest = new Request[uri.Length];

            for (int i = 0; i < listRequest.Length; i++)
            {
                listRequest[i] = new Request(uri[i], referer[i], useragent[i], proxilist[i]);
            }
            return listRequest;
        }
       


        /**
         * создать массив урлов
         * создть массив рефереров
         * создать массив юзерагентов
         * создать массив Проксей         * 
         * 
         * создать матод формирования массива объеко Запросов
         * метод получет 4 массива
         * 
         * для каждого из масиво, если они меньше массива урлов,
         * создать новые массивы рефереров, юзерагентов и прокси, 
         * равные массиву урлов
         * 
         * создает массив объектов ллиной == массиву урлов
         * создает объекты, записывая в них значение по индексу,      * 
         * 
         */

    }
}
