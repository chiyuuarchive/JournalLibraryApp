using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDatabase.Managers
{
    internal interface IEntityManager
    {
        void InitializeManager();
        bool Register(string[] fields);
        bool RemoveAt(string entityID);
        bool ChangeAt(object entity, string entityID);
    }
}
