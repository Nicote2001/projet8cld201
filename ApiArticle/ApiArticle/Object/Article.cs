namespace ApiArticle.Object
{
    public class Article
    {
        public Article(string Id, string Name, string Text, string Autor)
        {
            this.Id = Id;
            this.Name = Name;
            this.Text = Text;
            this.Autor = Autor;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Autor { get; set; }
    }
}
