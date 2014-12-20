using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketPrice.Models
{
    public class Commodity : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Unit of Sale")]
        public string UnitOfSale { get; set; }
    }
}