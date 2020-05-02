using System.ComponentModel.DataAnnotations;

namespace CloudStorage.BLL.Interfaces.Models
{
    public class UpdateUserDTO
    {
        [Required]
        public long Id { get; set; }
        [EmailAddress(ErrorMessage = "Некорректный email адрес")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(25, MinimumLength = 7, ErrorMessage = "Длина пароля должна быть от 7 до 25 символов")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
