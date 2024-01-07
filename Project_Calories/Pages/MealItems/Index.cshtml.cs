using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
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
        //
        public string FoodSort { get; set; }
        public string MealSort { get; set; }
        public string DateSort { get; set; }


        public async Task OnGetAsync(string sortOrder)
        {
            //
            FoodSort = String.IsNullOrEmpty(sortOrder) ? "food_desc" : "";
            MealSort = sortOrder == "meal" ? "meal_desc" : "meal";
            DateSort = sortOrder == "date" ? "date_desc" : "date";

            if (_context.MealItem != null)
            {
                MealItem = await _context.MealItem
                .Include(m => m.Food)
                .Include(m => m.Meal).ToListAsync();
            }
            //
            switch (sortOrder)
            {
                case "food_desc":
                    MealItem = MealItem.OrderByDescending(s => s.Food.Name).ToList();
                    break;
                case "meal_desc":
                    MealItem = MealItem.OrderByDescending(s => s.Meal).ToList();
                    break;
                case "date_desc":
                    MealItem = MealItem.OrderByDescending(s => s.Date).ToList();
                    break;
                case "date":
                    MealItem = MealItem.OrderBy(s => s.Date).ToList();
                    break;
                default:
                    MealItem = MealItem.OrderBy(s => s.Food.Name).ToList();
                    break;
            }
        }
    }
}
