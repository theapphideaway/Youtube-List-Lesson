using System;
using System.IO;
using NewYoutube.iOS;
using NewYoutube.Services;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLDb))]
namespace NewYoutube.iOS
{
    public class SQLDb : ISQLDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
