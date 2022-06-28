using FJU.Inventario.Application.Commands.MoveInventory;
using FJU.Inventario.Application.Commands.ReturnedInventory;
using FJU.Inventario.Application.Query.GetClosedMovimentInventory;
using FJU.Inventario.Application.Query.GetOpenedMovimentInventory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FJU.Inventario.API.Controllers.v1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MoveInventoryController : Controller
    {
        private ILogger<ProductController> Logger { get; set; }
        private IMediator Mediator { get; set; }

        public MoveInventoryController(ILogger<ProductController> logger,
            IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }

        /// <summary>
        /// Create Moviment Repository - withdrawal
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(MoveInventoryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMoviment([FromBody] MoveInventoryRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send Moviment Inventory:", request);
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Get Opened Moves
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("Opened")]
        [ProducesResponseType(typeof(GetOpenedMovimentInventoryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOpenedMoves([FromBody] GetOpenedMovimentInventoryRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Get Opened Moviment Inventory:", request);
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Get Closed Moves
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("Closed")]
        [ProducesResponseType(typeof(GetClosedMovimentInventoryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetClosedMoves([FromBody] GetClosedMovimentInventoryRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Get Closed Moviment Inventory:", request);
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Update Moviment Inventory - returned
        /// </summary>
        /// <param name="param"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("returned/{id}")]
        [ProducesResponseType(typeof(ReturnedInventoryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateMoviment([FromRoute] ReturnedInventoryParams param, [FromBody] ReturnedInventoryRequest request, CancellationToken cancellationToken)
        {
            request.Id = param.Id;
            Logger.LogInformation($"Send Moviment Inventory:", request);
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }
    }
}
