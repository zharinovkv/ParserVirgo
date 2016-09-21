namespace ParserAvito.Phone
{
    public partial class Articles
    {
        public string Url { get; set; }
        public string Phone { get; set; }
    }
}


/** как вызвать парсер  
 * 
 *          Parser parser = Parser.Instance;
            parser.ParseAll("https://m.avito.ru/urus-martan/oborudovanie_dlya_biznesa", 0);
**/ 