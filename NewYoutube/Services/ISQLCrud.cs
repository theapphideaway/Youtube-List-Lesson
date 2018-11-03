using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewYoutube.Models;

namespace NewYoutube.Services
{
    public interface ISQLCrud
    {
        Task<IEnumerable<Person>> GetItemsAsync();
        Task<Person> GetItems(int id);
        Task AddItem(Person person);
        Task DeleteItem(Person person);
    }
}
