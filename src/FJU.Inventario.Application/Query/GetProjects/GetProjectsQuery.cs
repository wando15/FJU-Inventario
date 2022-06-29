using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FJU.Inventario.Application.Query.GetProjects
{
    public class GetProjectsQuery : IRequestHandler<GetProjectsRequest, GetProjectsResponse>
    {
        #region Properties
        private ILogger<GetProjectsQuery> Logger { get; }
        private IProjectRepository Repository { get; }
        #endregion

        #region Constructor
        public GetProjectsQuery(
            ILogger<GetProjectsQuery> logger,
            IProjectRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation Handler
        public async Task<GetProjectsResponse> Handle(GetProjectsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var projects = await Repository.GetAsync();

                if (projects is null)
                {
                    throw new NotFoundException("Projects not found");
                }

                return new GetProjectsResponse
                {
                    Result = new BaseResult<IList<ProjectEntity>>()
                    {
                        IsSuccess = true,
                        Message = "these is projects found",
                        StatusCode = HttpStatusCode.OK,
                        Data = projects
                    }
                };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw;
            }
        }
        #endregion
    }
}
