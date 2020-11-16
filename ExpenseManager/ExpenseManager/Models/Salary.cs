﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public class Salary
    {
        public int SalaryId { get; set; }
        public int MonthId { get; set; }
        public Months Months { get; set; }

        [Required(ErrorMessage = "Required Field.")]
        [Range(0, double.MaxValue, ErrorMessage = "Invalid value.")]
        public double Value { get; set; }
    }
}
