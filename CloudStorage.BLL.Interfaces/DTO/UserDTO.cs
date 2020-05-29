using System;

namespace CloudStorage.BLL.Interfaces.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
