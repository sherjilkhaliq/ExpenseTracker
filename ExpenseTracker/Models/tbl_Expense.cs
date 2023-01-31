using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class tbl_Expense
    {
        [Key]
        public int ExpenseID { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string ExpenseDate { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid double Number")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Required")]
        [ForeignKey("ExpenseCategoroies")]
        public int ExpenseCategoroyID { get; set; }

        public virtual tbl_ExpenseCategoroy _ExpenseCategoroy { get; set; }
    }
}
