using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using teste.Data;
using teste.Models;

namespace teste.Controllers
{
    public class BebidasController : Controller
    {
        private readonly Teste _context;

        public BebidasController(Teste context)
        {
            _context = context;
        }

        // GET: Bebidas
        public async Task<IActionResult> Index()
        {
            var teste = _context.Bebidas.Include(b => b.Categoria);
            return View(await teste.ToListAsync());
        }

        // GET: Bebidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bebidas = await _context.Bebidas
                .Include(b => b.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bebidas == null)
            {
                return NotFound();
            }

            return View(bebidas);
        }

        // GET: Bebidas/Create
        public IActionResult Create()
        {
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "Id");
            return View();
        }

        // POST: Bebidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Preco,Imagem,Stock,CategoriaFK")] Bebidas bebidas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bebidas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "Id", bebidas.CategoriaFK);
            return View(bebidas);
        }

        // GET: Bebidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bebidas = await _context.Bebidas.FindAsync(id);
            if (bebidas == null)
            {
                return NotFound();
            }
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "Id", bebidas.CategoriaFK);
            return View(bebidas);
        }

        // POST: Bebidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Preco,Imagem,Stock,CategoriaFK")] Bebidas bebidas)
        {
            if (id != bebidas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bebidas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BebidasExists(bebidas.Id))
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
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "Id", bebidas.CategoriaFK);
            return View(bebidas);
        }

        // GET: Bebidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bebidas = await _context.Bebidas
                .Include(b => b.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bebidas == null)
            {
                return NotFound();
            }

            return View(bebidas);
        }

        // POST: Bebidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bebidas = await _context.Bebidas.FindAsync(id);
            _context.Bebidas.Remove(bebidas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BebidasExists(int id)
        {
            return _context.Bebidas.Any(e => e.Id == id);
        }
    }
}
