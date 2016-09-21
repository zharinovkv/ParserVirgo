using System;
using System.Windows.Forms;
using ParserVirgo;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParserAvito.Spyder;

namespace ParserAvito
{
    public partial class Form1 : Form
    {
        List<string> urllist = new List<string>();
        SearcherAvito ks;
        List<SearcherAvito> productList = new List<SearcherAvito>();

        string time = DateTime.Now.ToString("_yyyy.MM.d_HH.mm");
        List<string> goodProxiesList = new List<string>();
        List<string> url = new List<string>();
        List<string> list2 = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        public void textBox1_TextChanged(object sender, EventArgs e)
        { }


        // 21.00
        // получаем список урлов
        private async Task<List<string>> Work()
        {
            List<string> list = new List<string>();
            int countPages = 1;
            CountPagesLists countPagesLists = new CountPagesLists();
            
            try
            {
                //получаем кол-во страниц                
                countPages = countPagesLists.GetCountPages();
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            GetUrlsList spyder = new GetUrlsList();

            try
            {
                for (int i = 1; i <= countPages; i++)
                {
                    // при присваивании переменной значения срабатывает событие в основном потоке
                    //list.AddRange(spyder.GetListings(i));
                }
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            foreach (var item in list)
            {
                textBox1.Text += item + Environment.NewLine;
            }

            MessageBox.Show("Листинг готов.");
            return list;
        }

        

        // получаем спарсеный результат
        private void Progress(List<string> listUrls)
        {
            //string path = @"C:\Users\User\Documents\ParserVirgo\Reports\textfile_";
            //System.IO.StreamWriter textFile = new System.IO.StreamWriter(path + time + ".txt");

            for (int i = 0; i < listUrls.Count; i++)
            {
                ks = new SearcherAvito();

                if (Convert.ToBoolean(ks.DownLoadHtml(listUrls[i], goodProxiesList)))
                {
                    //ks.Url = listUrls[i];
                    ks.FindUrl(listUrls[i]);
                    ks.FindTitle();
                    ks.FindCover();
                }

                string imageName = "";

                if (ks.Url != null)
                {
                    string[] totoProcess = ks.Url.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                    imageName = totoProcess[totoProcess.Length - 1] + ".png";
                }

                if (ks.Cover != null)
                {
                    SaveAs saveImage = new SaveAs();
                    saveImage.SaveImage(ks, imageName, time);
                    ks.ImagePath = imageName;
                    productList.Add(ks);
                    //textFile.WriteLine("a" + i + ". " + ks.Url + ";" + ks.Title + ";" + ks.Title + ".png" + ";" + Environment.NewLine);
                    textBox2.Text += ks.Url + "\t" + ks.Title + "\t" + imageName + Environment.NewLine;
                }
                else
                {
                    ks.ImagePath = "NO IMAGE";
                    productList.Add(ks);
                    //textFile.WriteLine("b" + i + ". " + ks.Url + ";" + ks.Title + ";" + "No Image" + ";" + Environment.NewLine);
                    textBox2.Text += ks.Url + "\t" + ks.Title + "\t" + "No Image" + Environment.NewLine;
                }
            }

            SaveAs saveAs = new SaveAs();
            //            textFile.Close();
            saveAs.SaveAsCSV(productList, time);
            MessageBox.Show("Парсинг готов.");
        }


        private async Task<List<string>> ExecuteProxies()
        {
            PingProxi pingProxi = new PingProxi();
            List<string> goods = await pingProxi.Example();
            return goods;
        }




        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            list2 = await Work();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Progress(list2);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            goodProxiesList = await ExecuteProxies();
        }
    }
}


