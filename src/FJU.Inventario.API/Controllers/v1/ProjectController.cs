using FJU.Inventario.Application.Commands.CreateProject;
using FJU.Inventario.Application.Commands.RemoveProject;
using FJU.Inventario.Application.Commands.UpdateProject;
using FJU.Inventario.Application.Query.GetProjectById;
using FJU.Inventario.Application.Query.GetProjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FJU.Inventario.API.Controllers.v1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProjectController : Controller
    {
        private ILogger<ProjectController> Logger { get; }
        private IMediator Mediator { get; }

        public ProjectController(ILogger<ProjectController> logger,
            IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }

        /// <summary>
        /// Create Project
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin,coordenator")]
        [ProducesResponseType(typeof(CreateProjectResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send createProject:", request);
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Get All Projects
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(GetProjectsResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send GetProjects");
            var result = await Mediator.Send(new GetProjectsRequest(), cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Get Project By Id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(GetProjectByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromRoute] GetProjectByIdParams param, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send GetProject by Id: {param.Id}");
            var result = await Mediator.Send(param, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Delete Project By Id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,coordenator")]
        [ProducesResponseType(typeof(RemoveProjectResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] RemoveProjectParams param, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send DeleteProject by Id: {param.Id}");
            var result = await Mediator.Send(param, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Update Project
        /// </summary>
        /// <param name="param"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,coordenator")]
        [ProducesResponseType(typeof(UpdateProjectResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] RemoveProjectParams param, [FromBody] UpdateProjectRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Send UpdateProject by Id: {param}");
            request.Id = param.Id;
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }
    }
}