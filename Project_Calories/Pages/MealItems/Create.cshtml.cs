using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Calories.Data;
using Project_Calories.Models;

namespace Project_Calories.Pages.MealItems
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public List<SelectListItem> AvailableMeals { get; set; }

        [BindProperty]
        public List<int> SelectedMeals { get; set; } = new List<int>();

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

        public Member CurrentUser { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            CurrentUser = await _context.Member.FirstOrDefaultAsync(m => m.Email == User.Identity.Name);
            if(CurrentUser == null)
            {
                throw new Exception();
            }
            if (!ModelState.IsValid || _context.MealItem == null || MealItem == null)
            {
                return Page();
            }
            MealItem.MemberId = CurrentUser.MemberId;
            _context.MealItem.Add(MealItem);
            await _context.SaveChangesAsync();

            var mealsFromDatabase = await _context.Meal.ToListAsync(); // Schimbați cu obținerea datelor din baza de date
            AvailableMeals = mealsFromDatabase.Select(m => new SelectListItem { Value = m.MealId.ToString(), Text = m.Name }).ToList();

            return RedirectToPage("./Index");
        }
    }
}
