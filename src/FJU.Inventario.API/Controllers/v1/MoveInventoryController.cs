using FJU.Inventario.Application.Commands.MoveInventory;
using FJU.Inventario.Application.Commands.ReturnedInventory;
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
        /// Update Moviment Inventory - returned
        /// </summary>
        /// <param name="param"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
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
