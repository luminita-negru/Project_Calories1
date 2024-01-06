using System.ComponentModel.DataAnnotations;

namespace Project_Calories.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$",
        ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau AnaMaria")]
        [StringLength(30, MinimumLength = 3)]
        public string? FirstName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string? LastName { get; set; }
        [StringLength(70)]
        public string? Address { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^0\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([09]{3})$",
        ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
        public string? Phone { get; set; }
        [Display(Name = "Full Name")] public string? FullName { get { return FirstName + " " + LastName; } }
        public ICollection<MealItem>? MealItem { get; set; }

        public int CaloriesGoal {  get; set; }
    }
}
