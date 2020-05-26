using CloudStorage.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using CloudStorage.WEB.ViewModels;
using CloudStorage.BLL.Interfaces.DTO;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;

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

        [HttpPost]
        public async Task<IActionResult> Login(AuthorizeViewModel user)
        {
            Guid id = _userService.GetUserId(user.Name, user.Password);
            await Authenticate(id);
            UserViewModel userViewModel = new UserViewModel()
            {
                Id = id,
                Name = user.Name
            };
            return Json(userViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> Register(RegistrationViewModel user)
        {
            UserDTO userDTO = new UserDTO()
            {
                Name = user.Name,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword
            };
            Guid id = _userService.Registration(userDTO);
            await Authenticate(id);
            UserViewModel userViewModel = new UserViewModel()
            {
                Id = id,
                Name = user.Name
            };
            return Json(userViewModel);
        }

        [HttpGet ("isAuthorize")]
        public bool IsAuthorize()
        {
            return HttpContext.User.Identity.IsAuthenticated;
        }

        [Authorize]
        [HttpGet]
        [Route("getUsername")]
        public IActionResult GetUserName()
        {
            Guid id = Guid.Parse(HttpContext.User.Identity.Name);
            string name = _userService.GetUserName(id);
            return Json(name);
        }

        private async Task Authenticate(Guid id)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, id.ToString())
            };

            ClaimsIdentity claimId = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimId));
        }
    }
}
