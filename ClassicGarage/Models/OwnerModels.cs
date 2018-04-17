using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassicGarage.Models
{
    public class OwnerModels
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(12, MinimumLength = 9)]
        [Display(Name = "Phone")]
        public string PhoneNum { get; set; }
        [StringLength(100)]
        public string Mail { get; set; }

        public virtual ICollection<CarModels> Cars { get; set; }
    }
}