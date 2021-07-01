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
    public class DakimakuraController : Controller
    {
        public readonly DataDbContext _db;
        public DakimakuraController(DataDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Dakimakura> objList = _db.Dakimakuras;
            foreach(var obj in objList)
            {
                obj.DakimakuraTypes = _db.DakimakuraTypes.FirstOrDefault(u => u.Id == obj.TypeId);
                obj.Brand = _db.Brands.FirstOrDefault(u => u.Id == obj.TypeId);
                obj.Country = _db.Countries.FirstOrDefault(u => u.Id == obj.TypeId);
            }
            return View(objList);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            DakimakuraVM DakimakuraVM = new DakimakuraVM()
            {
                Dakimakura = new Dakimakura(),
                DDBrand = _db.Brands.Select(i => new SelectListItem
                {
                    Text = i.BrandName,
                    Value = i.Id.ToString()
                }),
                DDCountry = _db.Countries.Select(i => new SelectListItem
                {
                    Text = i.CountryName,
                    Value = i.Id.ToString()
                }),
                DDType = _db.DakimakuraTypes.Select(i => new SelectListItem
                {
                    Text = i.TypeName,
                    Value = i.Id.ToString()
                })
            };
            return View(DakimakuraVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(DakimakuraVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Dakimakuras.Add(obj.Dakimakura);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Dakimakuras.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Dakimakuras.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Dakimakuras.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin, moderator")]
        public IActionResult Update(int? id)
        {
            DakimakuraVM DakimakuraVM = new DakimakuraVM()
            {
                Dakimakura = new Dakimakura(),
                DDBrand = _db.Brands.Select(i => new SelectListItem
                {
                    Text = i.BrandName,
                    Value = i.Id.ToString()
                }),
                DDCountry = _db.Countries.Select(i => new SelectListItem
                {
                    Text = i.CountryName,
                    Value = i.Id.ToString()
                }),
                DDType = _db.DakimakuraTypes.Select(i => new SelectListItem
                {
                    Text = i.TypeName,
                    Value = i.Id.ToString()
                })
            };
            if (id == null || id == 0)
            {
                return NotFound();
            }
            DakimakuraVM.Dakimakura = _db.Dakimakuras.Find(id);
            if (DakimakuraVM.Dakimakura == null)
            {
                return NotFound();
            }
            return View(DakimakuraVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, moderator")]
        public IActionResult Update(DakimakuraVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Dakimakuras.Update(obj.Dakimakura);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Dakimakura = await _db.Dakimakuras.Include(b=>b.Brand).Include(c=>c.Country).Include(t=>t.DakimakuraTypes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Dakimakura == null)
            {
                return NotFound();
            }
            return View(Dakimakura);
        }
    }
}
