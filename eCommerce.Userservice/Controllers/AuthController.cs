using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Userservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IUserService _userService;
        public readonly IValidator<LoginRequest> _validator;
        public readonly IValidator<RegisterRequest> _Regivalidator;
        public AuthController(IUserService userService,IValidator<LoginRequest> validator, IValidator<RegisterRequest> regivalidator)
        {
            _userService = userService;
            _validator = validator;
            _Regivalidator = regivalidator;
        }
        /// <summary>
        /// Authenticate user and return user details and token
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Invalid login data");
            }
            var validation = _validator.Validate(loginRequest);
            if (!validation.IsValid)
            {
                return Unauthorized(validation.ToDictionary());
            }
            AuthenticationResponse? LoginResponse = await _userService.Login(loginRequest);
            if (LoginResponse == null || !LoginResponse.success)
            {
                return Unauthorized("Please validate login credentials");
            }
            return Ok(LoginResponse);
        }

        /// <summary>
        /// Register the user
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest("Invalid registration data");
            }
            var validation = _Regivalidator.Validate(registerRequest);
            if (!validation.IsValid)
            {
                return Unauthorized(validation.ToDictionary());
            }
            AuthenticationResponse? registrationResponse = await _userService.Register(registerRequest);
            if (registrationResponse == null || !registrationResponse.success)
            {
                return Unauthorized("Please validate registration details");
            }
            return Ok(registrationResponse);
        }
        
    }
}
