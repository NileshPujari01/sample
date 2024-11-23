using Koperasi.API.Commands;
using Koperasi.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Koperasi.API.Controllers
{
    /// <summary>
    /// Provides all activities related to user. e.g registration, login, OTP verification
    /// </summary>
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(
            ILogger<UserController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Registers the user based on request parameters
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Returns RegisterUserResponse</returns>
        [HttpPost("registerUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        /// <summary>
        /// Login user based on LoginUserRequest
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Returns LoginUserResponse</returns>
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserQuery request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        /// <summary>
        /// Resend OTP functionality after OTP verification timeout
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Returns ResendOTPResponse</returns>
        [HttpPost("resendOTP")]
        public async Task<IActionResult> ResendOTP([FromBody] ResendOTPQuery request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
