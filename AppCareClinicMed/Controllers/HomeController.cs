using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppCareClinicMed.Models;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices;
using AppCareClinicMed.Exceptions.ViewModel;
using AppCareClinicMed.Data;

namespace AppCareClinicMed.Controllers {
    public class HomeController : Controller {

        [NoDirectAccess]
        public IActionResult Index() {

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
