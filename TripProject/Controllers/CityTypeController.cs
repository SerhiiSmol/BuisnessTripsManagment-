using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripProject.Models.DbModels;

namespace TripProject.Controllers
{
    public class CityTypeController : Controller
    {
        TripMonDbContext dbContext = new TripMonDbContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Citytype citytype)
        {
            try
            {
                dbContext.Citytype.Add(citytype);
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
            if (id != null)
            {
                Citytype citytype = dbContext.Citytype.FirstOrDefault(p => p.Id == id);
                if (citytype != null)
                    return View(citytype);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Citytype citytype)
        {

            dbContext.Citytype.Update(citytype);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Show");

        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Citytype citytype = dbContext.Citytype.FirstOrDefault(p => p.Id == id);
                if (citytype != null)
                    return View(citytype);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Citytype citytype = dbContext.Citytype.FirstOrDefault(p => p.Id == id);

                if (citytype != null)
                {
                    dbContext.Citytype.Remove(citytype);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index", "Show");
                }
            }
            return NotFound();
        }
    }
}
