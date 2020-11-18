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
    public class SalaryController : Controller
    {
        private readonly Contexto _context;

        public SalaryController(Contexto context)
        {
            _context = context;
        }

        // GET: Salary
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Salaries.Include(s => s.Months);
            return View(await contexto.ToListAsync());
        }

        

        // GET: Salary/Create
        public IActionResult Create()
        {
            ViewData["MonthId"] = new SelectList(_context.Months.Where(s => s.MonthId != s.Salary.MonthId), "MonthId", "Name");
            return View();
        }

        // POST: Salary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalaryId,MonthId,Value")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirm"] = "Salary registered with success";
                _context.Add(salary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MonthId"] = new SelectList(_context.Months.Where(s => s.MonthId != s.Salary.MonthId), "MonthId", "Name", salary.MonthId);
            return View(salary);
        }

        // GET: Salary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _context.Salaries.FindAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            ViewData["MonthId"] = new SelectList(_context.Months.Where(s => s.MonthId == salary.MonthId), "MonthId", "Name", salary.MonthId);
            return View(salary);
        }

        // POST: Salary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalaryId,MonthId,Value")] Salary salary)
        {
            if (id != salary.SalaryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salary);
                    await _context.SaveChangesAsync();
                    TempData["Confirm"] = "Salary updated with success";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryExists(salary.SalaryId))
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
            ViewData["MonthId"] = new SelectList(_context.Months.Where(s => s.MonthId == salary.MonthId), "MonthId", "Name", salary.MonthId);
            return View(salary);
        }

      


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var salary = await _context.Salaries.FindAsync(id);
            _context.Salaries.Remove(salary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryExists(int id)
        {
            return _context.Salaries.Any(e => e.SalaryId == id);
        }
    }
}
