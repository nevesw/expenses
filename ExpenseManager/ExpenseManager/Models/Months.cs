using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public class Months
    {
        public int MonthId { get; set; }

        public string Name { get; set; }
        public ICollection<Expense> Expenses { get; set; }

        public Salary Salary { get; set; }
    }
}
