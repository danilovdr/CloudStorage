using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using CloudStorage.BLL.Interfaces.Models;

namespace CloudStorage.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        private IUserService _userService;

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO user)
        {
            bool hasUser = _userService.HasUser(user.Name, user.Password);

            if (hasUser)
            {
                await Authenticate(user.Name);
            }
            else
            {
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return Json(ModelState);
        }

        [HttpPut]
        public IActionResult Register(CreateUserDTO userCreated)
        {
            _userService.Registration(userCreated);
            return Ok();
        }

        private async Task Authenticate(string userName)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
