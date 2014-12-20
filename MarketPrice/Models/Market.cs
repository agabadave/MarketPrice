using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketPrice.Models
{
    public class Market : BaseEntity
    {
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        public virtual ICollection<Vendor> Vendors { get; set; } 
    }
}