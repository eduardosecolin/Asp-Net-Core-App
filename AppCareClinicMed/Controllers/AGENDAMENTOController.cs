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
    public class AGENDAMENTOController : Controller
    {

        #region Header

        private readonly AppCareClinicMedContext _context;

        public AGENDAMENTOController(AppCareClinicMedContext context)
        {
            _context = context;
        }

        #endregion

        #region Get and Details

        // GET: AGENDAMENTO
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            try {

                var lista = _context.AGENDAMENTO.Include(a => a.Convenio).Include(a => a.Medico).Include(a => a.Paciente).Include(a => a.Tipo_consulta).Include(a => a.Forma_pagamento).Where(x => x.Data_agendamento.ToShortDateString().Equals(DateTime.Now.ToShortDateString())).ToListAsync();
                return View(await lista);

            } catch(Exception e) {

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        [NoDirectAccess]
        public async Task<IActionResult> GetAll() {

            try {

                var appCareClinicMedContext = _context.AGENDAMENTO.Include(a => a.Convenio).Include(a => a.Medico).Include(a => a.Paciente).Include(a => a.Tipo_consulta).Include(a => a.Forma_pagamento);
                return View(await appCareClinicMedContext.ToListAsync());

            }catch(Exception e) {

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        // GET: AGENDAMENTO/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var aGENDAMENTO = await _context.AGENDAMENTO
                .Include(a => a.Convenio)
                .Include(a => a.Medico)
                .Include(a => a.Paciente)
                .Include(a => a.Tipo_consulta)
                .Include(a => a.Forma_pagamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aGENDAMENTO == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Dados não encontrado!" });
            }

            return View(aGENDAMENTO);
        }

        #endregion

        #region Create / Post

        // GET: AGENDAMENTO/Create
        public IActionResult Create()
        {
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["TIPO_CONSULTAId"] = new SelectList(_context.TIPO_CONSULTA.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewData["FORMA_PAGAMENTOId"] = new SelectList(_context.FORMA_PAGAMENTO.OrderBy(x => x.Descricao), "Id", "Descricao");
            return View();
        }

        // POST: AGENDAMENTO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,retorno,Data_agendamento,PACIENTEId,MEDICOId,TIPO_CONSULTAId,CONVENIOId,FORMA_PAGAMENTOId")] AGENDAMENTO aGENDAMENTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aGENDAMENTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["TIPO_CONSULTAId"] = new SelectList(_context.TIPO_CONSULTA.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewData["FORMA_PAGAMENTOId"] = new SelectList(_context.FORMA_PAGAMENTO.OrderBy(x => x.Descricao), "Id", "Descricao");
            return View(aGENDAMENTO);
        }

        #endregion

        #region Edit / Put

        // GET: AGENDAMENTO/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var aGENDAMENTO = await _context.AGENDAMENTO.FindAsync(id);
            if (aGENDAMENTO == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Dados não encontrado!" });
            }
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["TIPO_CONSULTAId"] = new SelectList(_context.TIPO_CONSULTA.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewData["FORMA_PAGAMENTOId"] = new SelectList(_context.FORMA_PAGAMENTO.OrderBy(x => x.Descricao), "Id", "Descricao");
            return View(aGENDAMENTO);
        }

        // POST: AGENDAMENTO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,retorno,Data_agendamento,PACIENTEId,MEDICOId,TIPO_CONSULTAId,CONVENIOId, FORMA_PAGAMENTOId")] AGENDAMENTO aGENDAMENTO)
        {
            if (id != aGENDAMENTO.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
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
                        return RedirectToAction(nameof(Error), new { message = "Dados não encontrado!" });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["TIPO_CONSULTAId"] = new SelectList(_context.TIPO_CONSULTA.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewData["FORMA_PAGAMENTOId"] = new SelectList(_context.FORMA_PAGAMENTO.OrderBy(x => x.Descricao), "Id", "Descricao");
            return View(aGENDAMENTO);
        }

        #endregion

        #region Delete

        // GET: AGENDAMENTO/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var aGENDAMENTO = await _context.AGENDAMENTO
                .Include(a => a.Convenio)
                .Include(a => a.Medico)
                .Include(a => a.Paciente)
                .Include(a => a.Tipo_consulta)
                .Include(a => a.Forma_pagamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aGENDAMENTO == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Dados não encontrado!" });
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

        #endregion

        #region Others Methods

        private bool AGENDAMENTOExists(int id)
        {
            return _context.AGENDAMENTO.Any(e => e.Id == id);
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
