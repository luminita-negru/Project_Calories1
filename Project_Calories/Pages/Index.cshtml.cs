using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project_Calories.Data; // Assuming this is your DbContext namespace
using Project_Calories.Models;

namespace Project_Calories.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Project_CaloriesContext _context;

        public IndexModel(Project_CaloriesContext context)
        {
            _context = context;
        }

        public Member CurrentUser { get; set; }
        public int TotalCaloriesConsumed { get; set; }
        public int CaloriesGoal { get; set; }
        public Dictionary<string, int> CaloriesPerMeal { get; set; }

        public async Task OnGetAsync()
        {
            // Retrieve the current user
            CurrentUser = await _context.Member.FirstOrDefaultAsync(m => m.Email == User.Identity.Name);

            // Calculate total calories consumed
            TotalCaloriesConsumed = await _context.MealItem
                .Where(item => item.MemberId == CurrentUser.MemberId && item.Date.Date == DateTime.Today)
                .SumAsync(item => item.Quantity * item.Food.Calories);

            // Get calories goal
            CaloriesGoal = CurrentUser.CaloriesGoal;

            // Fetch meal items for the current user and date
            var mealItems = await _context.MealItem
                .Include(item => item.Meal)
                .Include(item => item.Food)
                .Where(item => item.MemberId == CurrentUser.MemberId && item.Date.Date == DateTime.Today)
                .ToListAsync();

            // Calculate calories per meal using client-side evaluation
            CaloriesPerMeal = mealItems
                .GroupBy(item => item.Meal.Name)
                .ToDictionary(
                    group => group.Key,
                    group => group.Sum(item => item.Quantity * item.Food.Calories)
                );
        }
    }
}

