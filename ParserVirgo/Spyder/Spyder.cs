using System;
using System.Collections.Generic;
using xNet;


// в этом классе получаем 
namespace ParserAvito
{
    public class Spyder
    {
        // 5.50 функция возвращает  значение кол-ва страниц
        public int GetCountPages()
        {
            int counterPages = 2;

            try
            {
                // получаем исходный код страницы
                using (var Request = new HttpRequest())
                {
                    // переменная для страницы
                    // указываем ссылку на страницу, в которй хранится кол-во старниц
                    string SourcePage = Request.Get(SiteSettings.url).ToString();

                    // парсим кол-во старниц
                    // функция Substrings() парсит текст, находящийся между каким-либо промежутками
                    // пояснения к [4] - 10.40 - это четвертый элемент массива
                    string [] paginagionpage = SourcePage.Substrings(SiteSettings.sourcePageSubstringsStart, SiteSettings.sourcePageSubstringsEnd);

                    counterPages = Convert.ToInt32(SourcePage.Substrings(SiteSettings.suburl + SiteSettings.sourcePageSubstringsEnd, SiteSettings.sourcePageSubstringsThree, 0)[paginagionpage.Length-1]);
                }

            }
            catch
            {

            }
            return counterPages;
        }


        public static List<string> GetListings(int Num)
        {
            List<string> url = new List<string>();

            try
            {
                using (var Request = new HttpRequest())
                {
                    string sourcePage;

                    UserAgent userAgent = new UserAgent();
                    Request.UserAgent = userAgent.userAgent();
                    Request.KeepAlive = true;

                    // это загружает ОДНУ "навигационную" страницу, в которой находятся ссылки на страницы контента (объявлений)
                    // затем, в методе Work() это выполняется в цикле, с кол-вом итераций (int Num)

                    // это шаблон для страниц Авито
                    //sourcePage = Request.Get(SiteSettings.siteurl + SiteSettings.suburl + SiteSettings.sourcePageSubstringsEnd + Num).ToString();

                    // это шаблон для страниц Гдеперевести
                    sourcePage = Request.Get(SiteSettings.siteurl + SiteSettings.suburl + SiteSettings.sourcePageSubstringsEnd + Num + "&per_page=100").ToString();

                    // переменная для хранения строк
                    // это массив, в который загружаются УРЛЫ страниц объявлений,
                    // чтобы правильно найти - надо 
                    string[] row;
                    row = sourcePage.Substrings(SiteSettings.sourcePageSubstringsFoure, SiteSettings.sourcePageSubstringsFive, 0);

                    for (int i = 1; i < row.Length; i++)
                    {
                        url.Add(SiteSettings.siteurl + row[i]);
                    }
                }
            }

            catch
            {

            }

            return url;
        }

    }
}
