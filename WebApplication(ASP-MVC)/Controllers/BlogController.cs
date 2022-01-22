using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_ASP_MVC_.Models;

namespace WebApplication_ASP_MVC_.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View(); // menampilkan kolom inputan
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Blog parameter)
        {
            if (ModelState.IsValid) 
            { 
                // proses masukan ke database
          
                _context.Add(parameter);
               await _context.SaveChangesAsync();

                return Redirect("Index"); // menerima inputan
            }

            return View(parameter);
        }

        public IActionResult Index()
        {
            var data = _context.Tb_Blog.ToList();
            return View(data);
        }

    }
}
