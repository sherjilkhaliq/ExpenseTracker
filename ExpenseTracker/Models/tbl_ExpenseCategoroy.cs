
using System.ComponentModel.DataAnnotations;


namespace ExpenseTracker.Models
{
    public class tbl_ExpenseCategoroy
    {
        [Key]
        public int ExpenseCategoryID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string CategoryName { get; set; }
    }
}
