using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_ASP_MVC_.Services;
using WebApplication_ASP_MVC_.Helper;

namespace WebApplication_ASP_MVC_.Controllers.Api
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IBlogService _service;

        public HomeController(IBlogService s)
        {
            _service = s;
        }

        [Route("blog")]
        public IActionResult Index()
        {
            var blogs = _service.TampilSemuaData();

            var respon = Respon("Sukses", 200, "Berhasil Mengambil Semua Data", blogs);
            
            return Ok(respon);
        }

        [Route("blog/{id}")]
        public IActionResult Index(int id)
        {
            var blog = _service.TampilBLogById(id);

            var respon = new
            {
                status = "SUKSES",
                respon_code = 200,
                message = "Berhasil Mengambil Detail Data Blog",
                data = blog
            };

            return Ok(respon);
        }

        private object Respon(string stat, int code, string pesan, object datanya)
        {
            return new
            {
                status = stat,
                respon_code = code,
                message = pesan,
                data = datanya
            };
        }
    }
}
