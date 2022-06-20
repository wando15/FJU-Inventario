using FJU.Inventario.Application.Common.ValidateCoordenate;
using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Commands.CreateProject
{
    public class CreateProjectCommand : IRequestHandler<CreateProjectRequest, CreateProjectResponse>
    {
        #region Properties
        private ILogger<CreateProjectCommand> Logger { get; }
        private IProjectRepository ProjectRepository { get; }
        private IVerifyUserCoordenate VerifyUserCoordenate { get; }
        #endregion

        #region Constructor
        public CreateProjectCommand(
            ILogger<CreateProjectCommand> logger,
            IVerifyUserCoordenate verifyUserCoordenate,
            IProjectRepository projectRepository)
        {
            Logger = logger;
            VerifyUserCoordenate = verifyUserCoordenate;
            ProjectRepository = projectRepository;
        }
        #endregion

        #region Implementation Handler
        public async Task<CreateProjectResponse> Handle(CreateProjectRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var existisProject = await ProjectRepository.GetProjectNameAsync(request?.Name);

                if (existisProject != null)
                {
                    throw new UnprocessableEntityException("Project already exists");
                }

                if(await VerifyUserCoordenate.IsCoordenate(request.CoordinatorId))
                {
                    throw new UnprocessableEntityException("user not found or higher hierarchical level required");
                }

                var newProject = await ProjectRepository.CreateAsync((ProjectEntity)request);

                if (newProject is null)
                {
                    throw new UnprocessableEntityException("Failed to create Project");
                }

                return (CreateProjectResponse)newProject;
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
