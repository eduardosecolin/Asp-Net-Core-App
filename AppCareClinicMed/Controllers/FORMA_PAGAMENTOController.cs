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
    public class FORMA_PAGAMENTOController : Controller
    {
        #region Header

        private readonly AppCareClinicMedContext _context;

        public FORMA_PAGAMENTOController(AppCareClinicMedContext context)
        {
            _context = context;
        }

        #endregion

        #region Get and details

        // GET: FORMA_PAGAMENTO
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            return View(await _context.FORMA_PAGAMENTO.ToListAsync());
        }

        // GET: FORMA_PAGAMENTO/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fORMA_PAGAMENTO = await _context.FORMA_PAGAMENTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fORMA_PAGAMENTO == null)
            {
                return NotFound();
            }

            return View(fORMA_PAGAMENTO);
        }

        #endregion

        #region Create / Post

        // GET: FORMA_PAGAMENTO/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FORMA_PAGAMENTO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] FORMA_PAGAMENTO fORMA_PAGAMENTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fORMA_PAGAMENTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fORMA_PAGAMENTO);
        }

        #endregion

        #region Edit/ Put

        // GET: FORMA_PAGAMENTO/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fORMA_PAGAMENTO = await _context.FORMA_PAGAMENTO.FindAsync(id);
            if (fORMA_PAGAMENTO == null)
            {
                return NotFound();
            }
            return View(fORMA_PAGAMENTO);
        }

        // POST: FORMA_PAGAMENTO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] FORMA_PAGAMENTO fORMA_PAGAMENTO)
        {
            if (id != fORMA_PAGAMENTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fORMA_PAGAMENTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FORMA_PAGAMENTOExists(fORMA_PAGAMENTO.Id))
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
            return View(fORMA_PAGAMENTO);
        }

        #endregion

        #region Delete

        // GET: FORMA_PAGAMENTO/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fORMA_PAGAMENTO = await _context.FORMA_PAGAMENTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fORMA_PAGAMENTO == null)
            {
                return NotFound();
            }

            return View(fORMA_PAGAMENTO);
        }

        // POST: FORMA_PAGAMENTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fORMA_PAGAMENTO = await _context.FORMA_PAGAMENTO.FindAsync(id);
            _context.FORMA_PAGAMENTO.Remove(fORMA_PAGAMENTO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Others Methods

        private bool FORMA_PAGAMENTOExists(int id)
        {
            return _context.FORMA_PAGAMENTO.Any(e => e.Id == id);
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
