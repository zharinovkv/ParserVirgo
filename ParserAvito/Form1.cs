using System;
using System.Windows.Forms;
using ParserAvito;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParserAvito.Spyder;
using ParserAvito.Phone;

namespace ParserAvito
{
    public partial class Form1 : Form
    {
        List<string> urllist = new List<string>();
        SearcherAvito ks;
        List<SearcherAvito> productList = new List<SearcherAvito>();
        public string AvitoUrl { get; set; } = "https://m.avito.ru";


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

        

        // получаем спарсеный результат
        private void Progress()
        {
            
            string filePath1 = @"D:\avito\rezult3.txt";
            string filePath2 = @"D:\avito\referer.txt";
            string filePath3 = @"D:\avito\useragent.txt";
            string filePath4 = @"D:\avito\proxi.txt";
            Request request = new Request();
            string[] file1 = request.CreateArray(filePath1);
            string[] file2 = request.CreateArray(filePath2);
            string[] file3 = request.CreateArray(filePath3);
            string[] file4 = request.CreateArray(filePath4);
            Request[] listRequest = request.CreateListRequest(file1, file2, file3, file4);

            ParserPhone parserPhone = new ParserPhone();
            parserPhone.ParseArticles(listRequest);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Progress();
        }

        private async void button3_Click(object sender, EventArgs e)
        {

        }
    }
}


