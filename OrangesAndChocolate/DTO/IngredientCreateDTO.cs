using Microsoft.AspNetCore.Mvc;
using OrangesAndChocolateB.Models;
using System.ComponentModel.DataAnnotations;

namespace OrangesAndChocolateB.DTOs
{
    public class IngredientCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public Unit Units { get; set; }

    }
}
