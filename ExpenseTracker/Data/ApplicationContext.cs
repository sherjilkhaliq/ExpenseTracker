using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Models;

namespace ExpenseTracker.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) { }
         
        public DbSet<ExpenseCategoroies> tbl_ExpenseCategoroy { get; set; }
        public DbSet<Expenses> tbl_Expense { get; set; }
    }
}
