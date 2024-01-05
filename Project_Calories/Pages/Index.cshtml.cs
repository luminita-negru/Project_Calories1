using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Project_Calories.Data; // Assuming this is your DbContext namespace

namespace Project_Calories.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Project_CaloriesContext _context; // Assuming ApplicationDbContext is your DbContext

        public IndexModel(ILogger<IndexModel> logger, Project_CaloriesContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            // Get the current user's member ID (you may need to implement user authentication)
            int memberId = GetCurrentMemberId(); // Implement this method as per your authentication mechanism

            // Get the current user's calorie goal
            var calorieGoal = _context.Member.Where(m => m.MemberId == memberId).Select(m => m.CaloriesGoal).FirstOrDefault();

            // Get statistics for the current user
            var lunchCalories = GetTotalCaloriesForMealType(memberId, "Lunch");
            var breakfastCalories = GetTotalCaloriesForMealType(memberId, "Breakfast");
            var snacksCalories = GetTotalCaloriesForMealType(memberId, "Snacks");

            // Calculate remaining calories for the day
            var remainingCalories = calorieGoal - (lunchCalories + breakfastCalories + snacksCalories);

            // You can now pass these values to the view using ViewData or a ViewModel
            ViewData["CalorieGoal"] = calorieGoal;
            ViewData["LunchCalories"] = lunchCalories;
            ViewData["BreakfastCalories"] = breakfastCalories;
            ViewData["SnacksCalories"] = snacksCalories;
            ViewData["RemainingCalories"] = remainingCalories;
        }

        private int GetCurrentMemberId()
        {
            // Implement your logic to get the current user's member ID
            // This could be based on user authentication
            // For example, if you are using ASP.NET Identity, you might do something like:
            // return _userManager.GetUserId(User);
            return 1; // Placeholder value, replace with your implementation
        }

        private int GetTotalCaloriesForMealType(int memberId, string mealType)
        {
            // Implement your logic to get the total calories for a specific meal type
            // This involves querying the MealItem and related tables
            // You can use LINQ to perform the necessary calculations
            // For example:
            return _context.MealItem
                .Where(mi => mi.MemberId == memberId && mi.Meal.Name == mealType)
                .Sum(mi => mi.Food.Calories);
        }
    }
}

