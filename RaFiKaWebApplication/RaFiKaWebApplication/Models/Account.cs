using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RaFiKaWebApplication.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required]
        public string NameAccount { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAccount { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public int PasswordAccount { get; set; }

        public bool isAdminAccount { get; set; }

        public ICollection<Product> WishListAccount { get; set; }
    }
}