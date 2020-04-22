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
        public ActionResult Registration(UserCreatedDTO userCreated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            long id = _userService.Registration(userCreated);
            return Json(id);
        }

        [HttpPut]
        [Authorize]
        public ActionResult Update(UserUpdatedDTO userUpdated)
        {
            string name = User.Identity.Name;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userService.UpdateUserInfo(userUpdated);
            return Ok();
        }
    }
}
