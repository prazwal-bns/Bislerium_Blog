using BlogCw.Data;
using BlogCw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogCw.Controllers;

public class BlogController: Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly BlogCwContext _context;

    public BlogController(IWebHostEnvironment webHostEnvironment, BlogCwContext context)
    {
        _webHostEnvironment = webHostEnvironment;
        _context = context;
    }
    public IActionResult WriteBlog()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Blog model)
    {
        if (model.FeaturedImage != null)
        {
            string folder = "featured_images/";
            model.FeaturedImagePath = await UploadImage(folder, model.FeaturedImage);
        }
        // Add the new user to the database
        _context.Blogs.Add(model);
        _context.SaveChanges();
        return View("WriteBlog");
    }
    
    private async Task<string> UploadImage(string folderPath, IFormFile file)
    {

        folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

        await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

        return "/" + folderPath;
    }
    
    
    public IActionResult Details(int id)
    {
        Blog blog = _context.Blogs.FirstOrDefault(x => x.Id == id);
        return View(blog);
    }
    
    
    
    public IActionResult Upvote(int id)
    {
        var blog = _context.Blogs.FirstOrDefault(x => x.Id == id);
        if (blog != null)
        {
            blog.Upvotes++;
            _context.SaveChanges();
        }
        return View("Details",blog);
    }

    public IActionResult Downvote(int id)
    {
        var blog = _context.Blogs.FirstOrDefault(x => x.Id == id);
        if (blog != null)
        {
            blog.Downvotes++;
            _context.SaveChanges();
        }
        return View("Details",blog);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var blog = await _context.Blogs.FindAsync(id);
        if (blog == null)
        {
            return Content("Blog not found");
        }

        _context.Blogs.Remove(blog);
        await _context.SaveChangesAsync();
    
        return RedirectToAction("Index","Home");
    }
}