using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassicGarage.Models
{
    public class AnnouncementsModels
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public bool Activ { get; set; }

        public virtual CarModels Car { get; set; }
    }
}