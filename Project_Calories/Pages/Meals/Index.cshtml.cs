﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Project_Calories.Data.Project_CaloriesContext _context;

        public IndexModel(Project_Calories.Data.Project_CaloriesContext context)
        {
            _context = context;
        }

        public IList<Meal> Meal { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Meal != null)
            {
                Meal = await _context.Meal.ToListAsync();
            }
        }
    }
}
