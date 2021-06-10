using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebJugueteria.Models
{
    public class Toy
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(0, 100)]
        public int? AgeRestriction { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Company { get; set; }
        [Required]
        [Range(0, 1000.00)]
        public decimal Price { get; set; }        
    }
}