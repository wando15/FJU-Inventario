using FJU.Inventario.Application.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FJU.Inventario.API.Controllers.v1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : Controller
    {
        private ILogger<LoginController> Logger { get; }
        private IMediator Mediator { get; }

        public LoginController(ILogger<LoginController> logger,
            IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send createLogin:", request);
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }
    }
}