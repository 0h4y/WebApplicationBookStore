using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationBookStore.Data;
using WebApplicationBookStore.Models;

namespace WebApplicationBookStore.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplicationBookStore.Data.BookstoreContext _context;

        public DetailsModel(WebApplicationBookStore.Data.BookstoreContext context)
        {
            _context = context;
        }

      public Book Book { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FirstOrDefaultAsync(m => m.Isbn == id);
            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }
    }
}
