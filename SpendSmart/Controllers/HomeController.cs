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
        return View();
    }
    public IActionResult ExpenseCreateEdit()
    {
        return View();
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
