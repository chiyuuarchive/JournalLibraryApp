using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDatabase.Database.Models
{
    public class User : EntityBase
    {
        public bool IsAdmin { get; set; }
        public bool IsVerified { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;    // Future works: A boolean for email 
        public DateTime LastTimeLoggedIn { get; set; }
        public ICollection<ArticleDownloadLog>? Log { get; set; }

        public bool IsSameUser(int otherId) => Id == otherId;
        public string Name()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
