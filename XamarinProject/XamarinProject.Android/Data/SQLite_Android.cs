﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinProject.Data;
using System.IO;
using XamarinProject.Droid.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]

namespace XamarinProject.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "Test.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, sqliteFileName);

            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}