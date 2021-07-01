using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class DakimakuraType
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}
