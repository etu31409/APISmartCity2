using System.ComponentModel.DataAnnotations;
namespace APISmartCity.DTO
{
public class LoginModelDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}