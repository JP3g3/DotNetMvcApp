using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassicGarage.Models
{
    public class RepairModels
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Desc { get; set; }
        public float PriceOfRepair { get; set; }

        public virtual CarModels Car { get; set; }
    }
}