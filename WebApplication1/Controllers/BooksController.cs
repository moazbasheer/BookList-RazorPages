using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Book.ToList() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var bookFromDb = _db.Book.FirstOrDefault(u => u.Id == id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Book.Remove(bookFromDb);
            _db.SaveChanges();
            return Json(new { success = true, message = "Delete successful" });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
