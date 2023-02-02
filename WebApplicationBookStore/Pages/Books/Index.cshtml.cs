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
    public class IndexModel : PageModel
    {
        private readonly WebApplicationBookStore.Data.BookstoreContext _context;

        public IndexModel(WebApplicationBookStore.Data.BookstoreContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Books != null)
            {
                Book = await _context.Books.ToListAsync();
            }
        }
    }
}
