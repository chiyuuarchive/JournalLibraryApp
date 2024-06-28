using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDatabase.Database.Models
{
    public class ArticleDownloadLog 
    {
        public int Id { get; set; }
        public Article Article { get; set; } = null!;
        public DateTime DownloadDateTime { get; set; }
    }
}
