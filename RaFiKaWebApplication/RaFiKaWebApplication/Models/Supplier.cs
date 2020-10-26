using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RaFiKaWebApplication.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Display(Name = ("Supplier"))]
        public string NameSupplier { get; set; }

        [Display(Name = ("Phone"))]
        [DataType(DataType.PhoneNumber)]
        public string PhoneSupplier { get; set; }

        [Display(Name = ("Goods"))]
        public string GoodsSupplier { get; set; }
    }
}