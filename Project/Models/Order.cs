using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }

        [DisplayName("Dakimakura")]
        public int DakimakuraId { get; set; }
        [DisplayName("User")]
        public string UserId { get; set; }


        [ForeignKey("DakimakuraId")]
        public virtual Dakimakura Dakimakura { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public bool IsCart { get; set; }

        public bool IsPack { get; set; }

        public string Status { get; set; }
    }
}
