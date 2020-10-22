using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Pages.Theaters
{
    public class DeleteModel : PageModel
    {
        private readonly MovieApp.Data.MovieContext _context;

        public DeleteModel(MovieApp.Data.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Theater Theater { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Theater = await _context.Theater.FirstOrDefaultAsync(m => m.TheaterId == id);

            if (Theater == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Theater = await _context.Theater.FindAsync(id);

            if (Theater != null)
            {
                _context.Theater.Remove(Theater);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
