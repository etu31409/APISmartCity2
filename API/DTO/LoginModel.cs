using System.ComponentModel.DataAnnotations;
namespace APISmartCity.DTO
{
public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}