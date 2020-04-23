using System.ComponentModel.DataAnnotations;

namespace CloudStorage.BLL.Interfaces.DTO
{
    public class UserLoginDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
