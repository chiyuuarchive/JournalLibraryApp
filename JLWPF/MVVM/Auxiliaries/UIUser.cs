using JLDatabase.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLWPF.MVVM.Auxiliaries
{
    public class UIUser
    {
        private string _password = null!;
        private ICollection<ArticleDownloadLog>? _log;

        public bool IsVerified { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string LastTimeLoggedIn { get; set; } = null!;

        public ICollection<ArticleDownloadLog>? Log() => _log;
        public string Password() => _password;

        public string Name() => $"{FirstName} {LastName}";

        public void Copy(User user)
        {
            IsVerified = user.IsVerified;
            IsAdmin = user.IsAdmin;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            LastTimeLoggedIn = user.LastTimeLoggedIn.ToString("dd/MM/yyyy, HH:mm:ss");
            _password = user.Password;
            _log = user.Log;
        }

        public bool IsSame(UIUser other)
        {
            return IsVerified == other.IsVerified &&
                IsAdmin == other.IsAdmin &&
                FirstName == other.FirstName &&
                LastName == other.LastName &&
                Email == other.Email &&
                LastTimeLoggedIn == other.LastTimeLoggedIn &&
                _password == other._password &&
                _log == other._log;
        }
    }
}
