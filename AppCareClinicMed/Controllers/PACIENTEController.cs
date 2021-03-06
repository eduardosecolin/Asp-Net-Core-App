﻿using System;
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
    public class PACIENTEController : Controller
    {

        #region Header

        private readonly AppCareClinicMedContext _context;

        public PACIENTEController(AppCareClinicMedContext context)
        {
            _context = context;
        }

        #endregion

        #region Get and Details

        // GET: PACIENTE
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            var appCareClinicMedContext = _context.PACIENTE.Include(p => p.Convenio).Include(p => p.Estado).Include(p => p.Pais);
            return View(await appCareClinicMedContext.ToListAsync());
        }

        // GET: PACIENTE/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pACIENTE = await _context.PACIENTE
                .Include(p => p.Convenio)
                .Include(p => p.Estado)
                .Include(p => p.Pais)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pACIENTE == null)
            {
                return NotFound();
            }

            return View(pACIENTE);
        }

        #endregion

        #region Create / Post

        // GET: PACIENTE/Create
        public IActionResult Create()
        {
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO.OrderBy(x => x.Descricao), "Id", "Descricao");
            ViewData["ESTADOSId"] = new SelectList(_context.ESTADOS.OrderBy(x => x.Estado), "Id", "Estado");
            ViewData["PAISId"] = new SelectList(_context.PAIS.OrderBy(x => x.Pais), "Id", "Pais");
            return View();
        }

        // POST: PACIENTE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Data_nascimento,Sexo,Estado_civil,Endereco,Numero,Bairro,Cidade,ESTADOSId,PAISId,Cpf,Rg,CONVENIOId,Email")] PACIENTE pACIENTE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pACIENTE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO.OrderBy(x => x.Descricao), "Id", "Descricao", pACIENTE.CONVENIOId);
            ViewData["ESTADOSId"] = new SelectList(_context.ESTADOS.OrderBy(x => x.Estado), "Id", "Estado", pACIENTE.ESTADOSId);
            ViewData["PAISId"] = new SelectList(_context.PAIS.OrderBy(x => x.Pais), "Id", "Pais", pACIENTE.PAISId);
            return View(pACIENTE);
        }

        #endregion

        #region Edit / Put

        // GET: PACIENTE/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pACIENTE = await _context.PACIENTE.FindAsync(id);
            if (pACIENTE == null)
            {
                return NotFound();
            }
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO.OrderBy(x => x.Descricao), "Id", "Descricao", pACIENTE.CONVENIOId);
            ViewData["ESTADOSId"] = new SelectList(_context.ESTADOS.OrderBy(x => x.Estado), "Id", "Estado", pACIENTE.ESTADOSId);
            ViewData["PAISId"] = new SelectList(_context.PAIS.OrderBy(x => x.Pais), "Id", "Pais", pACIENTE.PAISId);
            return View(pACIENTE);
        }

        // POST: PACIENTE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Data_nascimento,Sexo,Estado_civil,Endereco,Numero,Bairro,Cidade,ESTADOSId,PAISId,Cpf,Rg,CONVENIOId,Email")] PACIENTE pACIENTE)
        {
            if (id != pACIENTE.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pACIENTE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PACIENTEExists(pACIENTE.Id))
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
            ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO.OrderBy(x => x.Descricao), "Id", "Descricao", pACIENTE.CONVENIOId);
            ViewData["ESTADOSId"] = new SelectList(_context.ESTADOS.OrderBy(x => x.Estado), "Id", "Estado", pACIENTE.ESTADOSId);
            ViewData["PAISId"] = new SelectList(_context.PAIS.OrderBy(x => x.Pais), "Id", "Pais", pACIENTE.PAISId);
            return View(pACIENTE);
        }

        #endregion

        #region Delete

        // GET: PACIENTE/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pACIENTE = await _context.PACIENTE
                .Include(p => p.Convenio)
                .Include(p => p.Estado)
                .Include(p => p.Pais)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pACIENTE == null)
            {
                return NotFound();
            }

            return View(pACIENTE);
        }

        // POST: PACIENTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pACIENTE = await _context.PACIENTE.FindAsync(id);
            _context.PACIENTE.Remove(pACIENTE);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Others Methods

        private bool PACIENTEExists(int id)
        {
            return _context.PACIENTE.Any(e => e.Id == id);
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
