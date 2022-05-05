using InstaFoodAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace InstaFoodAPP.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public Product myP { get; set; }

        public ProductViewModel()
        {
            myP =  new Product();
        }

        public async Task<ObservableCollection<Product>> GetQList()
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
                    ObservableCollection<Product> list = new ObservableCollection<Product>();

                    list = await myP.GetProductsList();

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


        public async Task<bool> AddProduct(string pName,
                                        int pPrice,
                                        string pDetail,
                                        string pImgUrl)
        {

            if (IsBusy) return false;

            IsBusy = true;
            try
            {

                DateTime dateTime = DateTime.Now;



                string fecha = String.Format("{0:d}", DateTime.Now);

                myP.Name = pName;
                myP.IdRest = 4;
                myP.Price = pPrice;
                myP.Detail = pDetail;
                myP.Status = true;
                myP.Express = true;
                myP.Published = fecha;
                myP.ImgUrl = pImgUrl;



                bool R = await myP.AddNewProduct();



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


        public async Task<List<Product>> GetProducts()
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
                    List<Product> list = new List<Product>();

                    list = await myP.GetNamesList();

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
