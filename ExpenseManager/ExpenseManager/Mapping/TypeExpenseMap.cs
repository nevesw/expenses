using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManager.Mapping
{
    public class TypeExpenseMap : IEntityTypeConfiguration<TypeExpense>
    {
        // Create the method do mapping classes
        public void Configure(EntityTypeBuilder<TypeExpense> builder)
        {
            builder.HasKey(td => td.TypeExpenseId);
            builder.Property(td => td.Name).HasMaxLength(50).IsRequired();

            // Configure relation to expense class 1 n
            builder.HasMany(td => td.Expenses).WithOne(td => td.TypeExpense).HasForeignKey(td => td.TypeExpenseId);

            //Name of the table
            builder.ToTable("Expense");


        }
    }
}
