using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Calories.Data;
using Project_Calories.Models;

namespace Project_Calories.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly Project_Calories.Data.Project_CaloriesContext _context;

        public IndexModel(Project_Calories.Data.Project_CaloriesContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get;set; } = default!;

        public string FoodSort { get; set; }
        public string CategorieSort { get; set; }
        //
        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            //
            FoodSort = String.IsNullOrEmpty(sortOrder) ? "food_desc" : "";
            CategorieSort = sortOrder == "categorie" ? "categorie_desc" : "categorie";
            if (_context.Food != null)
            {
                Food = await _context.Food
                .Include(f => f.Categorie).ToListAsync();
            }

            CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                Food = Food.Where(s => s.Name.Contains(searchString)
                    || s.Categorie.Name.Contains(searchString))
                    .ToList();
            }
            //
            switch (sortOrder)
            {
                case "food_desc":
                    Food = Food.OrderByDescending(s => s.Name).ToList();
                    break;
                case "categorie_desc":
                    Food = Food.OrderByDescending(s => s.Categorie.Name).ToList();
                    break;
                case "categorie":
                    Food = Food.OrderBy(s => s.Categorie.Name).ToList();
                    break;
                default:
                    Food = Food.OrderBy(s => s.Name).ToList();
                    break;
            }
        }
    }
}
