using BE_Project_29_07_02_08.Models;

namespace BE_Project_29_07_02_08.Services.Ingredients
{
    public interface IIngredientService
    {
        Task<Ingredient> CreateIngredient(Ingredient ingredient);

    }
}
