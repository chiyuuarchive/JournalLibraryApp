namespace JLDatabase.Database.Models
{
    public class User : EntityBase
    {
        public bool IsAdmin { get; set; }
        public bool IsVerified { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime LastTimeLoggedIn { get; set; }
        public ICollection<ArticleDownloadLog>? Log { get; set; }

        public void Copy(User other)
        {
            RegisteredAt = other.RegisteredAt;
            IsAdmin = other.IsAdmin;
            IsVerified = other.IsVerified;
            FirstName = other.FirstName;
            LastName = other.LastName;
            Password = other.Password;
            Email = other.Email;
            LastTimeLoggedIn = other.LastTimeLoggedIn;
            Log = other.Log;
        }

        public string Name => $"{FirstName} {LastName}";
    }
}