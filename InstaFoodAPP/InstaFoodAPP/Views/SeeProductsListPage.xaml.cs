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
    public partial class SeeProductsListPage : ContentPage
    {

        //RestaurantViewModel Rvm;

        ProductViewModel Pvm;

        public SeeProductsListPage()
        {
            InitializeComponent();

            BindingContext = Pvm = new ProductViewModel();

            LoadList();
        }


      //  private async void LoadListRestaurants() {

       //     LstProductsList.ItemsSource = await Rvm.GetQList();
            
      //  }

        private async void LoadList()
        {

            LstProductsList.ItemsSource = await Pvm.GetQList();

        }



    }
}