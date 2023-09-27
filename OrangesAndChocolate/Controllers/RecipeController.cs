using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrangesAndChocolate.DTO;
using OrangesAndChocolateB.DTOs;
using OrangesAndChocolateB.Services.Interfaces;
using System.Data;

namespace OrangesAndChocolateB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        
        public readonly IRecipeService _recipeService;
        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [Authorize(Roles = StaticUserRoles.User)]
        [HttpPost("create_recipe")]
        public async Task<ActionResult<RecipeCreateDTO>> CreateRecipe(RecipeCreateDTO rDTO)
        {
            var retVal = await _recipeService.CreateRecipe(rDTO);

            return retVal is null ? BadRequest("No such user.") : Ok(retVal);
        }

        [HttpGet("get_recipes")]
        public async Task<ActionResult<RecipeCreateDTO>> GetAllRecipes([FromQuery] int amount)
        {
            var retVal = await _recipeService.GetAllRecipes(amount);

            return retVal is null ? BadRequest("No recipes.") : Ok(retVal);
        }

        [HttpGet("get_one_by_name")]
        public async Task<ActionResult<RecipeCreateDTO>> GetRecipeByName([FromQuery] string name)
        {
            var retVal = await _recipeService.GetOneRecipeByName(name);

            return retVal is null ? BadRequest("No such recipe.") : Ok(retVal);
        }

        [Authorize(Roles = StaticUserRoles.User)]
        [HttpDelete("delete_recipe")]
        public async Task<ActionResult<RecipeCreateDTO>> DeleteRecipe(string recipeName)
        {
            var retVal = await _recipeService.DeleteRecipe(recipeName);

            return retVal is null ? BadRequest("No such recipe.") : Ok(retVal);
        }

        [HttpGet("filter_by_ingredient")]
        public async Task<ActionResult<RecipeCreateDTO>> FilterByIngredient([FromQuery]string ingredient)
        {
            var retVal = await _recipeService.GetByIngredient(ingredient);

            return retVal is null ? BadRequest("No igredients.") 
                : (retVal.Count == 0 ? BadRequest("No such recipe.") : Ok(retVal));
        }
    }
}
