using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_ASP_MVC_.Helper;
using WebApplication_ASP_MVC_.Models;
using WebApplication_ASP_MVC_.Services;

namespace WebApplication_ASP_MVC_.Controllers
{
    [Authorize]
    public class BlogController : Controller
    { 
        private readonly AppDbContext _context;
        private readonly IBlogService _blogService;
        public BlogController(AppDbContext context, IBlogService service)
        {
            _context = context;
            _blogService = service;
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

                // parameter.Id = BuatPrimary.primary(); // untuk membuat primary key dari helper

                string nama = User.GetUsername();

                parameter.User = _context.Tb_User.FirstOrDefault(x => x.Username == nama);



                _context.Add(parameter);
               await _context.SaveChangesAsync();

                return Redirect("Index"); // menerima inputan
            }

            return View(parameter);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cari = _context.Tb_Blog.Where(x => x.Id == id).FirstOrDefault();

            if(cari == null)
            {
                return NotFound();
            }

            _context.Tb_Blog.Remove(cari);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var data = new BlogDashboard();

            data.blog = _context.Tb_Blog.Include(x => x.User).ToList();
            data.user = _context.Tb_User.Include(x => x.Roles).ToList();
            //var data = _context.Tb_Blog.ToList();
            return View(data);
        }

        public IActionResult DetailsBlog(int id)
        {
            var cari = _context.Tb_Blog.FirstOrDefault(x => x.Id == id);

            if (cari == null)
            {
                return NotFound();
            }

            var data = new DetailBlog();

            data.blog = _context.Tb_Blog.Where(x => x.Id == id).ToList();


            return View(data) ;

        }
      
        public async Task<IActionResult> Ubah(int id)
        {
            //var cari = await _context.Tb_Blog.FirstOrDefaultAsync(x => x.Id == id);
            var cari = await _blogService.TampilBLogById(id);

            if (cari == null)
            {
                return NotFound();
            }

            return View(cari);
        }

        [HttpPost]

        public async Task<IActionResult> Ubah(Blog data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Tb_Blog.Update(data);
                    //await _context.SaveChangesAsync();

                    await _blogService.UpdateBlogAsync(data);
                }
                catch
                {
                    return NotFound();
                }
                return RedirectToAction("Index");
                 
            }
            return View(data);
        }

    }
}
