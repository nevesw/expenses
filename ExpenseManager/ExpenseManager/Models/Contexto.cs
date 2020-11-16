using ExpenseManager.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public class Contexto : DbContext
    {
        // add classes to context

        public DbSet<Months> Months { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<TypeExpense> TypeExpenses { get; set; }
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {
            
        }

        // Ovvertide method onmodelcreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TypeExpenseMap());
            modelBuilder.ApplyConfiguration(new ExpenseMap());
            modelBuilder.ApplyConfiguration(new SalaryMap());
            modelBuilder.ApplyConfiguration(new MonthsMap());

        }
    }
}
