using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationContext _db;

        public ExpenseController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult ExpenseList()
        {
            try
            {
                var expenselist = from a in _db.tbl_Expense
                                  join b in _db.tbl_ExpenseCategoroy
                                  on a.ExpenseCategoroyID equals b.ExpenseCategoryID
                                  into Expense
                                  from b in Expense.DefaultIfEmpty()

                                  select new Expenses
                                  {
                                      ExpenseID = a.ExpenseID,
                                      ExpenseDate = a.ExpenseDate,
                                      Amount = a.Amount,
                                      ExpenseCategoroyID = a.ExpenseCategoroyID,
                                      CategoryName = (b==null)?"":b.CategoryName
                                  };
                return View(expenselist);
            }
            catch (Exception ex)
            {

                return View();
            }
        }
        [HttpPost]
        public IActionResult ExpenseList(DateTime Todate,DateTime FromDate)
        {
            try
            {
                var expenselist = from a in _db.tbl_Expense
                                  join b in _db.tbl_ExpenseCategoroy
                                  on a.ExpenseCategoroyID equals b.ExpenseCategoryID
                                  into Expense
                                  from b in Expense.DefaultIfEmpty()

                                  select new Expenses
                                  {
                                      ExpenseID = a.ExpenseID,
                                      ExpenseDate = a.ExpenseDate,
                                      Amount = a.Amount,
                                      ExpenseCategoroyID = a.ExpenseCategoroyID,
                                      CategoryName = (b == null) ? "" : b.CategoryName
                                  };
                expenselist = expenselist.Where(x => x.ExpenseDate >= Todate && x.ExpenseDate <= FromDate);
                return View(expenselist);
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        public IActionResult Create(Expenses objexpense)
        {
            loadExpenseCategory();
            return View(objexpense);
        }

        private void loadExpenseCategory()
        {
            try
            {
                List<ExpenseCategoroies> expenseCategoroies = new List<ExpenseCategoroies>();
                expenseCategoroies = _db.tbl_ExpenseCategoroy.ToList();
                expenseCategoroies.Insert(0, new ExpenseCategoroies { ExpenseCategoryID = 0, CategoryName = "Select" });
                ViewBag.expenseCategoroies = expenseCategoroies; 
            }
            catch (Exception ex)
            {

            }
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(Expenses objexpense)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    if(Convert.ToDateTime(objexpense.ExpenseDate)>DateTime.Now.Date)
                    {

                        TempData["msg"] = "<script>alert('you can not enter future date.');</script>";
                        loadExpenseCategory();
                        return View("Create", objexpense);
                    }
                    if(objexpense.ExpenseID==0)
                    {
                       
                            _db.tbl_Expense.Add(objexpense);
                            await _db.SaveChangesAsync();
                            return RedirectToAction("ExpenseList");
                    }
                    else
                    {
                        _db.Entry(objexpense).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _db.SaveChangesAsync();
                        return RedirectToAction("ExpenseList");

                    }
                }
                return View();

            }
            catch (Exception ex)
            {
                return RedirectToAction("ExpenseList");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var expense = await _db.tbl_Expense.FindAsync(id);
                if (expense != null)
                {
                    _db.tbl_Expense.Remove(expense);
                    await _db.SaveChangesAsync();
                }
                return RedirectToAction("ExpenseList");

            }
            catch (Exception)
            {
                return RedirectToAction("ExpenseList");
            }
        }




    }
}
