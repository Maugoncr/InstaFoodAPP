using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InstaFoodAPP.Models
{
    public class Restaurant
    {

        public RestRequest request { get; set; }

        const string mimetype = "application/json";
        const string contentype = "Content-Type";

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

        public async Task<bool> AddNewRest()
        {
            bool R = false;

            try
            {
                string FinalApiRoute = CnnToAPI.ProductiorRoute + "restaurants";
                RestClient client = new RestClient(FinalApiRoute);
                request = new RestRequest(FinalApiRoute, Method.Post);

                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(contentype, mimetype);

                string SerializedClass = JsonConvert.SerializeObject(this);
                request.AddBody(SerializedClass, mimetype);

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
                request.AddHeader(contentype, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    R = true;
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
            return R;
        }

    }
}
