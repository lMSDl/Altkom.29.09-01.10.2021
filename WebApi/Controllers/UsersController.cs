using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize(Policy = "Admin")]
    public class UsersController : BaseCrudController<User>
    {
        private AuthService _authService;
        public UsersController(IService<User> service, AuthService authService) : base(service)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(User user)
        {
            var token = _authService.Authenticate(user.Login, user.Password);
            if (token == null)
                return BadRequest();
            return Ok(token);
        }

        [AllowAnonymous]
        public override IActionResult Get(int id)
        {
            return base.Get(id);
        }
    }
}
