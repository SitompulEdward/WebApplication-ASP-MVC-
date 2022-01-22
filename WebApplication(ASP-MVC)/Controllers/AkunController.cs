using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_ASP_MVC_.Models;

namespace WebApplication_ASP_MVC_.Controllers
{
    public class AkunController : Controller
    {
        private readonly AppDbContext _context;
        public AkunController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Daftar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Daftar(User datanya)
        {
            _context.Add(datanya);
            _context.SaveChanges();

            return RedirectToAction("Masuk");
        }

        public IActionResult Masuk()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Masuk(User datanya)
        {
            var cari = _context.Tb_User.Where(carii => carii.Username == datanya.Username
                                                       && carii.Password == carii.Password
                                              ).FirstOrDefault();
            if (cari != null)
            {
                return RedirectToAction(controllerName:"Blog", actionName:"Index");
            }


            return View(datanya);
        }
    }
}
