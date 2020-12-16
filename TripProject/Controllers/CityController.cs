using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TripProject.Models.DbModels;

namespace TripProject.Controllers
{
    public class CityController : Controller
    {
        TripMonDbContext dbContext = new TripMonDbContext();
        IEnumerable<Citytype> types;
        public CityController()
        {
            types = dbContext.Citytype.ToList();

        }
        public IActionResult Index()
        {
            ViewBag.CityTypeList = new SelectList(types, "Id", "Type");

            return View();
        }

     


        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            try
            {
                city.Type = dbContext.Citytype.FirstOrDefault(c => c.Id == city.TypeId);
               
                string name = city.Type.Type;
                dbContext.City.Add(city);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {

                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.CityTypeList = new SelectList(types, "Id", "Type");

            if (id != null)
            {
                City city = dbContext.City.FirstOrDefault(p => p.Id == id);
                if (city != null)
                    return View(city);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(City city)
        {

            ViewBag.CityTypeList = new SelectList(types, "Id", "Type");

            dbContext.City.Update(city);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Show");

        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            ViewBag.CityTypeList = new SelectList(types, "Id", "Type");

            if (id != null)
            {
                City city = dbContext.City.FirstOrDefault(p => p.Id == id);
                if (city != null)
                    return View(city);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                City city = dbContext.City.FirstOrDefault(p => p.Id == id);

                if (city != null)
                {
                    dbContext.City.Remove(city);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index", "Show");
                }
            }
            return NotFound();
        }
    }
}
