using ExpenseManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Mapping
{
    public class MonthsMap : IEntityTypeConfiguration<Months>
    {
        public void Configure(EntityTypeBuilder<Months> builder)
        {
            builder.HasKey(m => m.MonthId);
            builder.Property(m => m.MonthId).ValueGeneratedNever(); // database dont generate value
            builder.Property(m => m.Name).HasMaxLength(100).IsRequired();

            // Configure relation to expense class 1 n
            builder.HasMany(m => m.Expenses).WithOne(m => m.Months).HasForeignKey(m => m.MonthId).OnDelete(DeleteBehavior.Cascade);
            // Configure relation to slary
            builder.HasOne(m => m.Salary).WithOne(m => m.Months).OnDelete(DeleteBehavior.Cascade);
            //Name of the table
            builder.ToTable("Months");


        }
    }
}
