using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Universidade.Data;
using Universidade.Models;

namespace Universidade.Controllers
{
    public class EstudantesController : Controller
    {
        private readonly EscolaContexto _context;

        public EstudantesController(EscolaContexto context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: Estudantes
        public async Task<IActionResult> Index()
        {
            return _context.Estudantes != null
                ? View(await _context.Estudantes.ToListAsync())
                : Problem("Entity set 'EscolaContexto.Estudantes' is null.");
        }

        // GET: Estudantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estudantes == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes
                .FirstOrDefaultAsync(m => m.EstudanteID == id);
            if (estudante == null)
            {
                return NotFound();
            }

            return View(estudante);
        }

        // GET: Estudantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstudanteID,SobreNome,Nome,DataMatricula")] Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudante);
        }

        // GET: Estudantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estudantes == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes.FindAsync(id);
            if (estudante == null)
            {
                return NotFound();
            }
            return View(estudante);
        }

        // POST: Estudantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstudanteID,SobreNome,Nome,DataMatricula")] Estudante estudante)
        {
            if (id != estudante.EstudanteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudanteExists(estudante.EstudanteID))
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
            return View(estudante);
        }

        // GET: Estudantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estudantes == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes
                .FirstOrDefaultAsync(m => m.EstudanteID == id);
            if (estudante == null)
            {
                return NotFound();
            }

            return View(estudante);
        }

        // POST: Estudantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estudantes == null)
            {
                return Problem("Entity set 'EscolaContexto.Estudantes' is null.");
            }

            var estudante = await _context.Estudantes.FindAsync(id);
            if (estudante != null)
            {
                _context.Estudantes.Remove(estudante);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EstudanteExists(int id)
        {
            return (_context.Estudantes?.Any(e => e.EstudanteID == id)).GetValueOrDefault();
        }
    }
}
