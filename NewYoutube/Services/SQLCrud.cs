using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewYoutube.Models;
using SQLite;

namespace NewYoutube.Services
{
    public class SQLCrud : ISQLCrud
    {
        private SQLiteAsyncConnection _connection;

        public SQLCrud(ISQLDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Person>();
        }

        public async Task AddItem(Person person)
        {
            await _connection.InsertAsync(person);
        }

        public async Task<Person> GetItems(int id)
        {
            return await _connection.FindAsync<Person>(id);
        }

        public async Task<IEnumerable<Person>> GetItemsAsync()
        {
            return await _connection.Table<Person>().ToListAsync();
        }

        public async Task DeleteItem(Person person)
        {
            await _connection.DeleteAsync(person);
        }
    }
}
