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
    public partial class RestRegisterPage : ContentPage
    {
        RestaurantViewModel Vm;
        public RestRegisterPage()
        {
            InitializeComponent();
            BindingContext = Vm = new RestaurantViewModel();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {

            if (TxtName.Text != null && TxtProv.Text != null && TxtTown.Text != null && TxtDistrict.Text != null &&
                TxtAdress.Text != null && TxtSchedule.Text != null && TxtTelepone.Text != null &&
                TxtEmail.Text != null &&
                TxtPassword.Text != null)
            {

                int parsedprov;
                int parsedtown;
                int parseddis;
                int parsedp1;
                int parsedp2;
                int parsedp3;

                parsedprov = int.Parse(TxtProv.Text);
                parsedtown = int.Parse(TxtTown.Text);
                parseddis = int.Parse(TxtDistrict.Text);

                if (TxtPay1.Text != null && TxtPay2.Text != null && TxtPay3.Text != null)
                {
                    parsedp1 = int.Parse(TxtPay1.Text);
                    parsedp2 = int.Parse(TxtPay2.Text);
                    parsedp3 = int.Parse(TxtPay3.Text);
                }else
                {
                    parsedp1 = 0;
                    parsedp2 = 0;
                    parsedp3 = 0;
                }
                


                bool R = await Vm.AddRest(TxtName.Text.Trim(),
                    parsedprov,
                    parsedtown,
                    parseddis,
                    TxtAdress.Text.Trim(),
                    TxtSchedule.Text.Trim(),
                    TxtTelepone.Text.Trim(),
                    TxtEmail.Text.Trim(),
                    TxtPassword.Text.Trim(),
                    parsedp1,
                    TxtNumPay1.Text.Trim(),
                    parsedp2,
                    TxtNumPay2.Text.Trim(),
                    parsedp3,
                    TxtNumPay3.Text.Trim());

                if (R)
                {
                    await DisplayAlert("Good", "The Restaurant was added!", "OK");
                    await Navigation.PopAsync();

                }
                else
                {
                    await DisplayAlert("Oh no", "Something went wrong!", "OK");
                }



            }



        }
    }
}