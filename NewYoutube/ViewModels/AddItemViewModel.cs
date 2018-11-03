using System;
using System.Windows.Input;
using NewYoutube.Models;
using NewYoutube.Services;
using Xamarin.Forms;

namespace NewYoutube.ViewModels
{
    public class AddItemViewModel
    {
        private IPageService _pageService;
        private ISQLCrud _sqlCrud;
        private string _itemEntry;
        private int count = 0;

        public event EventHandler<Person> PersonAdded;
        public ICommand AddCommand { get; set; }

        public AddItemViewModel(IPageService pageService, ISQLCrud sqlCrud)
        {
            _sqlCrud = sqlCrud;
            _pageService = pageService;
            AddCommand = new Command(AddItems);
        }

        public async void AddItems()
        {
            count++;
            var person = new Person
            {
                Name = ItemEntry,
                Id = count
            };

            await _sqlCrud.AddItem(person);


            //Uncomment if you want to test with message center, But remember to comment out the event handler!
            //MessagingCenter.Send(this, "AddedPerson", person);



            PersonAdded?.Invoke(this, person);

            await _pageService.PopAsync();

        }

        public string ItemEntry
        {
            get => _itemEntry;
            set => _itemEntry = value;
        }

    }
}
