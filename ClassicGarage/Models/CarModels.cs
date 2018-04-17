using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassicGarage.Models
{
    public class CarModels
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string Mark { get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        public int Year { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(17)]
        public string VIN { get; set; }
        public string Photo { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfPurchase { get; set; }
        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }
        public float PurchasePrice { get; set; }
        public float SalePrice { get; set; }
        public int OwnerID { get; set; }


        public virtual OwnerModels Owner { get; set; }
        public virtual ICollection<PartsModels> Parts { get; set; }
        public virtual ICollection<RepairModels> Repair { get; set; }
        //public virtual AnnouncementsModels Announcements { get; set; }
    }
}

//jesli nie dziala wywalic plik .vs