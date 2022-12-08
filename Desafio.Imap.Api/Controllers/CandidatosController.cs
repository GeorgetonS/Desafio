using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Desafio.Imap.Api.Context;
using Desafio.Imap.Api.Entities;
using Desafio.Imap.Api.Models;
using AutoMapper;
using System.Text.RegularExpressions;

namespace Desafio.Imap.Api.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly MyContext _context;
        private readonly IMapper mapper;

        public CandidatosController(MyContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var candidato = (await _context.Candidatos.Include(x => x.Endereco).ToListAsync());
            var candidatos = mapper.Map<List<CandidatoViewModel>>(candidato);
            return View(candidatos);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Candidatos == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos.Include(x => x.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidato == null)
            {
                return NotFound();
            }

            var candidatos = mapper.Map<CandidatoViewModel>(candidato);

            return View(candidatos);
        }


        public IActionResult Create()
        {
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CandidatoViewModel candidatoViewModel)
        {
            if (ModelState.IsValid)
            {
                candidatoViewModel.Cpf = Regex.Replace(candidatoViewModel.Cpf, "[^0-9]", "");
                candidatoViewModel.Telefone = Regex.Replace(candidatoViewModel.Telefone, "[^0-9]", "");
                var candidato = mapper.Map<Candidato>(candidatoViewModel);
                _context.Add(candidato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidatoViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Candidatos == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos.Include(x => x.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidato == null)
            {
                return NotFound();
            }

            var candidatos = mapper.Map<CandidatoViewModel>(candidato);
            return View(candidatos);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CandidatoViewModel candidatoViewModel)
        {
            if (id != candidatoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    candidatoViewModel.Cpf = Regex.Replace(candidatoViewModel.Cpf, "[^0-9]", "");
                    candidatoViewModel.Telefone = Regex.Replace(candidatoViewModel.Telefone, "[^0-9]", "");
                    var candidato = mapper.Map<Candidato>(candidatoViewModel);
                    _context.Update(candidato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoExists(candidatoViewModel.Id))
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
            return View(candidatoViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Candidatos == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos
               .FirstOrDefaultAsync(m => m.Id == id);
            if (candidato == null)
            {
                return NotFound();
            }
            var candidatos = mapper.Map<CandidatoViewModel>(candidato);
            return View(candidatos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Candidatos == null)
            {
                return NotFound();
            }
            else if (id == 0)
            {
                return BadRequest();
            }

            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato != null)
            {
                _context.Candidatos.Remove(candidato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatoExists(int id)
        {
          return _context.Candidatos.Any(e => e.Id == id);
        }
    }
}
