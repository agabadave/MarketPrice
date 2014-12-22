using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarketPrice.Models
{
    public class Vendor : BaseEntity
    {
        [Display(Name = "Full Names")]
        [Required]
        public string FullName { get; set; }
        
        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Username { get; set; }

        public string Password { get; set; }

        [ForeignKey("Market")]
        public int MarketId { get; set; }

        public Market Market { get; set; }

        public virtual ICollection<VendorCommodity> VendorCommodities { get; set; } 
    }

    public class LoginDetail
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}