using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.ViewModels
{
    public class DakimakuraVM
    {
        public Dakimakura Dakimakura { get; set; }
        public IEnumerable<SelectListItem> DDCountry { get; set; }
        public IEnumerable<SelectListItem> DDBrand { get; set; }
        public IEnumerable<SelectListItem> DDType { get; set; }
    }
}
