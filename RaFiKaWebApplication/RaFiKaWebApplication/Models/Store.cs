using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RaFiKaWebApplication.Models
{
    public class Store
    {
        public int StoreId { get; set; }

        [Display(Name = "Store")]
        public string NameStore { get; set; }

        [Display(Name = "Address")]
        public string AddressStore { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneStore { get; set; }

        public ICollection<Product> ProductsStore { get; set; }
    }
}