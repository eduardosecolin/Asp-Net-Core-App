using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;
using AppCareClinicMed.Exceptions.ViewModel;
using System.Diagnostics;
using AppCareClinicMed.Data;

namespace AppCareClinicMed.Controllers
{
    public class CONVENIOController : Controller
    {
        #region Header

        private readonly AppCareClinicMedContext _context;

        public CONVENIOController(AppCareClinicMedContext context)
        {
            _context = context;
        }

        #endregion

        #region Get and Details

        // GET: CONVENIO
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CONVENIO.ToListAsync());
        }

        // GET: CONVENIO/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cONVENIO = await _context.CONVENIO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cONVENIO == null)
            {
                return NotFound();
            }

            return View(cONVENIO);
        }

        #endregion

        #region Create / Post

        // GET: CONVENIO/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] CONVENIO cONVENIO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cONVENIO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cONVENIO);
        }

        #endregion

        #region Edit / Put

        // GET: CONVENIO/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cONVENIO = await _context.CONVENIO.FindAsync(id);
            if (cONVENIO == null)
            {
                return NotFound();
            }
            return View(cONVENIO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] CONVENIO cONVENIO)
        {
            if (id != cONVENIO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cONVENIO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CONVENIOExists(cONVENIO.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cONVENIO);
        }

        #endregion

        #region Delete

        // GET: CONVENIO/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cONVENIO = await _context.CONVENIO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cONVENIO == null)
            {
                return NotFound();
            }

            return View(cONVENIO);
        }

        // POST: CONVENIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cONVENIO = await _context.CONVENIO.FindAsync(id);
            _context.CONVENIO.Remove(cONVENIO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Others Methods

        private bool CONVENIOExists(int id)
        {
            return _context.CONVENIO.Any(e => e.Id == id);
        }

        public IActionResult Error(string message) {
            var viewModel = new ErrorViewModel {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

        #endregion
    }
}
