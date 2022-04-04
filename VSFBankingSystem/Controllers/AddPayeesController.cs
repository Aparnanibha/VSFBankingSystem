#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VSFBankingSystem.Models;

namespace VSFBankingSystem.Controllers
{
    public class AddPayeesController : Controller
    {
        private readonly VSFBankContext _context;

        public AddPayeesController(VSFBankContext context)
        {
            _context = context;
        }

        // GET: AddPayees
        public async Task<IActionResult> Index()
        {
            var vSFBankContext = _context.AddPayees.Include(a => a.AccountNumberNavigation);
            return View(await vSFBankContext.ToListAsync());
        }

        // GET: AddPayees/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addPayee = await _context.AddPayees
                .Include(a => a.AccountNumberNavigation)
                .FirstOrDefaultAsync(m => m.BeneficiaryAccountNumber == id);
            if (addPayee == null)
            {
                return NotFound();
            }

            return View(addPayee);
        }

        // GET: AddPayees/Create
        public IActionResult Create()
        {
            ViewData["AccountNumber"] = new SelectList(_context.CustomerAccs, "AccountNumber", "AccountNumber");
            return View();
        }

        // POST: AddPayees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BeneficiaryAccountNumber,AccountNumber,BeneficiaryName,NickName")] AddPayee addPayee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addPayee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountNumber"] = new SelectList(_context.CustomerAccs, "AccountNumber", "AccountNumber", addPayee.AccountNumber);
            return View(addPayee);
        }

        // GET: AddPayees/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addPayee = await _context.AddPayees.FindAsync(id);
            if (addPayee == null)
            {
                return NotFound();
            }
            ViewData["AccountNumber"] = new SelectList(_context.CustomerAccs, "AccountNumber", "AccountNumber", addPayee.AccountNumber);
            return View(addPayee);
        }

        // POST: AddPayees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("BeneficiaryAccountNumber,AccountNumber,BeneficiaryName,NickName")] AddPayee addPayee)
        {
            if (id != addPayee.BeneficiaryAccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addPayee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddPayeeExists(addPayee.BeneficiaryAccountNumber))
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
            ViewData["AccountNumber"] = new SelectList(_context.CustomerAccs, "AccountNumber", "AccountNumber", addPayee.AccountNumber);
            return View(addPayee);
        }

        // GET: AddPayees/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addPayee = await _context.AddPayees
                .Include(a => a.AccountNumberNavigation)
                .FirstOrDefaultAsync(m => m.BeneficiaryAccountNumber == id);
            if (addPayee == null)
            {
                return NotFound();
            }

            return View(addPayee);
        }

        // POST: AddPayees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var addPayee = await _context.AddPayees.FindAsync(id);
            _context.AddPayees.Remove(addPayee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddPayeeExists(decimal id)
        {
            return _context.AddPayees.Any(e => e.BeneficiaryAccountNumber == id);
        }
    }
}
