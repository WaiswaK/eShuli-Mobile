using SQLite.Net;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(eShuli.iOS.Database.DBConnection))]

namespace eShuli.iOS.Database
{
    class DBConnection : Interfaces.IDatabase
    {
        static string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
        static string libraryPath = System.IO.Path.Combine(documentsPath, "..", "Library"); // Library folder
        string dbPath = System.IO.Path.Combine(libraryPath, Core.Constant.dbName);

        public DBConnection()
        {
        }
        public SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(), dbPath, true, null, null, null, null); 
            return conn;
        }
        public async System.Threading.Tasks.Task InitializeDatabase()
        {
            if (await LocalDatabaseNotPresent(Core.Constant.dbName))
            {
                using (var db = GetConnection())
                {
                    db.CreateTable<eShuli.Database.Subject>();
                    db.CreateTable<eShuli.Database.Topic>();
                    db.CreateTable<eShuli.Database.Assignment>();
                    db.CreateTable<eShuli.Database.Attachment>();
                    db.CreateTable<eShuli.Database.Video>();
                    db.CreateTable<eShuli.Database.User>();
                    db.CreateTable<eShuli.Database.School>();
                    db.CreateTable<eShuli.Database.Book>();
                    db.CreateTable<eShuli.Database.log>();
                };
            }
            else
            {
            }
        }
        public async System.Threading.Tasks.Task<bool> LocalDatabaseNotPresent(string fileName)
        {
            if (!System.IO.File.Exists(dbPath))
                return true;
            else
                return false;
        }      
    }
}
