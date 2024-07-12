using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDatabase.Managers
{
    internal interface IEntityManager
    {
        public ICollection<object> Entities { get; }
        public string FailRegistrationMessage(object entity);
        public string SuccessRegistrationMessage(object entity);
        public string FailRemoveAtMessage(object entity);
        public string SuccessRemoveAtMessage(object entity);
        public string FailChangeAtMessage(object entity);
        public string SuccessChangeAtMessage(object entity);
        void InitializeManager();
        bool Register(object entity);
        bool RemoveAt(string entityID);
        bool ChangeAt(object entity, string entityID);
    }
}
