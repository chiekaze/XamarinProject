using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinProject.Data;
using System.IO;
using XamarinProject.UWP.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_UWP))]

namespace XamarinProject.UWP.Data
{
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "Test.db3";
            string documentPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(documentPath, sqliteFileName);
    
            var conn = new SQLite.SQLiteConnection(path);
    
            return conn;
        }
    }
}
