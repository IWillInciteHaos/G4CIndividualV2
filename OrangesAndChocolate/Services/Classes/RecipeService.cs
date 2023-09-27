using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using OrangesAndChocolate.DTO;
using OrangesAndChocolateB.DTOs;
using OrangesAndChocolateB.Models;
using OrangesAndChocolateB.Repositories.Interfaces;
using OrangesAndChocolateB.Services.Interfaces;
using System.Data;

namespace OrangesAndChocolateB.Services.Classes
{

    public class RecipeService : IRecipeService
    {
        public readonly IRecipeRepository _recipeRepository;
        public readonly IMapper _mapper;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<RecipeCreateDTO> CreateRecipe(RecipeCreateDTO rDTO)
        {


            var tempRec = _mapper.Map<Recipe>(rDTO);
            tempRec.CreatorUsername = rDTO.CratorUsername;
            tempRec.isActive = true;

            foreach (var ingr in tempRec.Ingredients)
            {
                ingr.Recipe = tempRec;
                ingr.RecipieID = tempRec.ID;
                ingr.isActive = true;
            }

            await _recipeRepository.CreateRecipe(tempRec);

            //redundant?
            return rDTO;

            //this doesn't matter here
            /*
            var tempRec = await _recipeRepository.GetOneRecipeByName(rDTO.Name);
            if(tempRec != null)
            {
                return new RecipeCreateDTO("recipe exists?");
            }*/

        }

        public async Task<RecipeCreateDTO> DeleteRecipe(string rName)
        {
            var tempRec = await _recipeRepository.GetOneRecipeByName(rName);
            if (tempRec == null || !tempRec.isActive)
            {
                return null;
            }

            foreach (var ingr in tempRec.Ingredients)
            {
                ingr.isActive = false;
            }
            tempRec.isActive = false;

            await _recipeRepository.DeleteRecipe(tempRec);

            return _mapper.Map<RecipeCreateDTO>(tempRec);
        }

        public async Task<List<RecipeCreateDTO>> GetAllRecipes(int amount = 20)
        {
            return _mapper.Map<List<RecipeCreateDTO>>(await _recipeRepository.GetAllRecipes());
        }

        public async Task<List<RecipeCreateDTO>> GetByIngredient(string ingredient)
        {
            var retVal = await _recipeRepository.GetByIngredient(ingredient);
            if (retVal == null)
            {
                return null;
            }
            return _mapper.Map<List<RecipeCreateDTO>>(retVal);
        }

        public async Task<RecipeCreateDTO> GetOneRecipeById(int id)
        {
            return _mapper.Map<RecipeCreateDTO>(await _recipeRepository.GetOneRecipeById(id));
        }

        public async Task<RecipeCreateDTO> GetOneRecipeByName(string name)
        {
            return _mapper.Map<RecipeCreateDTO>(await _recipeRepository.GetOneRecipeByName(name));
        }
    }
}
