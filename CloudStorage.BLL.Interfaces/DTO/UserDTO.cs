using System;
using System.ComponentModel.DataAnnotations;

namespace CloudStorage.BLL.Interfaces.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указано подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
