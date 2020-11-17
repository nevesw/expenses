using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseManager.Models;

namespace ExpenseManager.Controllers
{
    public class TypeExpensesController : Controller
    {
        private readonly Contexto _context;

        public TypeExpensesController(Contexto context)
        {
            _context = context;
        }

        // GET: TypeExpenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeExpenses.ToListAsync());
        }

        //// GET: TypeExpenses/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var typeExpense = await _context.TypeExpenses
        //        .FirstOrDefaultAsync(m => m.TypeExpenseId == id);
        //    if (typeExpense == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(typeExpense);
        //}

        // GET: TypeExpenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeExpenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeExpenseId,Name")] TypeExpense typeExpense)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirm"] = typeExpense.Name + " has been successfully registered.";
                _context.Add(typeExpense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeExpense);
        }

        // GET: TypeExpenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeExpense = await _context.TypeExpenses.FindAsync(id);
            if (typeExpense == null)
            {
                return NotFound();
            }
            return View(typeExpense);
        }

        // POST: TypeExpenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeExpenseId,Name")] TypeExpense typeExpense)
        {
            if (id != typeExpense.TypeExpenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirm"] = typeExpense.Name + " has been successfully updated.";
                    _context.Update(typeExpense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeExpenseExists(typeExpense.TypeExpenseId))
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
            return View(typeExpense);
        }

        //// GET: TypeExpenses/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var typeExpense = await _context.TypeExpenses
        //        .FirstOrDefaultAsync(m => m.TypeExpenseId == id);
        //    if (typeExpense == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(typeExpense);
        //}

        // POST: TypeExpenses/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var typeExpense = await _context.TypeExpenses.FindAsync(id);
            TempData["Confirm"] = typeExpense.Name + " has been successfully deleted.";
            _context.TypeExpenses.Remove(typeExpense);
            await _context.SaveChangesAsync();
            return Json(typeExpense.Name + "Deleted.");
        }

        private bool TypeExpenseExists(int id)
        {
            return _context.TypeExpenses.Any(e => e.TypeExpenseId == id);
        }
    }
}
