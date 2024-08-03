namespace JLDatabase.Database.Models
{
    public class ArticleDownloadLog
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public DateTime DownloadDateTime { get; set; }
    }
}