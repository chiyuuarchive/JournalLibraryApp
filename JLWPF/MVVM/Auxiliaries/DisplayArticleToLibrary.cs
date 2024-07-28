using JLDatabase.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLWPF.MVVM.Auxiliaries
{
    internal class DisplayArticleToLibrary
    {
        public string Title { get; set; }
        public string Author {  get; set; }
        public string Category { get; set; }
        public string Journal {  get; set; }
        public string RegisteredAt { get; set; }
        private string _hyperlink;

        public string Key() => _hyperlink;
        public void Copy(Article a)
        {
            Category = a.Category.ToString();
            Title = a.ArticleTitle;
            Author = a.Author.ToString();
            Journal = a.JournalTitle;
            RegisteredAt = a.RegisteredAt.ToString("dd/MM/yyyy, HH:mm:ss");
            _hyperlink = a.Hyperlink;
        }

    }
}
