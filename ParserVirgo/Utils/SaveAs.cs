using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserAvito
{
    public class SaveAs
    {
        public void SaveAsCSV(List<SearcherAvito> list, string time)
        {
            DirectoryInfo di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            string fileName = SiteSettings.suburlstr;  // for report
            string filepath = di + @"\ParserAvito\Reports\" + SiteSettings.suburlstr + time + "\\";

            FileStream toSave;
            StreamWriter sw;

            //if (!Directory.Exists(filepath))
            //{
                Directory.CreateDirectory(filepath);
            //}

            //if (File.Exists(filepath + Path.GetFileNameWithoutExtension(fileName) + ".csv"))
            //{
                toSave = new FileStream(filepath + Path.GetFileNameWithoutExtension(fileName) + ".csv", FileMode.Append);
                sw = new StreamWriter(toSave, Encoding.GetEncoding(0));
            //}

            //else
            //{
            //    toSave = new FileStream(filepath + Path.GetFileNameWithoutExtension(fileName) + ".csv", FileMode.CreateNew);
            //    sw = new StreamWriter(toSave, Encoding.GetEncoding(0));
            //}

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                if (true)
                {
                    stringBuilder.AppendLine(list[i].ToString());
                }
                else
                {
                    stringBuilder.AppendLine(list[i].ToString());
                }
            }

            sw.WriteLine(stringBuilder);

            sw.Close();
            toSave.Close();
        }

        public void SaveImage(SearcherAvito ks, string path, string time)
        {
            DirectoryInfo di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            string fileName = SiteSettings.suburlstr;  // for report
            FileInfo finfo = new FileInfo(fileName);
            string filepath = di + @"\ParserAvito\Reports\" + SiteSettings.suburlstr + time + "\\";

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            //ks.Cover.Save(filepath + path);
        }
    }
}
