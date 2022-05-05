using InstaFoodAPP.ViewModels;
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
    public partial class buyPage : ContentPage
    {

        ProductViewModel Pvm;
        public buyPage()
        {
            InitializeComponent();

            BindingContext = Pvm = new ProductViewModel();

            LoadListRestaurants();

        }


        private async void LoadListRestaurants()
        {

            CboProduct.ItemsSource = await Pvm.GetProducts();

        }


    }
}