using System;
using NewYoutube.Models;

namespace NewYoutube.ViewModels
{
    public class DetailViewModel
    {
        public Person PersonalDetails { get; set; }

        public DetailViewModel(Person person)
        {
            PersonalDetails = new Person
            {
                Name = person.Name,
                Id = person.Id
            };
        }
    }
}
