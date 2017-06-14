using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserAvito
{
    public class SiteSettings
    {
        public static string siteurl = "https://www.avito.ru/";
        public static string suburl = "moskva/mebel_i_interer/osveschenie";
        public static string url = siteurl + suburl;
        public static string suburlstr = suburl.Replace("/", "-");
        public static string sourcePageSubstringsStart = "<a class=\"pagination-page\" href=\"/";
        public static string sourcePageSubstringsEnd = "</a>";
        public static string sourcePageSubstringsThree = "\">";
        public static string sourcePageSubstringsSecond = "?p=";

        // это нужно для поиска ссылки на страницу контента со страницы навигационной" для https://www.avito.ru/
        public static string sourcePageSubstringsFoure = "<h3 class=\"title item-description-title\"> <a class=\"item-description-title-link\" href=\"/";
        public static string sourcePageSubstringsFive = "\" title=";

        // это нужно для поиска ссылки на страницу контента со страницы навигационной" для https://m.avito.ru/
        //public static string sourcePageSubstringsFoure = "<a href=\"";
        //public static string sourcePageSubstringsFive = "\" class=\"item-link\"></a>";


    }
}
