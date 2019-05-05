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
    public class CLINICAController : Controller
    {

        #region Headers

        private readonly AppCareClinicMedContext _context;

        public CLINICAController(AppCareClinicMedContext context)
        {
            _context = context;
        }

        #endregion

        #region Get and Details

        // GET: CLINICA
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            var appCareClinicMedContext = _context.CLINICA.Include(c => c.Estado).Include(c => c.Pais);
            return View(await appCareClinicMedContext.ToListAsync());
        }

        // GET: CLINICA/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cLINICA = await _context.CLINICA
                .Include(c => c.Estado)
                .Include(c => c.Pais)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cLINICA == null)
            {
                return NotFound();
            }

            return View(cLINICA);
        }

        #endregion

        #region Create / Post

        // GET: CLINICA/Create
        public IActionResult Create()
        {
            ViewData["ESTADOSId"] = new SelectList(_context.ESTADOS.OrderBy(x => x.Estado), "Id", "Estado");
            ViewData["PAISId"] = new SelectList(_context.PAIS.OrderBy(x => x.Pais), "Id", "Pais");
            return View();
        }

        // POST: CLINICA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Razao_social,Nome_fantasia,Cnpj,Endereco,Numero,Bairro,Cidade,ESTADOSId,PAISId,Email")] CLINICA cLINICA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cLINICA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ESTADOSId"] = new SelectList(_context.ESTADOS.OrderBy(x => x.Estado), "Id", "Estado", cLINICA.ESTADOSId);
            ViewData["PAISId"] = new SelectList(_context.PAIS.OrderBy(x => x.Pais), "Id", "Pais", cLINICA.PAISId);
            return View(cLINICA);
        }

        #endregion

        #region Edit / Put

        // GET: CLINICA/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cLINICA = await _context.CLINICA.FindAsync(id);
            if (cLINICA == null)
            {
                return NotFound();
            }
            ViewData["ESTADOSId"] = new SelectList(_context.ESTADOS.OrderBy(x => x.Estado), "Id", "Estado", cLINICA.ESTADOSId);
            ViewData["PAISId"] = new SelectList(_context.PAIS.OrderBy(x => x.Pais), "Id", "Pais", cLINICA.PAISId);
            return View(cLINICA);
        }

        // POST: CLINICA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Razao_social,Nome_fantasia,Cnpj,Endereco,Numero,Bairro,Cidade,ESTADOSId,PAISId,Email")] CLINICA cLINICA)
        {
            if (id != cLINICA.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cLINICA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CLINICAExists(cLINICA.Id))
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
            ViewData["ESTADOSId"] = new SelectList(_context.ESTADOS.OrderBy(x => x.Estado), "Id", "Estado", cLINICA.ESTADOSId);
            ViewData["PAISId"] = new SelectList(_context.PAIS.OrderBy(x => x.Pais), "Id", "Pais", cLINICA.PAISId);
            return View(cLINICA);
        }

        #endregion

        #region Delete

        // GET: CLINICA/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cLINICA = await _context.CLINICA
                .Include(c => c.Estado)
                .Include(c => c.Pais)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cLINICA == null)
            {
                return NotFound();
            }

            return View(cLINICA);
        }

        // POST: CLINICA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cLINICA = await _context.CLINICA.FindAsync(id);
            _context.CLINICA.Remove(cLINICA);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Others Methods

        private bool CLINICAExists(int id)
        {
            return _context.CLINICA.Any(e => e.Id == id);
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
