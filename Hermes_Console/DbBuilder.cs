public static class DbBuilder {
        /// <summary>
        /// Creates App data folder and reportDb.db for Hermes if they don't exist.
        /// </summary>
        /// <returns>return true if the db file had to be created. False otherwise.</returns>
        public static bool SetupSqlite()
        {
            if (!Directory.Exists(ReportContext.DirPath)) Directory.CreateDirectory(ReportContext.DirPath);
            if (!File.Exists(ReportContext.SqliteDbPath))
            {

                string sourcePath = Path.Combine(AppContext.BaseDirectory, "ReportDb.db");
                File.Copy(sourcePath, ReportContext.SqliteDbPath);
                return true;
            }
            return false;
        }
}