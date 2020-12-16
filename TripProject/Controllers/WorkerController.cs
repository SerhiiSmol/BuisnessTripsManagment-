using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripProject.Models.DbModels;

namespace TripProject.Controllers
{
    public class WorkerController : Controller
    {
        TripMonDbContext dbContext = new TripMonDbContext();

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Worker worker)
        {
            try
            {
                dbContext.Worker.Add(worker);
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
                Worker worker = dbContext.Worker.FirstOrDefault(p => p.Id == id);
                if (worker != null)
                    return View(worker);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Worker worker)
        {

            dbContext.Worker.Update(worker);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Show");

        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Worker worker = dbContext.Worker.FirstOrDefault(p => p.Id == id);
                if (worker != null)
                    return View(worker);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Worker worker = dbContext.Worker.FirstOrDefault(p => p.Id == id);

                if (worker != null)
                {
                    dbContext.Worker.Remove(worker);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index", "Show");
                }
            }
            return NotFound();
        }

    }
}
