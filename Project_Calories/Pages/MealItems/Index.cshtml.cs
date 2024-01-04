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
    public class IndexModel : PageModel
    {
        private readonly Project_Calories.Data.Project_CaloriesContext _context;

        public IndexModel(Project_Calories.Data.Project_CaloriesContext context)
        {
            _context = context;
        }

        public IList<MealItem> MealItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MealItem != null)
            {
                MealItem = await _context.MealItem
                .Include(m => m.Food)
                .Include(m => m.Meal).ToListAsync();
            }
        }
    }
}
