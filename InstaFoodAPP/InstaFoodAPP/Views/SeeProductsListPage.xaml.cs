﻿using InstaFoodAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstaFoodAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeeProductsListPage : ContentPage
    {

        //RestaurantViewModel Rvm;

        ProductViewModel Pvm;

        public SeeProductsListPage()
        {
            InitializeComponent();

            BindingContext = Pvm = new ProductViewModel();

            LoadList();
           // LoadListRestaurants();

        }


          

        private async void LoadList()
        {

            LstProductsList.ItemsSource = await Pvm.GetQList();

        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new buyPage());
        }
    }
}