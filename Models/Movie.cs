using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 20, ErrorMessage = "Price must be between 1 and 20")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "€ {0:n2}")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; } 
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Genre { get; set; }
        public Theater Theater { get; set; }
    }
}