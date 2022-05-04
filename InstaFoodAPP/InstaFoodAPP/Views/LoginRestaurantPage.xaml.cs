using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using InstaFoodAPP.ViewModels;

namespace InstaFoodAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginRestaurantPage : ContentPage
    {
        RestaurantViewModel Vm;
        public LoginRestaurantPage()
        {
            InitializeComponent();
            this.BindingContext = Vm = new RestaurantViewModel();
        }

        private void SwSeePassword_Toggled(object sender, ToggledEventArgs e)
        {

            if (SwSeePassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }

        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            bool R = await Vm.ValidateRestAccess(TxtRestMail.Text.Trim(), TxtPassword.Text.Trim());
            if (R)
            {
                await DisplayAlert("Good", "Restaurant Access Granted!", "OK");
                await Navigation.PushAsync(new ProductMakerPage());
            }
            else
            {
                await DisplayAlert("Oh no!", "Incorrect email or password!", "OK");
                TxtPassword.Focus();
            }

        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RestRegisterPage());


        }
    }
}