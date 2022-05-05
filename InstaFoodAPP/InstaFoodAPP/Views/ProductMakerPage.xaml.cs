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
    public partial class ProductMakerPage : ContentPage
    {
        ProductViewModel Vm;

        public ProductMakerPage()
        {
            InitializeComponent();
            BindingContext = Vm = new ProductViewModel();

        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            int parsedprice;
            parsedprice = int.Parse(TxtPrice.Text);



            bool R = await Vm.AddProduct(TxtName.Text.Trim(),
            parsedprice,
            TxtDetail.Text.Trim(),
            TxtImgUrl.Text.Trim());



            if (R)
            {
                await DisplayAlert("Added", "The product was added", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Product not added", "OK");
            }
        }
    }
}