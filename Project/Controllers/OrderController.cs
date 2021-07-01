using Project.Data;
using Project.Models;
using Project.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Project.Controllers
{
    public class OrderController : Controller
    {

        public readonly DataDbContext _db;

        public OrderController(DataDbContext db)
        {
            _db = db;
        }
        public readonly ApplicationDbContext _adb;

        public OrderController(ApplicationDbContext db)
        {
            _adb = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        // GET-Create
        public IActionResult Create()
        {

            OrderVM orderVM = new OrderVM()
            {
                Order = new Order(),
                DDDakimakura = _db.Dakimakuras.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                DDUser = _adb.Users.Select(i => new SelectListItem
                {
                    Text = i.UserName,
                    Value = i.Id.ToString()
                }),
            };

            return View(orderVM);
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderVM obj)
        {
            if (ModelState.IsValid)
            {
                //obj.ExpenseTypeId = 1;
                _db.Orders.Add(obj.Order);
                _db.SaveChanges();
                return RedirectToAction("Details", "Dakimakura");
            }
            return View(obj);

        }
    }
}
