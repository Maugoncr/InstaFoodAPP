using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InstaFoodAPP.Models
{
    public partial class Client
    {

        public RestRequest request { get; set; }

        const string mimetype = "application/json";

        const string contentType = "Content-Type";

        public Client()
        {
            Purchases = new HashSet<Purchase>();
        }

        public int IdClient { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Strike { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }



        public async Task<bool> AddNewClient()
        {

            bool R = false;

            try
            {
                //poner la ruta del controller

                string FinalApiRoute = CnnToAPI.ProductiorRoute + "Clients/PostClientEncriptado";  // puede que falte el /

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



        //Funcion para validar el acceso del usuario en el sistema

        public async Task<bool> ValidateClientAccess()
        {
            bool R = false;

            try
            {
                //Como esta ruta es un poco más compleja de consumir ya que lleva una funcion con nombre y ademas dos parametros
                //lo mas conveniente es formatearla por aparte y luego adjuntarla a Base URL (CnnToApi.ProductiorRoute)
                // para obtener la ruta completa
                string routeSufix = string.Format("Clients/ValidateClientLogin?pEmail={0}&pPassword={1}",
                    this.Email, this.Password);

                string FinalApiRoute = CnnToAPI.ProductiorRoute + routeSufix;
                RestClient client = new RestClient(FinalApiRoute);
                request = new RestRequest(FinalApiRoute, Method.Get);

                //agregar la info de seguridad, en este caso api key
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













    }
}
