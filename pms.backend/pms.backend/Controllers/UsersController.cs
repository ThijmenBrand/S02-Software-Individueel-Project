using Microsoft.AspNetCore.Mvc;
using BusinessLayer.services.Users;
using Authorization;
using AutoMapper;
using DataLayer.models.users;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ApiLayer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUsersService _usersService;
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;

        public UsersController(IUsersService usersService, IMapper mapper, IJwtUtils jwtUtils)
        {
            _usersService = usersService;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest request)
        {
            var user = _usersService.FindUser(request.UserEmail);

            if (user == null || !_usersService.ValidatePassword(request.Password, user.UserPassword))
                return Unauthorized("Username or password incorrect");

            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Authenticate(RegisterRequest request)
        {
            _usersService.Register(request);
            return Ok(new {message = "Registration successfull"});
        }

        [HttpGet]
        public IActionResult GetMe()
        {
            int UserId = int.Parse(User.FindFirstValue("UserId"));
            var user = _usersService.GetMe(UserId);
            return Ok(user);
        }

        [HttpPut("{UserId}")]
        public IActionResult UpdateUser(int UserId, updateRequest request)
        {
            _usersService.UpdateUser(UserId, request);
            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("{UserId}")]
        public IActionResult DeleteUser(int UserId)
        {
            _usersService.DeleteUser(UserId);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
