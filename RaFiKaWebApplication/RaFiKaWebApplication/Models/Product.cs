using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RaFiKaWebApplication.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Display(Name = ("Item"))]
        public string NameProduct { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType TypeOfProduct { get; set; }

        [Display(Name = ("Size"))]
        public int SizeProduct { get; set; }

        [Display(Name = ("Price"))]
        [DataType(DataType.Currency)]
        public double PriceProduct { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PicProduct { get; set; }

        public int SupplierId { get; set; }
        public Supplier SupplierProduct { get; set; }
    }
}