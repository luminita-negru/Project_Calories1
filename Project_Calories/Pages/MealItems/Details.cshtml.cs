using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Calories.Data;
using Project_Calories.Models;

namespace Project_Calories.Pages.MealItems
{
    public class DetailsModel : PageModel
    {
        private readonly Project_Calories.Data.Project_CaloriesContext _context;

        public DetailsModel(Project_Calories.Data.Project_CaloriesContext context)
        {
            _context = context;
        }

      public MealItem MealItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MealItem == null)
            {
                return NotFound();
            }

            var mealitem = await _context.MealItem.FirstOrDefaultAsync(m => m.MealItemId == id);
            if (mealitem == null)
            {
                return NotFound();
            }
            else 
            {
                MealItem = mealitem;
            }
            return Page();
        }
    }
}
