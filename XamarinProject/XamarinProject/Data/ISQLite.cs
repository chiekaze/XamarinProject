using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinProject.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
