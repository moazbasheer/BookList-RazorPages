using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages.BookList
{
    public class EditModel : PageModel
    {
        ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { set; get; }
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var OldBook = await _db.Book.FindAsync(Book.Id);
                OldBook.Name = Book.Name;
                OldBook.ISBN = Book.ISBN;
                OldBook.Author = Book.Author;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            } 
            else
            {
                return Page();
            }
        }
    }
}
