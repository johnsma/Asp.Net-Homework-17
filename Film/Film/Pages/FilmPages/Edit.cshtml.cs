using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Film.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Film.Pages
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Connections Connect { get; set; }

        [TempData]
        public string afterAddMessage { get; set; }
               

        public void OnGet(int id)
        {
            Connect = _db.FilmItems.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var FilmInDb = _db.FilmItems.Find(Connect.ID);
                FilmInDb.Name = Connect.Name;
                var FilmInDb1 = _db.FilmItems.Find(Connect.ID);
                FilmInDb.Year = Connect.Year;
                var FilmInDb2 = _db.FilmItems.Find(Connect.ID);
                FilmInDb.Length = Connect.Length;

                await _db.SaveChangesAsync();
                afterAddMessage = "Film list updated successfully!";

                return RedirectToPage();

            }
            else
            {
                return RedirectToPage();
            }
        }
    }

    
}