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
    public class TransactionDetailsController : Controller
    {
        private readonly VSFBankContext _context;

        public TransactionDetailsController(VSFBankContext context)
        {
            _context = context;
        }

        // GET: TransactionDetails
        public async Task<IActionResult> Index()
        {
            var vSFBankContext = _context.TransactionDetails.Include(t => t.AccountNumberNavigation);
            return View(await vSFBankContext.ToListAsync());
        }

        // GET: TransactionDetails/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionDetail = await _context.TransactionDetails
                .Include(t => t.AccountNumberNavigation)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transactionDetail == null)
            {
                return NotFound();
            }

            return View(transactionDetail);
        }

        // GET: TransactionDetails/Create
        public IActionResult Create()
        {
            ViewData["AccountNumber"] = new SelectList(_context.CustomerAccs, "AccountNumber", "AccountNumber");
            return View();
        }

        // POST: TransactionDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,TransactionType,ToAccountNumber,AccountNumber,Maturityinstruct,TransactionDate,Amount,TransType")] TransactionDetail transactionDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountNumber"] = new SelectList(_context.CustomerAccs, "AccountNumber", "AccountNumber", transactionDetail.AccountNumber);
            return View(transactionDetail);
        }

        // GET: TransactionDetails/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionDetail = await _context.TransactionDetails.FindAsync(id);
            if (transactionDetail == null)
            {
                return NotFound();
            }
            ViewData["AccountNumber"] = new SelectList(_context.CustomerAccs, "AccountNumber", "AccountNumber", transactionDetail.AccountNumber);
            return View(transactionDetail);
        }

        // POST: TransactionDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("TransactionId,TransactionType,ToAccountNumber,AccountNumber,Maturityinstruct,TransactionDate,Amount,TransType")] TransactionDetail transactionDetail)
        {
            if (id != transactionDetail.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionDetailExists(transactionDetail.TransactionId))
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
            ViewData["AccountNumber"] = new SelectList(_context.CustomerAccs, "AccountNumber", "AccountNumber", transactionDetail.AccountNumber);
            return View(transactionDetail);
        }

        // GET: TransactionDetails/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionDetail = await _context.TransactionDetails
                .Include(t => t.AccountNumberNavigation)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transactionDetail == null)
            {
                return NotFound();
            }

            return View(transactionDetail);
        }

        // POST: TransactionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var transactionDetail = await _context.TransactionDetails.FindAsync(id);
            _context.TransactionDetails.Remove(transactionDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionDetailExists(decimal id)
        {
            return _context.TransactionDetails.Any(e => e.TransactionId == id);
        }
    }
}
