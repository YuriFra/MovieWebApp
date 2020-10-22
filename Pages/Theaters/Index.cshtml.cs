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
    public class IndexModel : PageModel
    {
        private readonly MovieApp.Data.MovieContext _context;

        public IndexModel(MovieApp.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<Theater> Theater { get;set; }

        public async Task OnGetAsync()
        {
            Theater = await _context.Theater.ToListAsync();
        }
    }
}
