using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project_Calories.Models
{
    public class CreateModel : PageModel
    {
        // Alte proprietăți existente

        [BindProperty]
        public List<SelectListItem> AvailableMeals { get; set; }

        [BindProperty]
        public List<int> SelectedMeals { get; set; } = new List<int>();
    }

}
