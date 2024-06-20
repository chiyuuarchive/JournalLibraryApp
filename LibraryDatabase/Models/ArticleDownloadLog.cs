using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbJournalLibrary.Models
{
    internal class ArticleDownloadLog
    {
        public Article Article { get; set; } = null!;
        public DateTime DownloadDateTime { get; set; }
    }
}
