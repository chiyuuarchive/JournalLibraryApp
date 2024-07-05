using JLAuthenticationAPI;
using JLDatabase.Database.Data;
using JLDatabase.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace JLDatabase.Managers
{
    internal class UserManager : IEntityManager
    {
        EntityFactory _factory;
        ICollection<User> _users;
        User? _activeUser;

        public UserManager(EntityFactory factory)
        {
            _factory = factory;
            _users = new List<User>();
            InitializeManager();
        }

        public bool SetActiveUser(string email)
        {
            _activeUser = _users.SingleOrDefault(u => u.Email == email);
            return _activeUser != null;
        }

        #region Debug Helpers
        public void LogUsersToConsole()
        {
            foreach (var user in _users)
                Console.WriteLine(user.Name());
        }
        #endregion

        public bool ChangeAt(object updatedUser, string emailID)
        {
            try
            {
                User user = (User)updatedUser;
                User? userToChange = _users.SingleOrDefault(u => u.Email == emailID);
                if (user == null || userToChange == null) return false;

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
            using (var dbContext = new JournalLibraryDbContext())
            {
                dbContext.Database.EnsureCreated();

                foreach (var userSet in dbContext.Users)
                    _users.Add(userSet);
            }

            LogUsersToConsole();
        }

        public bool Register(string[] fields)
        {
            try
            {
                User user = _factory.CreateUser(fields);
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
                return false;
            }

            return true;
        }

        public bool RemoveAt(string emailID)
        {
            try
            {
                User? userToRemove = _users.SingleOrDefault(u => u.Email == emailID);
                if (userToRemove == null) return false;
                using (var dbContext = new JournalLibraryDbContext() )
                {
                    dbContext.Users.Remove(userToRemove);
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
