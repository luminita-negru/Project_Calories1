using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_Calories.Models;

namespace Project_Calories.Data
{
    public class Project_CaloriesContext : DbContext
    {
        public Project_CaloriesContext (DbContextOptions<Project_CaloriesContext> options)
            : base(options)
        {
        }

        public DbSet<Project_Calories.Models.Food> Food { get; set; } = default!;

        public DbSet<Project_Calories.Models.Categorie>? Categorie { get; set; }

        public DbSet<Project_Calories.Models.Meal>? Meal { get; set; }

        public DbSet<Project_Calories.Models.MealItem>? MealItem { get; set; }

        public DbSet<Project_Calories.Models.Member>? Member { get; set; }
    }
}
