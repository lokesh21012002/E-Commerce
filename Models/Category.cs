using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Category
    {
        [Key]

        public int ID { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Length should be less thn 30")]
        public string? Name { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Display order must be in range 1 - 100")]

        [DisplayName("Category Order")]
        public int DisplayOrder { get; set; }

    }
}