using InstaFoodAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace InstaFoodAPP.ViewModels
{
    public class RestaurantViewModel : BaseViewModel
    {

        public Restaurant MyRest { get; set; }


        public RestaurantViewModel()
        {
            MyRest = new Restaurant();
        }


        public async Task<ObservableCollection<Restaurant>> GetQList()
        {


            if (IsBusy)
            {
                return null;
            }
            else
            {
                IsBusy = true;

                try
                {
                    ObservableCollection<Restaurant> list = new ObservableCollection<Restaurant>();

                    list = await MyRest.GetRestaurantsList();

                    if (list == null)
                    {
                        return null;
                    }
                    else
                    {
                        return list;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }








    }
}
