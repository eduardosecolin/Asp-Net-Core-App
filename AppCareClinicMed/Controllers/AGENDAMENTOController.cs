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
    public class AGENDAMENTOController : Controller
    {
        private readonly AppCareClinicMedContext _context;

        public AGENDAMENTOController(AppCareClinicMedContext context)
        {
            _context = context;
        }

        // GET: AGENDAMENTO
        public async Task<IActionResult> Index()
        {
            var appCareClinicMedContext = _context.AGENDAMENTO.Include(a => a.Convenio).Include(a => a.Medico).Include(a => a.Paciente).Include(a => a.Tipo_consulta);
            return View(await appCareClinicMedContext.ToListAsync());
        }

        // GET: AGENDAMENTO/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aGENDAMENTO = await _context.AGENDAMENTO
                .Include(a => a.Convenio)
                .Include(a => a.Medico)
                .Include(a => a.Paciente)
                .Include(a => a.Tipo_consulta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aGENDAMENTO == null)
            {
                return NotFound();
            }

            return View(aGENDAMENTO);
        }

        // GET: AGENDAMENTO/Create
        public IActionResult Create()
        {
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO, "Id", "Id");
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO, "Id", "Id");
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE, "Id", "Id");
            ViewData["TIPO_CONSULTAId"] = new SelectList(_context.TIPO_CONSULTA, "Id", "Id");
            return View();
        }

        // POST: AGENDAMENTO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,retorno,Data_agendamento,PACIENTEId,MEDICOId,TIPO_CONSULTAId,CONVENIOId")] AGENDAMENTO aGENDAMENTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aGENDAMENTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO, "Id", "Id", aGENDAMENTO.CONVENIOId);
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO, "Id", "Id", aGENDAMENTO.MEDICOId);
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE, "Id", "Id", aGENDAMENTO.PACIENTEId);
            ViewData["TIPO_CONSULTAId"] = new SelectList(_context.TIPO_CONSULTA, "Id", "Id", aGENDAMENTO.TIPO_CONSULTAId);
            return View(aGENDAMENTO);
        }

        // GET: AGENDAMENTO/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aGENDAMENTO = await _context.AGENDAMENTO.FindAsync(id);
            if (aGENDAMENTO == null)
            {
                return NotFound();
            }
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO, "Id", "Id", aGENDAMENTO.CONVENIOId);
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO, "Id", "Id", aGENDAMENTO.MEDICOId);
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE, "Id", "Id", aGENDAMENTO.PACIENTEId);
            ViewData["TIPO_CONSULTAId"] = new SelectList(_context.TIPO_CONSULTA, "Id", "Id", aGENDAMENTO.TIPO_CONSULTAId);
            return View(aGENDAMENTO);
        }

        // POST: AGENDAMENTO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,retorno,Data_agendamento,PACIENTEId,MEDICOId,TIPO_CONSULTAId,CONVENIOId")] AGENDAMENTO aGENDAMENTO)
        {
            if (id != aGENDAMENTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aGENDAMENTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AGENDAMENTOExists(aGENDAMENTO.Id))
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
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO, "Id", "Id", aGENDAMENTO.CONVENIOId);
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO, "Id", "Id", aGENDAMENTO.MEDICOId);
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE, "Id", "Id", aGENDAMENTO.PACIENTEId);
            ViewData["TIPO_CONSULTAId"] = new SelectList(_context.TIPO_CONSULTA, "Id", "Id", aGENDAMENTO.TIPO_CONSULTAId);
            return View(aGENDAMENTO);
        }

        // GET: AGENDAMENTO/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aGENDAMENTO = await _context.AGENDAMENTO
                .Include(a => a.Convenio)
                .Include(a => a.Medico)
                .Include(a => a.Paciente)
                .Include(a => a.Tipo_consulta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aGENDAMENTO == null)
            {
                return NotFound();
            }

            return View(aGENDAMENTO);
        }

        // POST: AGENDAMENTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aGENDAMENTO = await _context.AGENDAMENTO.FindAsync(id);
            _context.AGENDAMENTO.Remove(aGENDAMENTO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AGENDAMENTOExists(int id)
        {
            return _context.AGENDAMENTO.Any(e => e.Id == id);
        }
    }
}
