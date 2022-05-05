using System;
using System.Collections.Generic;
using System.Text;

namespace InstaFoodAPP.Models
{
    public partial class Purchase
    {
        public int IdPurchase { get; set; }
        public int IdProduct { get; set; }
        public int IdClient { get; set; }
        public int IdProv { get; set; }
        public int IdDistrict { get; set; }
        public int IdTown { get; set; }
        public string Adress { get; set; }
        public string Date { get; set; }
        public string Voucher { get; set; }
        public int? Cash { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual District IdDistrictNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
        public virtual Province IdProvNavigation { get; set; }
        public virtual Town IdTownNavigation { get; set; }
    }
}
