using CloudStorage.BLL.Interfaces.DTO;
using CloudStorage.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudStorage.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        private IUserService _userService;

        [HttpGet]
        public ActionResult Login()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult Registration(UserCreateDTO userCreated)
        {
            long id = _userService.Registration(userCreated);
            return Json(id);
        }

        [HttpPut]
        [Authorize]
        public ActionResult Update(UserUpdateDTO userUpdated)
        {
            _userService.UpdateUser(userUpdated);
            return Ok();
        }
    }
}
