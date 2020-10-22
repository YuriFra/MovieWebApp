using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;

namespace MovieApp.Pages
{
    public class UploadFile : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        public string Filename { get; set; }
        
        public UploadFile(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        
        public void OnPost(IFormFile poster)
        {
            var path = Path.Combine(_environment.WebRootPath, "Images", poster.FileName);
            var fileStream = new FileStream(path, FileMode.Create);
            poster.CopyToAsync(fileStream);
            Filename = poster.FileName;
        }
        
        public void OnGet()
        {
            
        }
    }
}