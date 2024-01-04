using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Calories.Data;
using Project_Calories.Models;

namespace Project_Calories.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Project_Calories.Data.Project_CaloriesContext _context;

        public CreateModel(Project_Calories.Data.Project_CaloriesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Categorie Categorie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Categorie == null || Categorie == null)
            {
                return Page();
            }

            _context.Categorie.Add(Categorie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
