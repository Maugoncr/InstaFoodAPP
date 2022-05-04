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
    public partial class LoginClientPage : ContentPage
    {

        ClientViewModel vm;

        public LoginClientPage()
        {
            InitializeComponent();
            BindingContext = vm = new ClientViewModel();

        }

        private void CmdSeePassword(object sender, ToggledEventArgs e)
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

        // verifica los datos para ver si deja entrar al usuario
        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if (TxtUserName.Text != null && TxtPassword.Text != null)
            {

                bool R = await vm.ValidateClientAccess(TxtUserName.Text.Trim(), TxtPassword.Text.Trim());

                if (R)
                {

                    //TODO quitar este mensaje luego
                    //await DisplayAlert(":)", "Correct User", "OK");

                    await Navigation.PushAsync(new SeeProductsListPage());

                }
                else
                {
                    await DisplayAlert("!", "Incorrect User or Password!", "OK");
                    TxtPassword.Focus();

                }
            }
            else {
                await DisplayAlert("!", "You have to send information!", "OK");
            }



           
        }
    
        //abre la vista para agregar clientes
        private async void CmdClientRegister(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientRegisterPage());
        }



    }
}