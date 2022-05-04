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
    public partial class ClientRegisterPage : ContentPage
    {


        ClientViewModel vm;

        public ClientRegisterPage()
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

        private async void CmdVolver(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {


            bool R = await vm.AddClient(TxtName.Text.Trim(),
                                           TxtLastName.Text.Trim(),
                                           TxtPhoneNumber.Text.Trim(),
                                           TxtEmail.Text.Trim(),
                                           TxtPassword.Text.Trim());

            if (R)
            {
                await DisplayAlert("Warning", "The client was added successfully", "OK");
                await Navigation.PopAsync();

            }
            else
            {
                await DisplayAlert("Warning", "Something went wrong", "OK");
            }








        }
    }
}