using FJU.Inventario.Application.Commands.MoveInventory;
using FJU.Inventario.Application.Commands.ReturnedInventory;
using FJU.Inventario.Application.Query.GetClosedMovimentInventory;
using FJU.Inventario.Application.Query.GetClosedMovimentInventoryByProductId;
using FJU.Inventario.Application.Query.GetOpenedMovimentInventory;
using FJU.Inventario.Application.Query.GetOpenedMovimentInventoryByProductId;
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
        private ILogger<ProductController> Logger { get; }
        private IMediator Mediator { get; }
        private HttpContextAccessor Context { get; }

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

            request.UserId = Context.HttpContext.Request.Headers["UserId"].ToString();
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
        public async Task<IActionResult> GetOpenedMoves(CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Get Opened Moviment Inventory");
            var result = await Mediator.Send(new GetOpenedMovimentInventoryRequest(), cancellationToken);

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
        public async Task<IActionResult> GetClosedMoves(CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Get Closed Moviment Inventory");
            var result = await Mediator.Send(new GetClosedMovimentInventoryRequest(), cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Get Opened Moves by product
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("Opened/{id}")]
        [ProducesResponseType(typeof(GetOpenedMovimentInventoryByProductIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOpenedMovesByProductId([FromRoute] GetOpenedMovimentInventoryByProductIdParams request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Get Opened Moviment Inventory for product:", request);
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Get Closed Moves by product
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("Closed/{id}")]
        [ProducesResponseType(typeof(GetClosedMovimentInventoryByProductIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetClosedMovesByProductId([FromRoute] GetClosedMovimentInventoryByProductIdParams request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Get Closed Moviment Inventory for product:", request);
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
