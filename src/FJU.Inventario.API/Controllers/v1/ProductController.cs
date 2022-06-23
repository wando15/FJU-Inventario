using FJU.Inventario.Application.Commands.CreateProduct;
using FJU.Inventario.Application.Commands.RemoveProduct;
using FJU.Inventario.Application.Commands.UpdateProduct;
using FJU.Inventario.Application.Query.GetProductById;
using FJU.Inventario.Application.Query.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FJU.Inventario.API.Controllers.v1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private ILogger<ProductController> Logger { get; set; }
        private IMediator Mediator { get; set; }

        public ProductController(ILogger<ProductController> logger,
            IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateProductResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send createProduct:", request);
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetProductsResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(GetProductsRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send GetProducts");
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetProductByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromRoute] GetProductByIdParams request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send GetProduct by Id: {request.Id}");
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Delete Product By Id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RemoveProductResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductParams request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send DeleteProduct by Id: {request.Id}");
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="param"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateProductResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] RemoveProductParams param, [FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send UpdateProduct by Id: {param}");
            request.Id = param.Id;
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }
}
}
