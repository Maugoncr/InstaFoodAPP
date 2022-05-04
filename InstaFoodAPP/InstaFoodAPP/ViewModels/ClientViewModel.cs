using InstaFoodAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaFoodAPP.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        public Client MyClient { get; set; }

        public Tools.Crypto MyCrypto { get; set; }



        public ClientViewModel()
        {
            MyClient = new Client();
            MyCrypto = new Tools.Crypto();  

        }

        public async Task<bool> AddClient(string pName,
                                        string pLastName,
                                        string pPhone,
                                        string pEmail,
                                        string pPassword)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {


                MyClient.Name = pName;
                MyClient.LastName = pLastName;
                MyClient.Phone = pPhone;
                MyClient.Email = pEmail;

                string EncriptedPassword = MyCrypto.EncriptarEnUnSentido(pPassword);

                MyClient.Password = EncriptedPassword;

                MyClient.Strike = 0;

                bool R = await MyClient.AddNewClient();

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



        //FUNCION para validar el permiso de acceso del cliente

        public async Task<bool> ValidateClientAccess(string pEmail, string pPassword)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                string EncriptedPassword = MyCrypto.EncriptarEnUnSentido(pPassword);
                MyClient.Email = pEmail;
                MyClient.Password = EncriptedPassword;

                bool R = await MyClient.ValidateClientAccess();

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




    }
}
