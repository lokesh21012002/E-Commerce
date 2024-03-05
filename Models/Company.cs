using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace MVC.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string? StreetAdrress { get; set; }

        public string? City { get; set; }
        public string? State { get; set; }

        public string? PostalCode { get; set; }

        public string? PhoneNumber { get; set; }






    }
}