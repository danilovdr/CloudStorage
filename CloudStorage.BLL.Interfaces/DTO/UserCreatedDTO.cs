using System.ComponentModel.DataAnnotations;

namespace CloudStorage.BLL.Interfaces.DTO
{
    public class UserCreatedDTO
    {
        [Required (ErrorMessage = "Не указано имя пользователя")]
        public string Name { get; set; }
        
        [Required (ErrorMessage = "Не указан email")]
        [EmailAddress (ErrorMessage = "Некорректный email адрес")]
        public string Email { get; set; }
        
        [Required (ErrorMessage = "Не указан пароль")]
        [StringLength (25, MinimumLength = 7, ErrorMessage = "Длина пароля должна быть от 7 до 25 символов")]
        public string Password { get; set; }

        [Required (ErrorMessage = "Не указано подтверждение пароля")]
        [Compare ("Password", ErrorMessage = "Пароли на совпадают")]
        public string ConfirmPassowrd { get; set; }
    }
}
