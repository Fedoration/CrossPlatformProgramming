using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2Laputin.Data;
using WebApplication2Laputin.Models;

namespace WebApplication2Laputin.Controllers
{
    public class PipesController : Controller
    {
        private readonly MvcPipeContext _context;

        public PipesController(MvcPipeContext context)
        {
            _context = context;
        }

        // GET: Pipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pipe.ToListAsync());
        }

        // GET: Pipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pipe = await _context.Pipe
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pipe == null)
            {
                return NotFound();
            }

            return View(pipe);
        }

        // GET: Pipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ReleaseDate,length,diameter")] Pipe pipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pipe);
        }

        // GET: Pipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pipe = await _context.Pipe.FindAsync(id);
            if (pipe == null)
            {
                return NotFound();
            }
            return View(pipe);
        }

        // POST: Pipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ReleaseDate,length,diameter")] Pipe pipe)
        {
            if (id != pipe.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PipeExists(pipe.ID))
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
            return View(pipe);
        }

        // GET: Pipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pipe = await _context.Pipe
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pipe == null)
            {
                return NotFound();
            }

            return View(pipe);
        }

        // POST: Pipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pipe = await _context.Pipe.FindAsync(id);
            _context.Pipe.Remove(pipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PipeExists(int id)
        {
            return _context.Pipe.Any(e => e.ID == id);
        }
    }
}
