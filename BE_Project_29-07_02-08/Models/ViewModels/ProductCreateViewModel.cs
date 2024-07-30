namespace BE_Project_29_07_02_08.Models.ViewModels
{
    public class ProductCreateViewModel
    {
        public Product Product { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<int> SelectedIngredientIds { get; set; } = new List<int>();

    }
}