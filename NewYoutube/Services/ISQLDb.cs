using System;
using SQLite;

namespace NewYoutube.Services
{
    public interface ISQLDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
