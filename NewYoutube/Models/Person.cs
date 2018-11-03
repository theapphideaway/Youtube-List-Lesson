using System;
using NewYoutube.ViewModels;
using SQLite;

namespace NewYoutube.Models
{
    public class Person
    {
        public string Name { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
