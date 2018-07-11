using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Film.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Film.Pages.FilmPages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;

        [TempData]
        public String afterAddMessage { get; set; }
        

        public IndexModel(ApplicationDbContext db)
        
        {
            _db = db;
        }
        public IEnumerable<Connections>myFilm { get; set; }
        public async Task OnGet()
        {
            myFilm = await _db.FilmItems.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var theFilm = _db.FilmItems.Find(id);
            _db.FilmItems.Remove(theFilm);

            await _db.SaveChangesAsync();

            afterAddMessage = "Movie deleted successfully!";

            return RedirectToPage();
        }
    }
}
