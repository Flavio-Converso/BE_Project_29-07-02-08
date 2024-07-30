using BE_Project_29_07_02_08.Models;

namespace BE_Project_29_07_02_08.Services.Ingredients
{
    public interface IIngredientService
    {
        public Ingredient CreateIngredient(Ingredient ingredient);
        // already in IProductService    public List<Ingredient> GetAllIngredients(int IdProduct);
    }
}
