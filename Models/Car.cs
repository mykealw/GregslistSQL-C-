using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Davinci.Models
{
    public class Car
    {

       public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Model { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Make { get; set; }
        [Required]
        [Range(1950, 2023)]
        public int Year { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Color { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Price { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string ImgUrl { get; set; }   
    }
}