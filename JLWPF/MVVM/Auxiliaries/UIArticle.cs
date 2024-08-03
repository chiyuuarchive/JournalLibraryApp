using JLDatabase.Database.Models;

namespace JLWPF.MVVM.Auxiliaries
{
    internal class UIArticle
    {
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Journal { get; set; } = null!;
        public string RegisteredAt { get; set; } = null!;
        private string _hyperlink = null!;

        public string Key() => _hyperlink;

        public void Copy(Article a)
        {
            Category = a.Category.ToString();
            Title = a.ArticleTitle;
            Author = a.Author.ToString();
            Year = a.YearOfPublication;
            Journal = a.JournalTitle;
            RegisteredAt = a.RegisteredAt.ToString("dd/MM/yyyy, HH:mm:ss");
            _hyperlink = a.Hyperlink;
        }
    }
}