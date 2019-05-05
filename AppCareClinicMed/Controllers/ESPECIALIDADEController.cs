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
    public class ESPECIALIDADEController : Controller
    {
        #region Header

        private readonly AppCareClinicMedContext _context;

        public ESPECIALIDADEController(AppCareClinicMedContext context)
        {
            _context = context;
        }

        #endregion

        #region Get and Details

        // GET: ESPECIALIDADE
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ESPECIALIDADE.ToListAsync());
        }

        // GET: ESPECIALIDADE/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eSPECIALIDADE = await _context.ESPECIALIDADE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eSPECIALIDADE == null)
            {
                return NotFound();
            }

            return View(eSPECIALIDADE);
        }

        #endregion

        #region Create / Post

        // GET: ESPECIALIDADE/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ESPECIALIDADE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] ESPECIALIDADE eSPECIALIDADE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eSPECIALIDADE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eSPECIALIDADE);
        }

        #endregion

        #region Edit / Put

        // GET: ESPECIALIDADE/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eSPECIALIDADE = await _context.ESPECIALIDADE.FindAsync(id);
            if (eSPECIALIDADE == null)
            {
                return NotFound();
            }
            return View(eSPECIALIDADE);
        }

        // POST: ESPECIALIDADE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] ESPECIALIDADE eSPECIALIDADE)
        {
            if (id != eSPECIALIDADE.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eSPECIALIDADE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ESPECIALIDADEExists(eSPECIALIDADE.Id))
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
            return View(eSPECIALIDADE);
        }

        #endregion

        #region Delete

        // GET: ESPECIALIDADE/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eSPECIALIDADE = await _context.ESPECIALIDADE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eSPECIALIDADE == null)
            {
                return NotFound();
            }

            return View(eSPECIALIDADE);
        }

        // POST: ESPECIALIDADE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eSPECIALIDADE = await _context.ESPECIALIDADE.FindAsync(id);
            _context.ESPECIALIDADE.Remove(eSPECIALIDADE);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Others Methods

        private bool ESPECIALIDADEExists(int id)
        {
            return _context.ESPECIALIDADE.Any(e => e.Id == id);
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
