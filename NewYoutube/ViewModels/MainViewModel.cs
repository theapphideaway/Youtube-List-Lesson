using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NewYoutube.Models;
using NewYoutube.Services;
using NewYoutube.Views;
using Xamarin.Forms;

namespace NewYoutube.ViewModels
{
    public class MainViewModel
    {
        public ICommand AddItemCommand { get; set; }
        public ICommand SelectedPersonCommand { get; set; }
        public ICommand DeletePersonCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        private IPageService _pageService;
        private ISQLCrud _sqlCrud;
        private Person _selectedPerson;
        private ObservableCollection<Person> _names;

        public MainViewModel(IPageService pageService, ISQLCrud sqlCrud)
        {
            _pageService = pageService;
            _sqlCrud = sqlCrud;

            //Uncomment if you want to test with messaging center
            //MessagingCenter.Subscribe<AddItemViewModel, Person>(this, "AddedPerson", (s, e) =>
            //{
            //    PopulateList(e);
            //});

            Names = new ObservableCollection<Person>();

            AddItemCommand = new Command(AddItems);
            SelectedPersonCommand = new Command(async () => await SelectedPersonMethod());
            DeletePersonCommand = new Command<Person>(DeleteItem);
            LoadCommand = new Command(LoadData);



            LoadCommand.Execute(null);
        }

        public async void AddItems()
        {
            //Comment out everything here except for the navigation method call if you want to use messaging center
            var viewModel = new AddItemViewModel(_pageService, _sqlCrud);

            viewModel.PersonAdded += (source, args) =>
            {
                PopulateList(args);
            };

            await _pageService.PushAsync(new AddItemPage(viewModel));
        }

        public void PopulateList(Person person)
        {
            Names.Add(new Person
            {
                Name = person.Name,
                Id = person.Id
            });
        }

        public async void DeleteItem(Person person)
        {
            Names.Remove(person);
            await _sqlCrud.DeleteItem(person);
        }

        public async void LoadData()
        {
            var people = await _sqlCrud.GetItemsAsync();
            foreach(var person in people)
            {
                Names.Add(new Person
                {
                    Name = person.Name,
                    Id = person.Id
                });
            }
        }

        public async Task SelectedPersonMethod()
        {
            var person = SelectedPerson;

            if (person != null)
            {
                var viewModel = new DetailViewModel(person);

                await _pageService.PushAsync(new DetailPage(viewModel));
            }
        }

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                SelectedPersonCommand.Execute(_selectedPerson);
            }
        }

        public ObservableCollection<Person> Names
        {
            get => _names;
            set
            {
                _names = value;
            }
        }
    }

}
