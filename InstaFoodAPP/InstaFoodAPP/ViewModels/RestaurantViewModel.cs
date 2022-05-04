using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InstaFoodAPP.Models;

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

        public async Task<bool>ValidateRestAccess(string pEmail, string pPassword)
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

        public async Task<bool> AddRest(
            string pNameRest,
            int pIdProv,
            int pIdTown,
            int pIdDistrict,
            string pAdress,
            string pSchedule,
            string pTelephone,
            string pEmail,
            string pPassword,
            int pIdPay1,
            string pNumPay1,
            int pIdPay2,
            string pNumPay2,
            int pIdPay3,
            string pNumPay3)
        {

            if (IsBusy) return false;
            IsBusy=true;

            try
            {
                MyRest.NameRest = pNameRest;
                MyRest.IdProv = pIdProv;
                MyRest.IdTown = pIdTown;
                MyRest.IdDistrict = pIdDistrict;
                MyRest.Adress= pAdress;
                MyRest.Schedule = pSchedule;
                MyRest.Telephone = pTelephone;
                MyRest.Email = pEmail;
                string EncriptedPassword = MyCrypto.EncriptarEnUnSentido(pPassword);
                MyRest.Password = EncriptedPassword;
                MyRest.IdPay1 = pIdPay1;
                MyRest.NumPay1 = pNumPay1;
                MyRest.IdPay2 = pIdPay2;
                MyRest.NumPay2 = pNumPay2;
                MyRest.IdPay3 = pIdPay3;
                MyRest.NumPay3 = pNumPay3;

                bool R = await MyRest.AddNewRest();
                return R;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy=false;
            }

        }

    }
}
