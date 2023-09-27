using OrangesAndChocolateB.Models;
using System.ComponentModel.DataAnnotations;

namespace OrangesAndChocolateB.DTOs
{
    //would look the same created and sent out
    public class RecipeCreateDTO
    {
        [Required]
        public string CratorUsername { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<IngredientCreateDTO> Ingredients { get; set; }
        [Required]
        public string Directions { get; set; }

        public RecipeCreateDTO()
        {
            Ingredients = new List<IngredientCreateDTO>();   
        }
        public RecipeCreateDTO(string name)
        {
            Ingredients = new List<IngredientCreateDTO>();  
            Name = name;
        }

    }
}
