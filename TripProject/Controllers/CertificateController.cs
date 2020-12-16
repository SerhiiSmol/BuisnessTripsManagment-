using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TripProject.Models.DbModels;

namespace TripProject.Controllers
{
    public class CertificateController : Controller
    {
        TripMonDbContext dbContext = new TripMonDbContext();
        IEnumerable<City> cities;
        IEnumerable<Worker> workers;

        public CertificateController()
        {
            cities = dbContext.City.ToList();
            workers = dbContext.Worker.ToList();
        }
        
        public IActionResult Index()
        {

            ViewBag.CitiesList = new SelectList(cities, "Id", "Name");
            ViewBag.WorkersList = new SelectList(workers, "Id", "FirstName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Certificate sert)
        {
            try
            {
                ViewBag.CitiesList = new SelectList(cities, "Id", "Name");
                ViewBag.WorkersList = new SelectList(workers, "Id", "FirstName");

           
                dbContext.Certificate.Add(sert);
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
            ViewBag.CitiesList = new SelectList(cities, "Id", "Name");
            ViewBag.WorkersList = new SelectList(workers, "Id", "FirstName");

            if (id != null)
            {
                Certificate sert = dbContext.Certificate.FirstOrDefault(p => p.Id == id);
                if (sert != null)
                    return View(sert);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Certificate sert)
        {

            ViewBag.CitiesList = new SelectList(cities, "Id", "Name");
            ViewBag.WorkersList = new SelectList(workers, "Id", "FirstName");

            dbContext.Certificate.Update(sert);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Show");

        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            ViewBag.CitiesList = new SelectList(cities, "Id", "Name");
            ViewBag.WorkersList = new SelectList(workers, "Id", "FirstName");

            if (id != null)
            {
                Certificate sert = dbContext.Certificate.FirstOrDefault(p => p.Id == id);
                if (sert != null)
                    return View(sert);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Certificate sert = dbContext.Certificate.FirstOrDefault(p => p.Id == id);

                if (sert != null)
                {
                    dbContext.Certificate.Remove(sert);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index", "Show");
                }
            }
            return NotFound();
        }
    }
}
