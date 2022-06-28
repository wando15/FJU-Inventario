using FJU.Inventario.Application.Commands.CreateUser;
using FJU.Inventario.Application.Commands.RemoveUser;
using FJU.Inventario.Application.Commands.UpdateUser;
using FJU.Inventario.Application.Query.GetUserById;
using FJU.Inventario.Application.Query.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FJU.Inventario.API.Controllers.v1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private ILogger<UserController> Logger { get; set; }
        private IMediator Mediator { get; set; }

        public UserController(ILogger<UserController> logger,
            IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateUserResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send createUser:", request);
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetUsersResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(GetUsersRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send GetUsers");
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="param"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetUserByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromRoute] GetUserByIdParams param, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send GetUser by Id: {param.Id}");
            var result = await Mediator.Send(param, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Delete User By Id
        /// </summary>
        /// <param name="param"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RemoveUserResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] RemoveUserParams param, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send DeleteUser by Id: {param.Id}");
            var result = await Mediator.Send(param, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="param"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateUserResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] RemoveUserParams param, [FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send UpdateUser by Id: {param}");
            request.Id = param.Id;
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }
    }
}