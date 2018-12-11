using System.ComponentModel.DataAnnotations;

namespace APISmartCity.Model
{
    public class LoginModel
    {
        [Required]
        public string Username {get; set; }
        [Required]
        public string Password {get; set; }
    }
}