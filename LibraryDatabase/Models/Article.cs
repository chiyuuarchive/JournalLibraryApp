using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbJournalLibrary.Models
{
    internal class Article : EntityBase
    {
        public IEEECategory Category { get; set; }
        public string Authors { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Abstract { get; set; }
        public string JournalTitle { get; set; } = null!;
        public string? VolumeNumber { get; set; }
        public string? IssueNumber { get; set; }
        public string? Pages { get; set; }
        public string? Hyperlink { get; set; }
    }
}
