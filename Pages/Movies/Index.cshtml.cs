using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieContext _context;

        public IndexModel(MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        //bind properties from GET request data
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }
        
        public async Task OnGetAsync()
        {
            //use LINQ markup for query to database
            IQueryable<string> genreQuery = from movie in _context.Movie
                orderby movie.Genre
                select movie.Genre;
            
            var movies = from movie in _context.Movie
                select movie;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(movie => movie.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(movie => movie.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
            Movie = Movie.OrderBy(name => name.Title).ToList();
        }
    }
}
