using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Film.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Film.Pages.FilmPages
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)

        {
            _db = db;
        }
        [TempData]
        public String afterAddMessage { get; set; }

        [BindProperty]
        public Connections Connect { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                _db.FilmItems.Add(Connect);

                await _db.SaveChangesAsync();

                afterAddMessage = "New Film Made!";

                return RedirectToPage("Index");
            }
        }
    }
}