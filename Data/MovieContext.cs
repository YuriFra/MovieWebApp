using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Data
{
    public class MovieContext : DbContext
        {
            public MovieContext (DbContextOptions<MovieContext> options)
                : base(options)
            {
            }
    
            public DbSet<Movie> Movie { get; set; }
            public DbSet<Theater> Theater { get; set; }
            
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Theater>()
                    .HasMany(m => m.Movies)
                    .WithOne(t => t.Theater)
                    .OnDelete(DeleteBehavior.SetNull);
            }
        }
}
    
