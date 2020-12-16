using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TripProject.Models.DbModels;

namespace TripProject.Controllers
{
    public class ShowController : Controller
    {
        TripMonDbContext context = new TripMonDbContext();

        public IActionResult Index()
        {
            return View(context.Worker.ToList());
        }
        public IActionResult CityTypeToList()
        {
            return View(context.Citytype.ToList());
        }
        public IActionResult CityList()
        {
            return View(context.City.ToList());
        }
        public IActionResult CertificateList()
        {
            return View(context.Certificate.ToList());
        }
    }
}
