using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Calories.Data;
using Project_Calories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            try
            {
                // Retrieve the current user
                CurrentUser = await _context.Member.FirstOrDefaultAsync(m => m.Email == User.Identity.Name);

                if (CurrentUser != null)
                {
                    // Calculate total calories consumed
                    var mealItemsQuery = _context.MealItem
                        .Where(item => item.MemberId == CurrentUser.MemberId && item.Date.Date == DateTime.Today);

                    if (mealItemsQuery != null)
                    {
                        var totalCaloriesQuery = mealItemsQuery.Select(item => item.Quantity * item.Food.Calories);
                        TotalCaloriesConsumed = totalCaloriesQuery.Any() ? await totalCaloriesQuery.SumAsync() : 0;
                    }
                    else
                    {
                        // Log an error or handle the situation where mealItemsQuery is null
                    }

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
                        .GroupBy(item => item.Meal?.Name)
                        .ToDictionary(
                            group => group.Key,
                            group => group.Sum(item => item.Quantity * (item.Food?.Calories ?? 0))
                        );

                    // Ensure that CaloriesPerMeal is not null
                    CaloriesPerMeal ??= new Dictionary<string, int>();
                }
                else
                {
                    // Log an error or handle the situation where CurrentUser is null
                }
            }
            catch (Exception ex)
            {
                // Log the exception for further analysis
                // You can use logging frameworks like Serilog, NLog, or just Console.WriteLine
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}

