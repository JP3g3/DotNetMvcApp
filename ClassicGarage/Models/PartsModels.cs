using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassicGarage.Models
{
    public class PartsModels
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int CatalogNmuber { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfPurchase { get; set; }
        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }
        public float PurchasePrice { get; set; }
        public float SalePrice { get; set; }

        public virtual CarModels Car { get; set; }
    }
}