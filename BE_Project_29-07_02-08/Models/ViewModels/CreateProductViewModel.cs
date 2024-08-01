namespace BE_Project_29_07_02_08.Models.ViewModels
{
    public class CreateProductViewModel
    {
        public required Product Product { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<int> SelectedIngredientIds { get; set; } = new List<int>();

        public IFormFile? Image { get; set; }
    }
}