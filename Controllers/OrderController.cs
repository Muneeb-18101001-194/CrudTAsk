using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDTASK.Data;
using CRUDTASK.Models;

namespace CRUDTASK.Controllers
{
    public class OrderController : Controller
    {
        private readonly StoreDB _context;

        public OrderController(StoreDB context)
        {
            _context = context;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderModels.ToListAsync());
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModels = await _context.OrderModels
                .FirstOrDefaultAsync(m => m.id == id);
            if (orderModels == null)
            {
                return NotFound();
            }

            return View(orderModels);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Description,Quantity,Price")] OrderModels orderModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderModels);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModels = await _context.OrderModels.FindAsync(id);
            if (orderModels == null)
            {
                return NotFound();
            }
           

            return View(orderModels);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Description,Quantity,Price")] OrderModels orderModels)
        {
            if (id != orderModels.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderModelsExists(orderModels.id))
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
            return View(orderModels);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModels = await _context.OrderModels
                .FirstOrDefaultAsync(m => m.id == id);
            if (orderModels == null)
            {
                return NotFound();
            }

            return View(orderModels);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderModels = await _context.OrderModels.FindAsync(id);
            _context.OrderModels.Remove(orderModels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderModelsExists(int id)
        {
            return _context.OrderModels.Any(e => e.id == id);
        }
    }
}
