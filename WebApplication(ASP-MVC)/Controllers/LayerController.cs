using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_ASP_MVC_.Services;

namespace WebApplication_ASP_MVC_.Controllers
{
    public class LayerController : Controller
    {
        private readonly IBlogService _blogService;
        public LayerController(IBlogService s)
        {
            _blogService = s;
        }
        public IActionResult Index()
        {
            var data = _blogService.TampilSemuaData();
            return View(data);
        }
    }
}
