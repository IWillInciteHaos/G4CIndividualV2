using OrangesAndChocolateB.DTOs;
using OrangesAndChocolateB.Models;

namespace OrangesAndChocolateB.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
                                                 //za paginaciju
        public Task<List<Recipe>> GetAllRecipes(int amount = 20);
        public Task<Recipe> GetOneRecipeById(int id);
        public Task CreateRecipe(Recipe r);
        public Task DeleteRecipe(Recipe r);
        public Task<Recipe> GetOneRecipeByName(string name);
        //public Task<List<Recipe>> GetUsersRecipes(int userID);
        public Task<List<Recipe>> GetByIngredient(string ingredient);
        //public Task<List<Recipe>> GetRecipesByIngredients(IEnumerable<Ingredient> i);
    }
}
