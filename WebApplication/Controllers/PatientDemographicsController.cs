using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class PatientDemographicsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Save()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}