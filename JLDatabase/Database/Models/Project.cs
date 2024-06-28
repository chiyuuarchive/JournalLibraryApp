using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDatabase.Database.Models
{
    public class Project : EntityBase
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IEEECategory Category { get; set; }
        public ProjectStatus Status { get; set; }
        public ICollection<User> Members { get; set; } = null!;
    }
}
