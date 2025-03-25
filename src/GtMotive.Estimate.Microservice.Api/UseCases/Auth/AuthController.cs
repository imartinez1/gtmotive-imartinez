using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Identity;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Auth
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthController"/> class.
    /// </summary>
    /// <param name="userManager">UserManager.</param>
    /// <param name="authService">authService.</param>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(UserManager<User> userManager, IAuthService authService) : ControllerBase
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IAuthService _authService = authService;

        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="signUpRequest">request with email and password.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserSignUpResource signUpRequest)
        {
            if (signUpRequest == null)
            {
                return BadRequest();
            }

            var user = new User() { Email = signUpRequest.Email, UserName = signUpRequest.Email };
            var userCreateResult = await _userManager.CreateAsync(user, signUpRequest.Password);

            return userCreateResult.Succeeded ? Ok() : Problem(userCreateResult.Errors.First().Description, null, 500);
        }

        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="loginRequest">login request with mail and password.</param>
        /// <returns>token.</returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginResource loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest();
            }

            var user = _userManager.Users.SingleOrDefault(u => u.UserName == loginRequest.Email);
            if (user is null)
            {
                return NotFound("User not found");
            }

            var userSigninResult = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            return userSigninResult ? Ok(_authService.GenerateJwt(user)) : BadRequest("Email or password incorrect.");
        }
    }
}
