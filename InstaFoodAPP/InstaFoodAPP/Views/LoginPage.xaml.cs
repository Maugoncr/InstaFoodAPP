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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private async void BtnRestaurante_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginRestaurantPage());

        }

        private async void BtnCliente_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginClientPage());

        }
    }


}