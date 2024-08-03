using JLDatabase.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace JLDatabase.Database.Data
{
    public class JournalLibraryDbContext : DbContext
    {
        public DbSet<ArticleDownloadLog> ArticleDownloadLog { get; set; }
        public DbSet<Article> Articles { get; set; }
        public string DbPath { get; }
        public DbSet<User> Users { get; set; }

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