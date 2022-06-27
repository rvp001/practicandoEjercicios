using System.ComponentModel.DataAnnotations;

namespace PrimeraAPI.BusinessModels.Models.Users
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
