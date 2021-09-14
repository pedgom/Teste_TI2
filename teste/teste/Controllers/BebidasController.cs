using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using teste.Data;
using teste.Models;

namespace teste.Controllers
{
    [Authorize]
    public class BebidasController : Controller
    {
        private readonly Teste _context;

        private readonly IWebHostEnvironment _caminho;

        public BebidasController(Teste context, IWebHostEnvironment caminho)
        {
            _context = context;
            _caminho = caminho;
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
        [Authorize(Roles = "Gestor")]
        public IActionResult Create()
        {
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "Id");
            return View();
        }

        // POST: Bebidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Gestor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Preco,Imagem,Stock,CategoriaFK")] Bebidas bebida, IFormFile ImagemBeb)
        {
            string caminhoCompleto = "";
            bool hImagem = false;

            if (ImagemBeb == null) { bebida.Imagem = "noDrink.png"; }
            else
            {
                if (ImagemBeb.ContentType == "image/jpeg" || ImagemBeb.ContentType == "image/jpg" || ImagemBeb.ContentType == "image/png")
                {               
                    Guid g;
                    g = Guid.NewGuid();
                    string extensao = Path.GetExtension(ImagemBeb.FileName).ToLower();
                    string nomeA = g.ToString() + extensao;

                   
                    caminhoCompleto = Path.Combine(_caminho.WebRootPath, "Imagens", nomeA);

                    bebida.Imagem = nomeA;

                    hImagem = true;
                }
                else
                {
                  
                    bebida.Imagem = "noDrink.png";
                }

            }

            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(bebida);
                    await _context.SaveChangesAsync();
                    if (hImagem)
                    {
                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                        await ImagemBeb.CopyToAsync(stream);
                        
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);

                }

                /*_context.Add(bebida);
                await _context.SaveChangesAsync();*/
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "Id", bebida.CategoriaFK);
            return View(bebida);
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
