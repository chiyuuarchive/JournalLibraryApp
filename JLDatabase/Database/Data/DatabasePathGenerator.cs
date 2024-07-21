using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDatabase.Database.Data
{
    public static class DatabasePathGenerator
    {
        public static string DbPath = $"{GetSolutionDirectory()}\\JournalLibraryDb.db";

        public static string GetSolutionDirectory()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo directoryInfo = new DirectoryInfo(baseDirectory);

            while (directoryInfo != null && !File.Exists(Path.Combine(directoryInfo.FullName, "JournalLibraryApp.sln")))
                directoryInfo = directoryInfo.Parent;

            if (directoryInfo == null)
                throw new Exception("Solution file not found");

            return directoryInfo.FullName;
        }
    }
}
