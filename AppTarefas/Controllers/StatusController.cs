using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppTarefas.Data;
using AppTarefas.Models;

namespace AppTarefas.Controllers
{
    public class StatusController : Controller
    {
        private readonly AppTarefasDbContext _context;

        public StatusController(AppTarefasDbContext context)
        {
            _context = context;
        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
            var dbStatus =  _context.Status;
            if (dbStatus.Count() == 0) 
            {
                Status ToDoStatus = new Status();
                ToDoStatus.StatusId = Guid.NewGuid();
                ToDoStatus.StatusNome = "A Fazer";
                _context.Add(ToDoStatus);

                Status DoingStatus = new Status();
                DoingStatus.StatusId = Guid.NewGuid();
                DoingStatus.StatusNome = "Fazendo";
                _context.Add(DoingStatus);

                Status DoneStatus = new Status();
                DoneStatus.StatusId = Guid.NewGuid();
                DoneStatus.StatusNome = "Concluído";
                _context.Add(DoneStatus);
                await _context.SaveChangesAsync();

            }
              return _context.Status != null ? 
                          View(await _context.Status.ToListAsync()) :
                          Problem("Entity set 'AppTarefasDbContext.Status'  is null.");
        }

        // GET: Status/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Status == null)
            {
                return NotFound();
            }

            var status = await _context.Status
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // GET: Status/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusId,StatusNome")] Status status)
        {
            if (ModelState.IsValid)
            {
                status.StatusId = Guid.NewGuid();
                _context.Add(status);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(status);
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Status == null)
            {
                return NotFound();
            }

            var status = await _context.Status.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("StatusId,StatusNome")] Status status)
        {
            if (id != status.StatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(status);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusExists(status.StatusId))
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
            return View(status);
        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Status == null)
            {
                return NotFound();
            }

            var status = await _context.Status
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Status == null)
            {
                return Problem("Entity set 'AppTarefasDbContext.Status'  is null.");
            }
            var status = await _context.Status.FindAsync(id);
            if (status != null)
            {
                _context.Status.Remove(status);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusExists(Guid id)
        {
          return (_context.Status?.Any(e => e.StatusId == id)).GetValueOrDefault();
        }
    }
}
