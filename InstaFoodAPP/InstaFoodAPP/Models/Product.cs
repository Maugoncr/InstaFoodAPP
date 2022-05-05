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
    public class Product
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";


        public Product()
        {
            Purchases = new HashSet<Purchase>();
        }

        public int IdProduct { get; set; }
        public string Name { get; set; }
        public int IdRest { get; set; }
        public int Price { get; set; }
        public string Detail { get; set; }
        public bool? Status { get; set; }
        public bool? Express { get; set; }
        public string Published { get; set; }
        public string ImgUrl { get; set; }

        public virtual Restaurant IdRestNavigation { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }



        public async Task<ObservableCollection<Product>> GetProductsList()
        {

            try
            {

                string routeSufix = string.Format("Products");

                string FinalApiRoute = CnnToAPI.ProductiorRoute + routeSufix;


                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);


                //agregar la info de seguridad, en este caso api key

                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);

                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<ObservableCollection<Product>>(response.Content);



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



        public async Task<bool> AddNewProduct()
        {
            bool R = false;

            try
            {
                string FinalApiRoute = CnnToAPI.ProductiorRoute + "Products";
                RestClient client = new RestClient(FinalApiRoute);
                request = new RestRequest(FinalApiRoute, Method.Post);
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);
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




        public async Task<List<Product>> GetNamesList()
        {

            try
            {

                string routeSufix = string.Format("Products/GetNamesList");

                string FinalApiRoute = CnnToAPI.ProductiorRoute + routeSufix;


                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);


                //agregar la info de seguridad, en este caso api key

                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);

                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<List<Product>>(response.Content);



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



    }
}
