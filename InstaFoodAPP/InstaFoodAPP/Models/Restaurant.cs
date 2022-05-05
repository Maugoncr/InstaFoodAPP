using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InstaFoodAPP.Models
{
    public partial class Restaurant
    {

        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public Restaurant()
        {
            Products = new HashSet<Product>();
        }

        public int IdRest { get; set; }
        public string NameRest { get; set; }
        public int IdProv { get; set; }
        public int IdTown { get; set; }
        public int IdDistrict { get; set; }
        public string Adress { get; set; }
        public string Schedule { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdPay1 { get; set; }
        public string NumPay1 { get; set; }
        public int IdPay2 { get; set; }
        public string NumPay2 { get; set; }
        public int IdPay3 { get; set; }
        public string NumPay3 { get; set; }
        public int Strike { get; set; }
        public bool? Active { get; set; }

        public virtual District IdDistrictNavigation { get; set; }
        public virtual Pay IdPay1Navigation { get; set; }
        public virtual Pay IdPay2Navigation { get; set; }
        public virtual Pay IdPay3Navigation { get; set; }
        public virtual Province IdProvNavigation { get; set; }
        public virtual Town IdTownNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }


        


            public async Task<ObservableCollection<Restaurant>> GetRestaurantsList()
        {

            try
            {

                string routeSufix = string.Format("Restaurants");

                string FinalApiRoute = CnnToAPI.ProductiorRoute + routeSufix;


                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);


                //agregar la info de seguridad, en este caso api key

                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);

                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<ObservableCollection<Restaurant>>(response.Content);



                if (statusCode == HttpStatusCode.OK)
                {
                    return QList;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                throw;
            }
        }


        public async Task<bool> ValidateRestAccess()
        {
            bool R = false;

            try
            {
                string routeSufix = string.Format("Restaurants/ValidateRestLogin?pEmail={0}&pPassword={1}",
                this.Email, this.Password);
                string FinalApiRoute = CnnToAPI.ProductiorRoute + routeSufix;
                RestClient client = new RestClient(FinalApiRoute);
                request = new RestRequest(FinalApiRoute, Method.Get);
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);
                RestResponse response = await client.ExecuteAsync(request);
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    R = true;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
            return R;
        }


        public async Task<bool> AddNewRest()
        {

            bool R = false;

            try
            {
                //poner la ruta del controller
                string FinalApiRoute = CnnToAPI.ProductiorRoute + "Restaurants/PostRestEncriptado";  // puede que falte el /
                RestClient client = new RestClient(FinalApiRoute);
                request = new RestRequest(FinalApiRoute, Method.Post);
                //agregar la info de seguridad, en este caso api key
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);
                //serializar esta clase para pasarla en el body
                string SerializedClass = JsonConvert.SerializeObject(this);
                request.AddBody(SerializedClass, mimetype);
                //esto envia la consulta al api y recibe una respuesta que debemos leer
                RestResponse response = await client.ExecuteAsync(request);
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.Created)
                {
                    R = true;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                throw;
            }

            return R;
        }






    }
}
