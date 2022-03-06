using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication_ASP_MVC_.Helper;
using WebApplication_ASP_MVC_.Models;
using WebApplication_ASP_MVC_.Services;

namespace WebApplication_ASP_MVC_.Controllers
{
    public class AkunController : Controller
    {
        private readonly AppDbContext _context;
        private readonly EmailService _email;
        public AkunController(AppDbContext context,EmailService e)
        {
            _context = context;
            _email = e;
        }

        public IActionResult Daftar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Daftar(User datanya)
        {
            int OTP = BanyakBantuan.BuatOTP();

            bool hasil = _email.KirimEmail(datanya.Email, "Konfirmasi Daftar","<h1 style='color:red'> Assalamulaikum </h1>" + OTP);

            _context.Add(datanya);
            _context.SaveChanges();

            return RedirectToAction("Masuk");
        }

        public IActionResult Masuk()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Masuk(User datanya)
        {
            //var cari = _context.Tb_User.Where(carii => carii.Username == datanya.Username
            //                                           && carii.Password == carii.Password
            //                                  ).FirstOrDefault();
            //if (cari != null)
            //{
            //    return RedirectToAction(controllerName: "Blog", actionName: "Index");
            //}

            var cariUsername = _context.Tb_User.Where(x => x.Username == datanya.Username).FirstOrDefault();

            if (cariUsername != null)
            {
                var cekPassword = _context.Tb_User.Where(x => x.Username == datanya.Username
                                                         && x.Password == datanya.Password)
                                                         .Include(x2 => x2.Roles).FirstOrDefault();

                // proses tampungan data

                if (cekPassword != null)
                {
                    var daftar = new List<Claim>
                    {
                        new Claim ("Username", cariUsername.Username),
                        new Claim("Role", cariUsername.Roles.Name)
                    };

                    // proses daftar Auth

                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(
                            new ClaimsIdentity(daftar, "Cookie", "Username", "Role")
                        )
                    );

                    if (cariUsername.Roles.Id == "1")
                    {
                        return Redirect("/admin/home");
                    }else if(cariUsername.Roles.Id == "2")
                    {
                        return Redirect("/user/home");
                    }

                    return RedirectToAction(controllerName: "Blog", actionName: "Index");
                }
                ViewBag.pesan = "Password Salah !";
                return View(datanya);
            }

            ViewBag.pesan = "Username Salah !";
            return View(datanya);
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }
    }
}
