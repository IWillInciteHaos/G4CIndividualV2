using System.ComponentModel.DataAnnotations;

namespace OrangesAndChocolate.DTO
{
    public class UpdatePermissionDTO
    {
        [Required]
        public string Username { get; set; }
    }
}
