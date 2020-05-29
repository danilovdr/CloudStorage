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
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

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

       
    }
}
