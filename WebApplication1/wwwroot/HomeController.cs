using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.wwwroot
{
    [Route("api/Book")]
    [ApiController]
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult getAll()
        {
            return Json(new { data = _db.Book.ToList() });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
