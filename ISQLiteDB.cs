using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppAndroidSQLite
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
