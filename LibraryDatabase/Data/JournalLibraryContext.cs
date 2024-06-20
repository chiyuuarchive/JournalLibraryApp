using Microsoft.EntityFrameworkCore;
using DbJournalLibrary.Models;
using System;

namespace DbJournalLibrary.Data
{
    internal class JournalLibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects {  get; set; } 
        public DbSet<Article> Articles { get; set; }

        public string DbPath { get; }
        public JournalLibraryDbContext(string fileName = "LibraryDatabase.db")
        {
            DbPath = $"{AppDomain.CurrentDomain.BaseDirectory}{fileName}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
