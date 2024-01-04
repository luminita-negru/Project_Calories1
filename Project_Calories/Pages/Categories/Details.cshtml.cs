using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Calories.Data;
using Project_Calories.Models;

namespace Project_Calories.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Project_Calories.Data.Project_CaloriesContext _context;

        public DetailsModel(Project_Calories.Data.Project_CaloriesContext context)
        {
            _context = context;
        }

      public Categorie Categorie { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categorie == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorie.FirstOrDefaultAsync(m => m.CategorieId == id);
            if (categorie == null)
            {
                return NotFound();
            }
            else 
            {
                Categorie = categorie;
            }
            return Page();
        }
    }
}
