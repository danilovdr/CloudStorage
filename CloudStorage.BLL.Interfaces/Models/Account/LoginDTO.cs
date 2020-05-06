using System.ComponentModel.DataAnnotations;

namespace CloudStorage.BLL.Interfaces.Models.Account
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}
