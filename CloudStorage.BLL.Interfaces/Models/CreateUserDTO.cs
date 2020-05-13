using System.ComponentModel.DataAnnotations;

namespace CloudStorage.BLL.Interfaces.Models
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(25, MinimumLength = 7, ErrorMessage = "Длина пароля должна быть от 7 до 25 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указано подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли на совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
