using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewYoutube.Services;
using NewYoutube.ViewModels;
using Xamarin.Forms;

namespace NewYoutube
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var pageService = new PageService();

            var sql = new SQLCrud(DependencyService.Get<ISQLDb>());

            BindingContext = new MainViewModel(pageService, sql);
        }
    }
}
