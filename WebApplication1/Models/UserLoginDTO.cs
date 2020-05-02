using System.ComponentModel.DataAnnotations;

namespace CloudStorage.BLL.Interfaces.Models
{
    public class UserLoginDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
