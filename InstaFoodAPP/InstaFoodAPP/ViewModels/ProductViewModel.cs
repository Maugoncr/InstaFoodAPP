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




    }




}
