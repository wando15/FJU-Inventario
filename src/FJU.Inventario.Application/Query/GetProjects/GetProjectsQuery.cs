using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

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
                var Projects = await Repository.GetAsync();

                if (Projects is null)
                {
                    throw new NotFoundException("Projects not found");
                }

                return (GetProjectsResponse)Projects;
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
