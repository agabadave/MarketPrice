using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarketPrice.Models
{
    public class VendorCommodity : BaseEntity
    {
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }

        public Vendor Vendor { get; set; }

        [Display(Name = "Select Commodity")]
        [ForeignKey("Commodity")]
        public int CommodityId { get; set; }

        public virtual Commodity Commodity { get; set; }

        [Required]
        public double Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}")]
        public DateTime CreatedOn { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}")]
        public DateTime LastModified { get; set; }
    }
}