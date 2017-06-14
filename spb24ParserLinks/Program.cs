using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using xNet;

namespace spb24ParserLinks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listUrls = new List<string>();

            string[] getArrSectionPagesNames = GetArrSectionPagesNames();

            foreach (var item in getArrSectionPagesNames)
            {
                string html = File.ReadAllText(item);
                string []str = GetLinks(html, item);
                listUrls.AddRange(str);
            }

            Console.WriteLine(listUrls.Count);

            var selectedTeams = from t in listUrls // определяем каждый объект из teams как t
                                where t.Contains(".spb24.net")                                
                                orderby t  // упорядочиваем по возрастанию
                                select t.Distinct().ToString(); // выбираем объект

            Console.WriteLine(selectedTeams.Count());

            //string time = DateTime.Now.ToString();
            string path = @"D:\Web\spb24.net_companies_\spb24.net\resultUrls.txt";
            File.AppendAllLines(path, listUrls);

            Console.ReadKey();
        }

        private static string[] GetArrSectionPagesNames()
        {
            string[] dirs = new string [] { };

            try
            {
                // Only get files that begin with the letter "c."
                dirs = Directory.GetFiles(@"D:\Web\spb24.net_companies_\spb24.net\companies", "section22*");
                Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                }

                Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            return dirs;
        }



        public static string[] GetLinks(string sourcePage, string path)
        {
            try
            {
                string[] link = new string[] { };
                //string refer = "";

                                           // <td align=left width=95%><b><a href="
                link = FindField(sourcePage, "<td align=left width=95%><b><a href=\"", "/\">", 0);
                //refer = path;

                string[] str = new string[link.Length];

                for (int i = 0; i < link.Length; i++)
                {
                    str[i] = link[i]/* + ";" + refer*/;
                }

                return str;
            }

            catch (Exception e)
            {
                Console.WriteLine("Ссылка в файле не найдена: {0}", e.ToString());
            }

            string[] s = new string[] { };
            return s;
        }


        static string[] FindField(string SourcePage, string start, string end, int x)
        {
            string [] y = SourcePage.Substrings(start, end, x);

            return y;
        }


    }
}
