using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RMS.Models;

namespace RMS.Controllers
{
    public class OrderitemController : Controller
    {
        private readonly ManagementSystemContext _context;

        public OrderitemController(ManagementSystemContext context)
        {
            _context = context;
        }

        // GET: Orderitem
        public async Task<IActionResult> Index()
        {
            var managementSystemContext = _context.Orderitems.Include(o => o.Item).Include(o => o.Order);
            return View(await managementSystemContext.ToListAsync());
        }

        // GET: Orderitem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderitem = await _context.Orderitems
                .Include(o => o.Item)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.Orderid == id);
            if (orderitem == null)
            {
                return NotFound();
            }

            return View(orderitem);
        }

        // GET: Orderitem/Create
        public IActionResult Create()
        {
            ViewData["Itemid"] = new SelectList(_context.Items, "Itemid", "Itemid");
            ViewData["Orderid"] = new SelectList(_context.Orders, "Orderid", "Orderid");
            return View();
        }

        // POST: Orderitem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Orderid,Itemid,Quantity,Specialinstructions")] Orderitem orderitem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderitem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Itemid"] = new SelectList(_context.Items, "Itemid", "Itemid", orderitem.Itemid);
            ViewData["Orderid"] = new SelectList(_context.Orders, "Orderid", "Orderid", orderitem.Orderid);
            return View(orderitem);
        }

        // GET: Orderitem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderitem = await _context.Orderitems.FindAsync(id);
            if (orderitem == null)
            {
                return NotFound();
            }
            ViewData["Itemid"] = new SelectList(_context.Items, "Itemid", "Itemid", orderitem.Itemid);
            ViewData["Orderid"] = new SelectList(_context.Orders, "Orderid", "Orderid", orderitem.Orderid);
            return View(orderitem);
        }

        // POST: Orderitem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Orderid,Itemid,Quantity,Specialinstructions")] Orderitem orderitem)
        {
            if (id != orderitem.Orderid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderitemExists(orderitem.Orderid))
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
            ViewData["Itemid"] = new SelectList(_context.Items, "Itemid", "Itemid", orderitem.Itemid);
            ViewData["Orderid"] = new SelectList(_context.Orders, "Orderid", "Orderid", orderitem.Orderid);
            return View(orderitem);
        }

        // GET: Orderitem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderitem = await _context.Orderitems
                .Include(o => o.Item)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.Orderid == id);
            if (orderitem == null)
            {
                return NotFound();
            }

            return View(orderitem);
        }

        // POST: Orderitem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderitem = await _context.Orderitems.FindAsync(id);
            if (orderitem != null)
            {
                _context.Orderitems.Remove(orderitem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderitemExists(int id)
        {
            return _context.Orderitems.Any(e => e.Orderid == id);
        }
    }
}
