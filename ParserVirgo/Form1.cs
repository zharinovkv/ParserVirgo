﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using xNet;
using ParserAvito;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ParserAvito.Proxi;
using System.Threading.Tasks;
using ParserVirgo.Searchers;

namespace ParserAvito
{
    public partial class Form1 : Form
    {
        List<string> urllist = new List<string>();
        SearcherAvitoShops saah;
        //SearcherAvito ks;
        //SearcherGdeperevesti gps;
        //List<ProductList> pl = new List<ProductList>();
        List<SearcherAvito> productList = new List<SearcherAvito>();
        
        string time = DateTime.Now.ToString("_yyyy.MM.d_HH.mm");
        List<string> goodProxiesList = new List<string>();
        List<string> url = new List<string>();
        List<string> list2 = new List<string>();

        public Form1()
        {
            InitializeComponent();
            ExecuteProxies();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        { }



        // 21.00
        // получаем список урлов
        private async Task<List<string>> Work()
        {
            List<string> list = new List<string>(); 
            int countPages = 1;
            Spyder spyder = new Spyder();

            try
            {
                //получаем кол-во страниц                
                countPages = spyder.GetCountPages();
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            try
            {
                for (int i = 1; i <= countPages; i++)
                {
                    // при присваивании переменной значения срабатывает событие в основном потоке
                    list.AddRange(Spyder.GetListings(i));
                }
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            foreach(var item in list)
            {
                textBox1.Text += item + Environment.NewLine;
            }

            MessageBox.Show("Листинг готов.");
            return list;
        }


        private void ProgressPerevod(List<string> listUrls)
        {
            string path = @"C:\Users\User\Documents\ParserVirgo\Reports\textfile_";
            System.IO.StreamWriter textFile = new System.IO.StreamWriter(path + time + ".txt");

            for (int i = 0; i < listUrls.Count; i++)
            {
                //gps = new SearcherAvito();
                string sStr = "";

                //if (Convert.ToBoolean(gps.DownLoadHtml(listUrls[i], goodProxiesList)))
                {
                    //gps.Url = listUrls[i];
                    //gps.FindTitle();
                    //gps.FindAdress();
                    //gps.FindEmail();
                    //gps.FindFax();
                    //gps.FindPhone();
                    //gps.FindSite();
                    //sStr = gps.FindString();
                    //gps.FindString();
                }

                //textFile.WriteLine(gps.Str);
                //                textFile.WriteLine(sStr);
                //textFile.WriteLineAsync(gps.Title + ";" + gps.Adress + ";" + gps.Email + ";" + gps.Fax + ";" + gps.Phone + ";" + gps.Site + ";");
                //textFile.WriteAsync(gps.Title + ";" + gps.Adress + ";" + gps.Email + ";" + gps.Fax + ";" + gps.Phone + ";" + gps.Site + ";");
                //textFile.WriteLine(gps.Title + ";" + gps.Adress + ";" + gps.Email + ";" + gps.Fax + ";" + gps.Phone + ";" + gps.Site + ";");
                //textBox2.Text += sStr + Environment.NewLine;
                //textBox2.Text += gps.Str + Environment.NewLine;

            }
            textFile.Close();
            MessageBox.Show("Парсинг готов.");
        }



        //// получаем спарсеный результат
        //private void Progress(List<string> listUrls)
        //{
        //    //string path = @"C:\Users\User\Documents\ParserVirgo\Reports\textfile_";
        //    //System.IO.StreamWriter textFile = new System.IO.StreamWriter(path + time + ".txt");

        //    for (int i = 0; i < listUrls.Count; i++)
        //    {
        //        ks = new SearcherAvito();

        //        if (Convert.ToBoolean(ks.DownLoadHtml(listUrls[i], goodProxiesList)))
        //        {
        //            //ks.Url = listUrls[i];
        //            ks.FindUrl(listUrls[i]);
        //            ks.FindTitle();
        //            ks.FindCover();
        //        }

        //        string imageName = "";

        //        if (ks.Url != null)
        //        {
        //            string[] totoProcess = ks.Url.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
        //            imageName = totoProcess[totoProcess.Length - 1] + ".png";
        //        }

        //        if (ks.Cover != null)
        //        {
        //            SaveAs saveImage = new SaveAs();
        //            saveImage.SaveImage(ks, imageName, time);
        //            ks.ImagePath = imageName;
        //            productList.Add(ks);
        //            //textFile.WriteLine("a" + i + ". " + ks.Url + ";" + ks.Title + ";" + ks.Title + ".png" + ";" + Environment.NewLine);
        //            textBox2.Text += ks.Url + "\t" + ks.Title + "\t" + imageName + Environment.NewLine;
        //        }
        //        else
        //        {
        //            ks.ImagePath = "NO IMAGE";
        //            productList.Add(ks);
        //            //textFile.WriteLine("b" + i + ". " + ks.Url + ";" + ks.Title + ";" + "No Image" + ";" + Environment.NewLine);
        //            textBox2.Text += ks.Url + "\t" + ks.Title + "\t" + "No Image" + Environment.NewLine;
        //        }
        //    }

        //    SaveAs saveAs = new SaveAs();
        //    //textFile.Close();
        //    saveAs.SaveAsCSV(productList, time);
        //    MessageBox.Show("Парсинг готов.");
        //}

        // получаем спарсеный результат
        private void Progress(List<string> listUrls)
        {
            //string path = @"C:\Users\User\Documents\ParserVirgo\Reports\textfile_";
            //System.IO.StreamWriter textFile = new System.IO.StreamWriter(path + time + ".txt");

            for (int i = 0; i < listUrls.Count; i++)
            {
                saah = new SearcherAvitoShops();

                if (Convert.ToBoolean(saah.DownLoadHtml(listUrls[i], goodProxiesList)))
                {
                    //saah.Url = listUrls[i];
                    saah.FindUrl(listUrls[i]);
                    saah.FindTitle();
                }

                string imageName = "";

                if (saah.Url != null)
                {
                    string[] totoProcess = saah.Url.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                    imageName = totoProcess[totoProcess.Length - 1] + ".png";
                }
            }

            SaveAs saveAs = new SaveAs();
            //textFile.Close();
            saveAs.SaveAsCSV(productList, time);
            MessageBox.Show("Парсинг готов.");
        }

        private async void ExecuteProxies()
        {
            PingProxi pingProxi = new PingProxi();
            List<string> goods = await pingProxi.Example();
            goodProxiesList = goods;
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
            //ProgressPerevod(list2);
        }
    }
}
