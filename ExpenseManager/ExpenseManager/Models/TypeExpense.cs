using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public class TypeExpense
    {
        public int TypeExpenseId { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [StringLength(100, ErrorMessage = "Use less characters")]
        [Remote("TypeExpenseExists", "TypeExpenses")]
        public string Name { get; set; }

        public ICollection<Expense> Expenses { get; set; }
    }
}
