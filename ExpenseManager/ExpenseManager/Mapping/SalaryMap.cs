﻿using ExpenseManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Mapping
{
    public class SalaryMap : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.HasKey(s => s.SalaryId);
            builder.Property(s => s.Value).IsRequired(); 
          
            builder.HasOne(s => s.Months).WithOne(s => s.Salary).HasForeignKey<Salary>(s => s.MonthId);
            //Name of the table
            builder.ToTable("Salary");


        }
    }
}
