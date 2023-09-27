using System.ComponentModel.DataAnnotations;

namespace OrangesAndChocolateB.DTOs
{
    public class IngredientSearchDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
