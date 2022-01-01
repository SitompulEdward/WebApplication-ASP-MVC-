using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_ASP_MVC_.Models;

namespace WebApplication_ASP_MVC_.Controllers
{
    public class MobilController : Controller
    {
        public IActionResult Index()
        {
            /*var mobils = new List<Mobil>();

            mobils.Add(new Mobil
            {
                IDRegistrasi = 1,
                Tipe = "Sedan",
                Merk = "Toyota",
                Varian = "Apple",
            });

            mobils.Add(new Mobil
            {
                IDRegistrasi = 2,
                Tipe = "Suv",
                Merk = "Toyota",
                Varian = "Rav4",
            });
*/
            var banyakMobil = new Mobil[]
            {
                new Mobil{  IDRegistrasi = 0001, Tipe= "Sedan", Merk = "Toyota", Varian = "FT86"  },
                new Mobil{  IDRegistrasi = 0002, Tipe = "SUV", Merk = "Toyota", Varian = "RAV4"  },
                new Mobil{  IDRegistrasi = 0003, Tipe = "Sedan", Merk = "Honda", Varian = "Accord"  },
                new Mobil{  IDRegistrasi = 0004, Tipe = "SUV", Merk = "Honda", Varian = "CRV"  },
                new Mobil{  IDRegistrasi = 0005, Tipe = "Sedan", Merk = "Honda", Varian = "City"  },

            };

            var cariMobil = banyakMobil.Where(x => x.Tipe == "Sedan");


            string nama = "Edward";
            ViewBag.namaSaya = nama;
            ViewBag.mobils = cariMobil;
            

            //ViewData["nama"] = "Edwardddd";


            return View();
        }
    }
}
