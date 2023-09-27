using OrangesAndChocolateB.DTOs;
using OrangesAndChocolateB.Models;

namespace OrangesAndChocolateB.Services.Interfaces
{
    public interface IRecipeService
    {
        public Task<List<RecipeCreateDTO>> GetAllRecipes(int amount = 20);
        public Task<RecipeCreateDTO> GetOneRecipeById(int id);
        public Task<RecipeCreateDTO> CreateRecipe(RecipeCreateDTO rDTO);
        public Task<RecipeCreateDTO> DeleteRecipe(string rDTO);
        public Task<RecipeCreateDTO> GetOneRecipeByName(string name);
        public Task<List<RecipeCreateDTO>> GetByIngredient(string ingredient);
    }
}
