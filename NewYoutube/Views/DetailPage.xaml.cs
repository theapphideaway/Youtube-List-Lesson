using System;
using System.Collections.Generic;
using NewYoutube.Models;
using NewYoutube.ViewModels;
using Xamarin.Forms;

namespace NewYoutube.Views
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(DetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
