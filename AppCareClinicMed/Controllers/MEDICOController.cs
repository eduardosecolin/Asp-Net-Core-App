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
    public class MEDICOController : Controller
    {
        #region Header

        private readonly AppCareClinicMedContext _context;

        public MEDICOController(AppCareClinicMedContext context)
        {
            _context = context;
        }

        #endregion

        #region Get and Details

        // GET: MEDICO
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            var appCareClinicMedContext = _context.MEDICO.Include(m => m.Especialidade);
            return View(await appCareClinicMedContext.ToListAsync());
        }

        // GET: MEDICO/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mEDICO = await _context.MEDICO
                .Include(m => m.Especialidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mEDICO == null)
            {
                return NotFound();
            }

            return View(mEDICO);
        }

        #endregion

        #region Create / Post

        // GET: MEDICO/Create
        public IActionResult Create()
        {
            ViewData["ESPECIALIDADEId"] = new SelectList(_context.ESPECIALIDADE.OrderBy(x => x.Descricao), "Id", "Descricao");
            return View();
        }

        // POST: MEDICO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Crm,ESPECIALIDADEId")] MEDICO mEDICO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mEDICO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ESPECIALIDADEId"] = new SelectList(_context.ESPECIALIDADE.OrderBy(x => x.Descricao), "Id", "Descricao", mEDICO.ESPECIALIDADEId);
            return View(mEDICO);
        }

        #endregion

        #region Edit / Put

        // GET: MEDICO/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mEDICO = await _context.MEDICO.FindAsync(id);
            if (mEDICO == null)
            {
                return NotFound();
            }
            ViewData["ESPECIALIDADEId"] = new SelectList(_context.ESPECIALIDADE.OrderBy(x => x.Descricao), "Id", "Descricao", mEDICO.ESPECIALIDADEId);
            return View(mEDICO);
        }

        // POST: MEDICO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Crm,ESPECIALIDADEId")] MEDICO mEDICO)
        {
            if (id != mEDICO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mEDICO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MEDICOExists(mEDICO.Id))
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
            ViewData["ESPECIALIDADEId"] = new SelectList(_context.ESPECIALIDADE.OrderBy(x => x.Descricao), "Id", "Descricao", mEDICO.ESPECIALIDADEId);
            return View(mEDICO);
        }

        #endregion

        #region Delete

        // GET: MEDICO/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mEDICO = await _context.MEDICO
                .Include(m => m.Especialidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mEDICO == null)
            {
                return NotFound();
            }

            return View(mEDICO);
        }

        // POST: MEDICO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mEDICO = await _context.MEDICO.FindAsync(id);
            _context.MEDICO.Remove(mEDICO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Others Methods

        private bool MEDICOExists(int id)
        {
            return _context.MEDICO.Any(e => e.Id == id);
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
