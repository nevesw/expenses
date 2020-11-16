using ExpenseManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Mapping
{
    public class ExpenseMap : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(e => e.ExpenseId);
            builder.Property(e => e.Value).IsRequired();

            builder.HasOne(e => e.Months).WithMany(e => e.Expenses).HasForeignKey(e => e.MonthId);
            builder.HasOne(e => e.TypeExpense).WithMany(e => e.Expenses).HasForeignKey(e => e.TypeExpenseId);
            //Name of the table
            builder.ToTable("Expense");


        }
    }
}
