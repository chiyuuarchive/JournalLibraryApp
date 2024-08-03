using JLDatabase.Database.Data;
using JLDatabase.Database.Models;

namespace JLDatabase.Managers
{
    internal class UserManager : IEntityManager
    {
        private readonly List<User> _users;
        private readonly List<ArticleDownloadLog> _log;
        public ICollection<object> Entities => new List<object>(_users);
        public ICollection<ArticleDownloadLog> Log => _log;

        public UserManager()
        {
            _users = new();
            _log = new List<ArticleDownloadLog>();
            InitializeManager();
        }

        public bool ChangeAt(object newUser, string userEmailID)
        {
            try
            {
                // Find user to change
                User user = (User)newUser;
                User? userToChange = _users.SingleOrDefault(u => u.Email == userEmailID);
                if (userToChange == null) return false;

                // Update database
                using (var dbContext = new JournalLibraryDbContext())
                {
                    User u = dbContext.Users.First(u => u == userToChange);
                    u.Copy(user);
                    dbContext.SaveChanges();
                }

                // Update manager
                userToChange.Copy(user);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return true;
        }

        public void InitializeManager()
        {
            // Update user list in manager class with current database
            using var dbContext = new JournalLibraryDbContext();
            dbContext.Database.EnsureCreated();
            foreach (var userSet in dbContext.Users)
                _users.Add(userSet);

            foreach (var logSet in dbContext.ArticleDownloadLog)
                _log.Add(logSet);
        }

        public bool Register(object entity)
        {
            try
            {
                User user = (User)entity;
                // Verify unique user email
                User? sameUser = _users.SingleOrDefault(u => u.Email == user.Email);
                if (sameUser != null) return false;

                // Update database
                using (var dbContext = new JournalLibraryDbContext())
                {
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                }

                // Update manager
                _users.Add(user);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message.ToString());
            }
            return true;
        }

        public bool RemoveAt(string emailID)
        {
            try
            {
                // Find user to remove
                User? userToRemove = _users.SingleOrDefault(u => u.Email == emailID);
                if (userToRemove == null) return false;

                // Find logs related to the user to remove
                List<ArticleDownloadLog> logs = _log.Where(l => l.UserId == userToRemove.Id).ToList();

                // Update database
                using (var dbContext = new JournalLibraryDbContext())
                {
                    dbContext.Users.Remove(userToRemove);
                    dbContext.ArticleDownloadLog.RemoveRange(logs);
                    dbContext.SaveChanges();
                }

                // Update manager
                _users.Remove(userToRemove);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message.ToString());
            }

            return true;
        }
    }
}