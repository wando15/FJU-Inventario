using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Query.GetProjectById
{
    public class GetProjectByIdQuery : IRequestHandler<GetProjectByIdParams, GetProjectByIdResponse>
    {
        #region Properties
        private ILogger<GetProjectByIdQuery> Logger { get; }
        private IProjectRepository Repository { get; }
        #endregion

        #region Constructor
        public GetProjectByIdQuery(
            ILogger<GetProjectByIdQuery> logger,
            IProjectRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation Handler
        public async Task<GetProjectByIdResponse> Handle(GetProjectByIdParams request, CancellationToken cancellationToken)
        {
            try
            {
                var project = await Repository.GetAsync(request?.Id);

                if (project is null)
                {
                    throw new NotFoundException("Projects not found");
                }

                return (GetProjectByIdResponse)project;
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
