using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCareClinicMed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppCareClinicMed.Controllers
{
    public class USUARIOController : Controller
    {

        private readonly AppCareClinicMedContext _context;

        public USUARIOController(AppCareClinicMedContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(USUARIOS user) {

            var usu = await _context.USUARIOS.Where(x => x.usuario == user.usuario && x.senha == user.senha).FirstOrDefaultAsync();
            if(usu != null) {
                return RedirectToAction("Index", "Home");
            }
            else {
                TempData["ErrorLogin"] = "Usuário ou senha inválidos!";
            }
            return View();
        }
    }
}