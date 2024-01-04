using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Calories.Data;
using Project_Calories.Models;

namespace Project_Calories.Pages.Meals
{
    public class DetailsModel : PageModel
    {
        private readonly Project_Calories.Data.Project_CaloriesContext _context;

        public DetailsModel(Project_Calories.Data.Project_CaloriesContext context)
        {
            _context = context;
        }

      public Meal Meal { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Meal == null)
            {
                return NotFound();
            }

            var meal = await _context.Meal.FirstOrDefaultAsync(m => m.MealId == id);
            if (meal == null)
            {
                return NotFound();
            }
            else 
            {
                Meal = meal;
            }
            return Page();
        }
    }
}
