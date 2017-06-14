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
        public void SaveAsCSV(StringBuilder stringBuilder, string time)
        {
            DirectoryInfo di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            string fileName = time;  // for report
            string filepath = di + @"\ParserVirgo\Reports\ParserVirgo\";

            FileStream toSave;
            StreamWriter sw;

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            if (File.Exists(filepath + Path.GetFileNameWithoutExtension(fileName) + ".csv"))
            {
                toSave = new FileStream(filepath + Path.GetFileNameWithoutExtension(fileName) + ".csv", FileMode.Append);
                sw = new StreamWriter(toSave, Encoding.GetEncoding(0));
            }

            else
            {
                toSave = new FileStream(filepath + Path.GetFileNameWithoutExtension(fileName) + ".csv", FileMode.CreateNew);
                sw = new StreamWriter(toSave, Encoding.GetEncoding(0));
            }


            sw.WriteLine(stringBuilder);

            sw.Close();
            toSave.Close();
        }
    }
}
