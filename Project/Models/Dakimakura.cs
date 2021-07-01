using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Dakimakura
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Cost { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Brand")]
        public int BrandId { get; set; }
        [DisplayName("Страна")]
        public int CountryId { get; set; }
        [DisplayName("Type")]
        public int TypeId { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        [ForeignKey("TypeId")]
        public  DakimakuraType DakimakuraTypes { get; set; }

        [DisplayName("Аниме")]
        public string Anime { get; set; }
        [DisplayName("Размер")]
        public string Вimensions { get; set; }
        [DisplayName("Наличие")]
        public string Availability { get; set; }
        [DisplayName("Материал")]
        public string Material { get; set; }
        [DisplayName("Печать")]
        public string Print { get; set; }
        [DisplayName("Плотность ткани")]
        public string Density { get; set; }
    }
}
