using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HelpDeskWebapp.Models;
using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel;

namespace HelpDeskWebapp.Controllers;

public class HomeController : Controller
{
    private AppDbContext context;
    public HomeController(AppDbContext dbContext)
    {
        context = dbContext;
    }
    public IActionResult Index()
    {
        Ticket t = new Ticket
        {
            Id = 1,
            Title = "test ticket",
            Description = "description of a problem",
            Priority = "low"
        };
        context.Tickets.Add(t);
        context.SaveChanges();
        return View(context.Tickets.First());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
