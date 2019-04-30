using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppCareClinicMed.Controllers
{
    public class OutrosRegistrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}