using System.Security.Policy;
using System.Diagnostics.Metrics;

namespace Project_Calories.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int? CategorieId { get; set; }
        public Categorie? Categorie { get; set; }
    }
}
