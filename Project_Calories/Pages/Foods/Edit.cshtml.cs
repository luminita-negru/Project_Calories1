using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Calories.Data;
using Project_Calories.Models;

namespace Project_Calories.Pages.Foods
{
    public class EditModel : PageModel
    {
        private readonly Project_Calories.Data.Project_CaloriesContext _context;

        public EditModel(Project_Calories.Data.Project_CaloriesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Food Food { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Food == null)
            {
                return NotFound();
            }

            var food =  await _context.Food.FirstOrDefaultAsync(m => m.FoodId == id);
            if (food == null)
            {
                return NotFound();
            }
            Food = food;
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "CategorieId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(Food.FoodId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FoodExists(int id)
        {
          return (_context.Food?.Any(e => e.FoodId == id)).GetValueOrDefault();
        }
    }
}
