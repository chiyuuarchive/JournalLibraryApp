using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDatabase.Managers
{
    public interface IEntityManager
    {
        public ICollection<object> Entities { get; }
        void InitializeManager();
        bool Register(object entity);
        bool RemoveAt(string entityID);
        bool ChangeAt(object entity, string entityID);
    }
}
