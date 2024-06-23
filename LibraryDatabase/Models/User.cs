using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbJournalLibrary.Models
{
    internal class User : EntityBase
    {
        public bool IsAdmin { get; set; }
        public bool IsVerified { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;    // Future works: A boolean for email 
        public DateTime LastTimeLoggedIn { get; set; }
        ICollection<ArticleDownloadLog> Log { get; set; } = null!;

        public bool IsSameUser(int otherId) => Id == otherId;
        public string Name()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
