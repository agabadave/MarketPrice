using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Converters;

namespace MarketPrice.Models
{
    public class CustomDateFormat : IsoDateTimeConverter
    {
        public CustomDateFormat()
        {
            base.DateTimeFormat = "yyyy-MM-dd hh:mm:ss";
        }
    }
}