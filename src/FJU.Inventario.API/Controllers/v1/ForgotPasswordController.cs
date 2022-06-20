using FJU.Inventario.Application.Commands.ForgotPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FJU.Inventario.API.Controllers.v1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ForgotPasswordController : Controller
    {

        private ILogger<ForgotPasswordController> Logger { get; set; }
        private IMediator Mediator { get; set; }

        public ForgotPasswordController(ILogger<ForgotPasswordController> logger,
            IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ForgotPasswordResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send createForgotPassword:", request);
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }
    }
}