using System;
using System.Collections.Generic;
using NewYoutube.Services;
using NewYoutube.ViewModels;
using Xamarin.Forms;

namespace NewYoutube.Views
{
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage(AddItemViewModel viewModel)
        {
            InitializeComponent();

            var pageSerive = new PageService();
            var sqlCrud = new SQLCrud(DependencyService.Get<ISQLDb>());

            BindingContext = viewModel;
        }
    }
}
