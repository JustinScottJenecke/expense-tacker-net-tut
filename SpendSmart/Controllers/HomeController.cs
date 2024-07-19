using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;

namespace SpendSmart.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SpendSmartDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, SpendSmartDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Expenses()
    {
        var allExpenses = _dbContext.Expenses.ToList<Expense>();
        return View(allExpenses);
    }
    public IActionResult ExpenseCreateEdit(int? id)
    {
        // load view with expense as arg
        if (id != null) 
        {
            var expense = _dbContext.Expenses.SingleOrDefault(expense => expense.Id == id);
            return View(expense);
        }

        // load page default
        return View();
    }
    public IActionResult ExpenseDelete(int id)
    {
        var deleteExpense = _dbContext.Expenses.SingleOrDefault(expense => expense.Id == id);

        _dbContext.Expenses.Remove(deleteExpense);
        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }
    public IActionResult ExpenseCreateEditFormHandler(Expense expense)
    {
        _dbContext.Expenses.Add(expense);
        _dbContext.SaveChanges();

        return RedirectToAction("Expenses");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
