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

        #region Header

        private readonly AppCareClinicMedContext _context;

        public AGENDAMENTOController(AppCareClinicMedContext context)
        {
            _context = context;
        }

        #endregion

        #region Get and Details

        // GET: AGENDAMENTO
        public async Task<IActionResult> Index()
        {
            //var appCareClinicMedContext = _context.AGENDAMENTO.Include(a => a.Convenio).Include(a => a.Medico).Include(a => a.Paciente).Include(a => a.Tipo_consulta).OrderBy(x => x.Data_agendamento.ToShortDateString() == DateTime.Now.ToShortDateString());
            var lista =  _context.AGENDAMENTO.Include(a => a.Convenio).Include(a => a.Medico).Include(a => a.Paciente).Include(a => a.Tipo_consulta).Where(x => x.Data_agendamento.ToShortDateString().Equals(DateTime.Now.ToShortDateString())).ToListAsync();
            return View(await lista);

        }

        public async Task<IActionResult> GetAll() {
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

        #endregion

        #region Create / Post

        // GET: AGENDAMENTO/Create
        public IActionResult Create()
        {
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["TIPO_CONSULTAId"] = new SelectList(_context.TIPO_CONSULTA.OrderBy(x => x.Descricao), "Id", "Descricao");
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
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["TIPO_CONSULTAId"] = new SelectList(_context.TIPO_CONSULTA.OrderBy(x => x.Descricao), "Id", "Descricao");
            return View(aGENDAMENTO);
        }

        #endregion

        #region Edit / Put

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
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["TIPO_CONSULTAId"] = new SelectList(_context.TIPO_CONSULTA.OrderBy(x => x.Descricao), "Id", "Descricao");
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
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewData["MEDICOId"] = new SelectList(_context.MEDICO.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["PACIENTEId"] = new SelectList(_context.PACIENTE.OrderBy(x => x.Nome), "Id", "Nome");
            ViewData["TIPO_CONSULTAId"] = new SelectList(_context.TIPO_CONSULTA.OrderBy(x => x.Descricao), "Id", "Descricao");
            return View(aGENDAMENTO);
        }

        #endregion

        #region Delete

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

        #endregion

        #region Others Methods

        private bool AGENDAMENTOExists(int id)
        {
            return _context.AGENDAMENTO.Any(e => e.Id == id);
        }

        #endregion
    }
}
