using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universidade.Data;

namespace Universidade.Controllers
{
    public class InstrutoresController : Controller
    {
        private readonly EscolaContexto _context;

        public InstrutoresController(EscolaContexto context)
        {
            _context = context;
        }

        // GET: Instrutores
        public async Task<IActionResult> Index()
        {
              return _context.Instrutores != null ? 
                          View(await _context.Instrutores.ToListAsync()) :
                          Problem("Entity set 'EscolaContexto.Instrutores'  is null.");
        }

        // GET: Instrutores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Instrutores == null)
            {
                return NotFound();
            }

            var instrutores = await _context.Instrutores
                .FirstOrDefaultAsync(m => m.InstrutoresID == id);
            if (instrutores == null)
            {
                return NotFound();
            }

            return View(instrutores);
        }

        // GET: Instrutores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instrutores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstrutoresNome,Sobrenome")] Instrutores instrutores)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(instrutores);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Logar o erro (descomente a variável ex e escreva um log
                ModelState.AddModelError("", "Não foi possível salvar. " +
                    "Tente novamente, e se o problema persistir " +
                    "chame o suporte.");
            }
            return View(instrutores);
        }

        // GET: Instrutores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Instrutores == null)
            {
                return NotFound();
            }

            var instrutores = await _context.Instrutores.FindAsync(id);
            if (instrutores == null)
            {
                return NotFound();
            }
            return View(instrutores);
        }

        // POST: Instrutores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstrutoresID,InstrutoresNome,Sobrenome")] Instrutores instrutores)
        {
            if (id != instrutores.InstrutoresID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrutores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrutoresExists(instrutores.InstrutoresID))
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
            return View(instrutores);
        }

        // GET: Instrutores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Instrutores == null)
            {
                return NotFound();
            }

            var instrutores = await _context.Instrutores
                .FirstOrDefaultAsync(m => m.InstrutoresID == id);
            if (instrutores == null)
            {
                return NotFound();
            }

            return View(instrutores);
        }

        // POST: Instrutores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Instrutores == null)
            {
                return Problem("Entity set 'EscolaContexto.Instrutores'  is null.");
            }
            var instrutores = await _context.Instrutores.FindAsync(id);
            if (instrutores != null)
            {
                _context.Instrutores.Remove(instrutores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrutoresExists(int id)
        {
          return (_context.Instrutores?.Any(e => e.InstrutoresID == id)).GetValueOrDefault();
        }
    }
}
