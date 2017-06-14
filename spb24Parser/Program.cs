using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spb24Parser
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> listAncors = new List<string>();

            string dirPath = @"D:\Мои Web Сайты\avito\2";
            string filePath = @"D:\Мои Web Сайты\avito\2\rezult2.txt";

            DirectoryInfo dir = new DirectoryInfo(dirPath);
            foreach (var item in dir.GetFiles())
            {
                Console.WriteLine(item.Name);
                string file = System.IO.File.ReadAllText(dirPath + "/" + item);

                var hrefTags = HtmlAgilityPack(file);

                var list = from ht in hrefTags
                           where ht.Contains("moskva/predlozheniya_uslug")
                           select ht;

                listAncors.AddRange(list);
                Console.WriteLine(listAncors.Count());
            }

            Console.WriteLine(listAncors.Distinct<string>().Count());

            var listAncor = listAncors.Distinct<string>();

            StringBuilder sb = new StringBuilder();
            foreach (var item in listAncor)
            {
                sb.Append(item).AppendLine();
            }

            string result = sb.ToString();
            File.WriteAllText(filePath, result);

            Console.ReadLine();
        }

        /// <summary>
        /// Extract all anchor tags using HtmlAgilityPack
        /// </summary>
        public static IEnumerable<string> HtmlAgilityPack(string Html)
        {
            HtmlDocument htmlSnippet = new HtmlDocument();
            htmlSnippet.LoadHtml(Html);

            List<string> hrefTags = new List<string>();

            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                hrefTags.Add(att.Value);
            }

            return hrefTags;
        }


    }
}
