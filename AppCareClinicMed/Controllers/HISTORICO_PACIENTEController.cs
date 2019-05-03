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
    public class HISTORICO_PACIENTEController : Controller
    {

        #region Header

        private readonly AppCareClinicMedContext _context;

        public HISTORICO_PACIENTEController(AppCareClinicMedContext context)
        {
            _context = context;
        }

        #endregion

        #region Get and Details

        // GET: HISTORICO_PACIENTE
        public async Task<IActionResult> Index()
        {
            var appCareClinicMedContext = _context.HISTORICO_PACIENTE.Include(h => h.Medico).Include(h => h.Paciente).OrderBy(x => x.Paciente.Nome);
            return View(await appCareClinicMedContext.ToListAsync());
        }

        // GET: HISTORICO_PACIENTE/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = _context.HISTORICO_PACIENTE.Find(id);
            var vPaciente = _context.PACIENTE.Find(paciente.PACIENTEId);

            var lista = _context.HISTORICO_PACIENTE.Include(h => h.Medico).Include(h => h.Paciente).Where(x => x.PACIENTEId == vPaciente.Id);

            return View(await lista.OrderBy(x => x.Data_historico).ToListAsync());
        }

        #endregion

        #region Create / Post

        // GET: HISTORICO_PACIENTE/Create
        public IActionResult Create()
        {
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE.OrderBy(x => x.Nome), "Id", "Nome");
            return View();
        }

        // POST: HISTORICO_PACIENTE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Historico,Data_historico,PACIENTEId,MEDICOId")] HISTORICO_PACIENTE hISTORICO_PACIENTE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hISTORICO_PACIENTE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO.OrderBy(x => x.Nome), "Id", "Nome", hISTORICO_PACIENTE.MEDICOId);
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE.OrderBy(x => x.Nome), "Id", "Nome", hISTORICO_PACIENTE.PACIENTEId);
            return View(hISTORICO_PACIENTE);
        }

        #endregion

        #region Edit / Put

        // GET: HISTORICO_PACIENTE/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hISTORICO_PACIENTE = await _context.HISTORICO_PACIENTE.FindAsync(id);
            if (hISTORICO_PACIENTE == null)
            {
                return NotFound();
            }
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO.OrderBy(x => x.Nome), "Id", "Nome", hISTORICO_PACIENTE.MEDICOId);
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE.OrderBy(x => x.Nome), "Id", "Nome", hISTORICO_PACIENTE.PACIENTEId);
            return View(hISTORICO_PACIENTE);
        }

        // POST: HISTORICO_PACIENTE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Historico,Data_historico,PACIENTEId,MEDICOId")] HISTORICO_PACIENTE hISTORICO_PACIENTE)
        {
            if (id != hISTORICO_PACIENTE.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hISTORICO_PACIENTE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HISTORICO_PACIENTEExists(hISTORICO_PACIENTE.Id))
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
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO.OrderBy(x => x.Nome), "Id", "Nome", hISTORICO_PACIENTE.MEDICOId);
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE.OrderBy(x => x.Nome), "Id", "Nome", hISTORICO_PACIENTE.PACIENTEId);
            return View(hISTORICO_PACIENTE);
        }

        #endregion

        #region Delete

        // GET: HISTORICO_PACIENTE/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hISTORICO_PACIENTE = await _context.HISTORICO_PACIENTE
                .Include(h => h.Medico)
                .Include(h => h.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hISTORICO_PACIENTE == null)
            {
                return NotFound();
            }

            return View(hISTORICO_PACIENTE);
        }

        // POST: HISTORICO_PACIENTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hISTORICO_PACIENTE = await _context.HISTORICO_PACIENTE.FindAsync(id);
            _context.HISTORICO_PACIENTE.Remove(hISTORICO_PACIENTE);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Others Methods

        private bool HISTORICO_PACIENTEExists(int id)
        {
            return _context.HISTORICO_PACIENTE.Any(e => e.Id == id);
        }

        #endregion
    }
}
