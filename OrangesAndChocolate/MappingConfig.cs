using AutoMapper;
using OrangesAndChocolateB.DTOs;
using OrangesAndChocolateB.Models;

namespace OrangesAndChocolateB
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Recipe, RecipeCreateDTO>().ReverseMap();
            CreateMap<Ingredient, IngredientCreateDTO>().ReverseMap();

        }
    }
}
