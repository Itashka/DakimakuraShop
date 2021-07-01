using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.ViewModels
{
    public class OrderVM
    {
        public Order Order { get; set; }
        public IEnumerable<SelectListItem> DDDakimakura { get; set; }
        public IEnumerable<SelectListItem> DDUser { get; set; }
    }
}
