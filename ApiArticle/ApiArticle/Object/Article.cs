namespace ApiArticle.Object
{
    public class Article
    {
        public Article(int Id, string Name, string Text, string Autor)
        {
            this.id = Id;
            this.name = Name;
            this.text = Text;
            this.autor = Autor;
        }

        public int id { get; set; }

        public string name { get; set; }

        public string text { get; set; }

        public string autor { get; set; }
    }
}
