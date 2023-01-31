using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Expenses
    {
        [Key]
        public int ExpenseID { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ExpenseDate { get; set; }
        
        [Required(ErrorMessage = "Required")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid double Number")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "CategoryName")]
        public int ExpenseCategoroyID { get; set; }

        [NotMapped]
        public string? CategoryName { get; set; }
    }
}
