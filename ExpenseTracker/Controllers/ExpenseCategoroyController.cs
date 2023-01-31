using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ExpenseTracker.Controllers
{
    public class ExpenseCategoroyController : Controller
    {
        private readonly ApplicationContext _db;

        public ExpenseCategoroyController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult ExpenseCategoroyList()
        {
            try
            {
                var Categoroylst = _db.tbl_ExpenseCategoroy.ToList();
                return View(Categoroylst);
            }
            catch (Exception ex)
            {

                return View();
            }
           
        }

        public IActionResult Create(ExpenseCategoroies expenseCategoroies)
        {
           
                return View(expenseCategoroies);
        }
        [HttpPost]
        public async Task<IActionResult> AddExpenseCategoroy(ExpenseCategoroies expenseCategoroies)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(expenseCategoroies.ExpenseCategoryID==0)
                    {
                        if (_db.tbl_ExpenseCategoroy.Where(x=>x.CategoryName==expenseCategoroies.CategoryName).Any())
                        {
                            TempData["msg"] = "<script>alert('Expense Categoroy Already Exists.');</script>";
                            return View("Create", expenseCategoroies);
                        }
                        else
                        {
                            _db.tbl_ExpenseCategoroy.Add(expenseCategoroies);
                            await _db.SaveChangesAsync();
                            return RedirectToAction("ExpenseCategoroyList");
                        }
                       
                       
                    }
                    else
                    {
                        if (_db.tbl_ExpenseCategoroy.Where(x => x.ExpenseCategoryID != expenseCategoroies.ExpenseCategoryID && x.CategoryName == expenseCategoroies.CategoryName).Any())
                        {
                            TempData["msg"] = "<script>alert('Expense Categoroy Already Exists.');</script>";
                            return View("Create", expenseCategoroies);
                        }
                        _db.Entry(expenseCategoroies).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _db.SaveChangesAsync();
                        return RedirectToAction("ExpenseCategoroyList");

                    }
                }

                return View("Create", expenseCategoroies);
            }
            catch (Exception ex)
            {

                return RedirectToAction("ExpenseCategoroyList");
            }
        }



        public async Task<IActionResult> DeleteExpense(int id)
        {
            try
            {
                var ExpCategoroy = await _db.tbl_ExpenseCategoroy.FindAsync(id);
                if(ExpCategoroy!=null)
                {
                    _db.tbl_ExpenseCategoroy.Remove(ExpCategoroy);
                    await _db.SaveChangesAsync();
                }
                return RedirectToAction("ExpenseCategoroyList");

            }
            catch (Exception)
            {
                return RedirectToAction("ExpenseCategoroyList");
            }
        }
    }
}
