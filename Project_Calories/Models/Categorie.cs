﻿namespace Project_Calories.Models
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        public string Name { get; set; }
        
        public ICollection<Food>? Foods { get; set; }
    }
}
