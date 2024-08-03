namespace JLDatabase.Database.Data
{
    public static class DatabasePathGenerator
    {
        public static readonly string DbPath = $"{GetSolutionDirectory()}\\JournalLibraryDb.db";

        public static string GetSolutionDirectory()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo directoryInfo = new(baseDirectory);

            while (directoryInfo.Parent != null && !File.Exists(Path.Combine(directoryInfo.FullName, "JournalLibraryApp.sln")))
                directoryInfo = directoryInfo.Parent;

            if (directoryInfo == null)
                throw new Exception("Solution file not found");

            return directoryInfo.FullName;
        }
    }
}