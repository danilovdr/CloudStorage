using System.ComponentModel.DataAnnotations;

namespace CloudStorage.BLL.Interfaces.DTO
{
    public class UserUpdatedDTO
    {
        [Required]
        long Id { get; set; }

        [EmailAddress(ErrorMessage = "Некорректный email адрес")]
        string Email { get; set; }

        [StringLength(25, MinimumLength = 7, ErrorMessage = "Длина пароля должна быть от 7 до 25 символов")]
        string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        string ConfirmNewPassword { get; set; }
    }
}
