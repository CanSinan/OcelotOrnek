namespace Article.API.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime LastUpdate { get; set; }
        public int WriterId { get; set; }

        public Article()
        {

        }

        //Constructor bir classtan nesne oluştururken içindeki değişkenlere değer atamamızı sağlar
        public Article(int Id, string Title, DateTime LastUpdate, int WriterId)
        {
            this.Id = Id;
            this.Title = Title;
            this.LastUpdate = LastUpdate;
            this.WriterId = WriterId;
        }
    }
}
