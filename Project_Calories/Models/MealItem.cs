using System.Diagnostics.Metrics;

namespace Project_Calories.Models
{
    public class MealItem
    {
        public int MealItemId { get; set; }

        public int? MemberId { get; set; }
        public Member? Member { get; set; }
        public int? MealId { get; set; }
        public Meal? Meal { get; set; }

        public int? FoodId { get; set; }
        public Food? Food { get; set; }

        public int Quantity { get; set; }
        public DateTime Date { get; set; }

    }
}
