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
    public class TIPO_CONSULTAController : Controller
    {

        #region Header

        private readonly AppCareClinicMedContext _context;

        public TIPO_CONSULTAController(AppCareClinicMedContext context)
        {
            _context = context;
        }

        #endregion

        #region Get and Details

        // GET: TIPO_CONSULTA
        public async Task<IActionResult> Index()
        {
            return View(await _context.TIPO_CONSULTA.ToListAsync());
        }

        // GET: TIPO_CONSULTA/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIPO_CONSULTA = await _context.TIPO_CONSULTA
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tIPO_CONSULTA == null)
            {
                return NotFound();
            }

            return View(tIPO_CONSULTA);
        }

        #endregion

        #region Create / Post

        // GET: TIPO_CONSULTA/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TIPO_CONSULTA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] TIPO_CONSULTA tIPO_CONSULTA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tIPO_CONSULTA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tIPO_CONSULTA);
        }

        #endregion

        #region Edit / Put

        // GET: TIPO_CONSULTA/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIPO_CONSULTA = await _context.TIPO_CONSULTA.FindAsync(id);
            if (tIPO_CONSULTA == null)
            {
                return NotFound();
            }
            return View(tIPO_CONSULTA);
        }

        // POST: TIPO_CONSULTA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] TIPO_CONSULTA tIPO_CONSULTA)
        {
            if (id != tIPO_CONSULTA.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tIPO_CONSULTA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TIPO_CONSULTAExists(tIPO_CONSULTA.Id))
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
            return View(tIPO_CONSULTA);
        }

        #endregion

        #region Delete

        // GET: TIPO_CONSULTA/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIPO_CONSULTA = await _context.TIPO_CONSULTA
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tIPO_CONSULTA == null)
            {
                return NotFound();
            }

            return View(tIPO_CONSULTA);
        }

        // POST: TIPO_CONSULTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tIPO_CONSULTA = await _context.TIPO_CONSULTA.FindAsync(id);
            _context.TIPO_CONSULTA.Remove(tIPO_CONSULTA);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Others Methods

        private bool TIPO_CONSULTAExists(int id)
        {
            return _context.TIPO_CONSULTA.Any(e => e.Id == id);
        }

        #endregion
    }
}
