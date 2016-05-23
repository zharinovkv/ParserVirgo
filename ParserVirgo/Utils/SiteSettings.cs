using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserVirgo
{
    public class SiteSettings
    {
        public static string siteurl = "https://www.avito.ru/";
        public static string suburl = "moskva/mebel_i_interer/osveschenie";
        public static string url = siteurl + suburl;
        public static string suburlstr = suburl.Replace("/", "-");
        public static string sourcePageSubstringsStart = "<a class=\"pagination__page\" href=\"/";
        public static string sourcePageSubstringsEnd = "?p=";
        public static string sourcePageSubstringsThree = "\">";

        // это нужно для поиска ссылки на страницу контента со страницы навигационной"
        public static string sourcePageSubstringsFoure = "<div class=\"description\"> <h3 class=\"title\"> <a href=\"/";
        public static string sourcePageSubstringsFive = "\" title=";


        //http://gdeperevesti.ru/spb/structure/Pismennyperevod/?sort=6&page=2&per_page=100

        //http://www.gdeperevesti.ru/?sort=6&page=15&per_page=100

        //public static string siteurl = "http://gdeperevesti.ru/";
        //public static string suburl = "?sort=6&page=";
        //public static string url = siteurl + suburl;
        //public static string suburlstr = suburl.Replace("/", "-");
        //public static string sourcePageSubstringsStart = "";
        //public static string sourcePageSubstringsEnd = "";
        //public static string sourcePageSubstringsThree = "";

        // это нужно для поиска ссылки на страницу контента со страницы навигационной"
        // для метода Spyder.GetListings(int Num)
        //public static string sourcePageSubstringsFoure = "text-decoration:underline;\" href=\"/";
        //public static string sourcePageSubstringsFive = "#comments\">";
    }
}
