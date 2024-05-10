using System.Diagnostics;
using BlogCw.Data;
using Microsoft.AspNetCore.Mvc;
using BlogCw.Models;

namespace BlogCw.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BlogCwContext _context;

    public HomeController(ILogger<HomeController> logger, BlogCwContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index(string sortOrder)
    {
        IQueryable<Blog> blogs = _context.Blogs.AsQueryable();

        // Sort by popularity (e.g., number of upvotes)
        if (sortOrder == "popularity")
        {
            blogs = blogs.OrderByDescending(x => x.Upvotes);
        }
        // Sort by recency (assuming DateCreated is the date of creation)
        else if (sortOrder == "recency")
        {
            blogs = blogs.OrderByDescending(x => x.Id);
        }
        else
        {
            // Default sorting if sortOrder is not provided
            blogs = blogs.OrderByDescending(x => x.DateCreated);
        }

        return View(blogs.ToList());
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
    
    public IActionResult Upvote(int id)
    {
        var blog = _context.Blogs.FirstOrDefault(x => x.Id == id);
        if (blog != null)
        {
            blog.Upvotes++;
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    public IActionResult Downvote(int id)
    {
        var blog = _context.Blogs.FirstOrDefault(x => x.Id == id);
        if (blog != null)
        {
            blog.Downvotes++;
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    
}