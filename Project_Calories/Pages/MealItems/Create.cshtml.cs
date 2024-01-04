using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Calories.Data;
using Project_Calories.Models;

namespace Project_Calories.Pages.MealItems
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
        ViewData["FoodId"] = new SelectList(_context.Food, "FoodId", "Name");
        ViewData["MealId"] = new SelectList(_context.Meal, "MealId", "Name");
            return Page();
        }

        [BindProperty]
        public MealItem MealItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MealItem == null || MealItem == null)
            {
                return Page();
            }

            _context.MealItem.Add(MealItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
