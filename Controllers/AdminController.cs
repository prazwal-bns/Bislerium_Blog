using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using BlogCw.Data;
using BlogCw.Models;

namespace BlogCw.Controllers
{
    public class AdminController : Controller
    {
        private readonly BlogCwContext _context;

        public AdminController(BlogCwContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Get all blog posts
            var allPostsCount = _context.Blogs.Count();

            // Get total upvotes
            var totalUpvotes = _context.Blogs.Sum(b => b.Upvotes);

            // Get total downvotes
            var totalDownvotes = _context.Blogs.Sum(b => b.Downvotes);

            // Get total comments
            var totalComments = _context.Comments.Count();

            // Get month-specific data (assuming DateCreated is the creation date of the blog post)
            var currentDate = DateTime.UtcNow;
            var currentMonth = currentDate.Month;
            var currentYear = currentDate.Year;

            var monthPostsCount = _context.Blogs
                .Where(b => b.DateCreated.Month == currentMonth && b.DateCreated.Year == currentYear)
                .Count();

            var monthUpvotes = _context.Blogs
                .Where(b => b.DateCreated.Month == currentMonth && b.DateCreated.Year == currentYear)
                .Sum(b => b.Upvotes);

            var monthDownvotes = _context.Blogs
                .Where(b => b.DateCreated.Month == currentMonth && b.DateCreated.Year == currentYear)
                .Sum(b => b.Downvotes);

            var monthComments = _context.Comments
                .Where(c => c.DateCreated.Month == currentMonth && c.DateCreated.Year == currentYear)
                .Count();

            var viewModel = new AdminDashboardViewModel
            {
                AllPostsCount = allPostsCount,
                TotalUpvotes = totalUpvotes,
                TotalDownvotes = totalDownvotes,
                TotalComments = totalComments,
                MonthPostsCount = monthPostsCount,
                MonthUpvotes = monthUpvotes,
                MonthDownvotes = monthDownvotes,
                MonthComments = monthComments
            };

            return View(viewModel);
        }
    }
}
