using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Controllers
{
    public class ESPECIALIDADEController : Controller
    {
        private readonly AppCareClinicMedContext _context;

        public ESPECIALIDADEController(AppCareClinicMedContext context)
        {
            _context = context;
        }

        // GET: ESPECIALIDADE
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

        private bool ESPECIALIDADEExists(int id)
        {
            return _context.ESPECIALIDADE.Any(e => e.Id == id);
        }
    }
}
