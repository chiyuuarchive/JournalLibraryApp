using Microsoft.EntityFrameworkCore;
using JLDatabase.Database.Models;

namespace JLDatabase.Database.Data
{
    public class JournalLibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleDownloadLog> ArticleDownloadLog { get; set; }

        public string DbPath { get; }
        public JournalLibraryDbContext()
        {
            DbPath = DatabasePathGenerator.DbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
