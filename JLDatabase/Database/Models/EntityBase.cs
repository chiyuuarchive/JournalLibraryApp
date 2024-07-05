using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDatabase.Database.Models
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
