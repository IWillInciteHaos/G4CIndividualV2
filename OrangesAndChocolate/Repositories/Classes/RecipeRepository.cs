using Microsoft.EntityFrameworkCore;
using OrangesAndChocolate;
using OrangesAndChocolateB.DTOs;
using OrangesAndChocolateB.Models;
using OrangesAndChocolateB.Repositories.Interfaces;
using System.Collections.Immutable;
using System.Linq;

namespace OrangesAndChocolateB.Repositories.Classes
{
    public class RecipeRepository : IRecipeRepository
    {
        public readonly OACDBContext _repository;
        public RecipeRepository(OACDBContext context)
        {
            _repository = context;
        }
        
        public async Task CreateRecipe(Recipe r)
        {
            await _repository.Recipes.AddAsync(r);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteRecipe(Recipe r)
        {
            _repository.Update(r);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<Recipe>> GetAllRecipes(int amount = 20)
        {
            //add paging?
            return await _repository.Recipes.Where(r=>r.isActive).ToListAsync();
        }

        //complicate your life and make it multiple?
        public async Task<List<Recipe>> GetByIngredient(string ingredient)
        {
            var retVal = new List<Recipe>();
            var ingredients = await _repository.Ingredients.Include(i=>i.Recipe).GroupBy(i => i.Name).ToListAsync();
            if(ingredients == null)
            {
                return null;
            }
            foreach (var ingr in ingredients)
            {
                foreach (var i in ingr)
                {
                    if(i.Name.Contains(ingredient) && !retVal.Contains(i.Recipe))
                    {
                        retVal.Add(i.Recipe);
                    }
                }
            }  

            return retVal;
            
        }
        /*
        public async Task<List<Recipe>> GetRecipesByIngredients(IEnumerable<Ingredient> i)
        {
            return await _repository.Recipes.Where(r => r.Ingredients.(i));
        }*/

        public async Task<Recipe> GetOneRecipeById(int id)
        {
            return await _repository.Recipes.Include(r => r.Ingredients).Where(r => r.ID == id && r.isActive).FirstOrDefaultAsync();
        }

        public async Task<Recipe> GetOneRecipeByName(string name)
        {
            return await _repository.Recipes.Where(rec => rec.Name == name && rec.isActive).FirstOrDefaultAsync();
        }

        /*
        public async Task<List<Recipe>> GetUsersRecipes(int userID)
        {
            return await _repository.Recipes.Where(r=> r.CreatorID == userID && r.isActive).ToListAsync();
        }*/        
    }
}
