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
        public Tools.Crypto MyCrypto { get; set; }

        public RestaurantViewModel()
        {
            MyRest = new Restaurant();
            MyCrypto = new Tools.Crypto();
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


        public async Task<bool> ValidateRestAccess(string pEmail, string pPassword)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                string EncriptedPassword = MyCrypto.EncriptarEnUnSentido(pPassword);
                MyRest.Email = pEmail;
                MyRest.Password = EncriptedPassword;

                bool R = await MyRest.ValidateRestAccess();
                return R;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }


        public async Task<bool> AddRest(string pName,
                                       string pAdress,
                                       string pSchedule,
                                       string pPhone,
                                       string pEmail,
                                       string pPassword                           
                                       )
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {

                MyRest.NameRest = pName;
                MyRest.IdProv = 1;
                MyRest.IdTown = 1;
                MyRest.IdDistrict = 1;
                MyRest.Adress = pAdress;
                MyRest.Schedule = pSchedule;
                MyRest.Telephone = pPhone;
                MyRest.Email = pEmail;

                string EncriptedPassword = MyCrypto.EncriptarEnUnSentido(pPassword);

                MyRest.Password = EncriptedPassword;

                MyRest.IdPay1 = 1;
                MyRest.NumPay1 = "Efectivo";
                MyRest.IdPay2 = 4;
                MyRest.NumPay1 = "Sinpe";
                MyRest.IdPay3 = 3;
                MyRest.NumPay1 = "Paypal";

                bool R = await MyRest.AddNewRest();

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {

                IsBusy = false;

            }
        }



    }
}
