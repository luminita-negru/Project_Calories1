using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Calories.Data;
using Project_Calories.Models;

namespace Project_Calories.Pages.Meals
{
    [Authorize(Roles = "Admin")]
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
        public Meal Meal { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Meal == null || Meal == null)
            {
                return Page();
            }

            _context.Meal.Add(Meal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
