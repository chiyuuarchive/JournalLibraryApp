using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDatabase.Database.Models
{
    public class Article : EntityBase
    {
        public IEEECategory Category { get; set; }
        public string Author { get; set; } = null!;
        public string ArticleTitle { get; set; } = null!;
        public string? Abstract { get; set; }
        public string JournalTitle { get; set; } = null!;
        public string Hyperlink { get; set; } = null!;

        public void Copy(Article other)
        {
            RegisteredAt = other.RegisteredAt;
            Category = other.Category;
            Author = other.Author;
            ArticleTitle = other.ArticleTitle;
            Abstract = other.Abstract;
            JournalTitle = other.JournalTitle;
            Hyperlink = other.Hyperlink;
        }
    }
}
