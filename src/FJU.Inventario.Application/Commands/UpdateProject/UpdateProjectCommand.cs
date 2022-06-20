using FJU.Inventario.Application.Common.ValidateCoordenate;
using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequestHandler<UpdateProjectRequest, UpdateProjectResponse>
    {
        #region Properties
        private ILogger<UpdateProjectCommand> Logger { get; }
        private IProjectRepository ProjectRepository { get; }
        private IVerifyUserCoordenate VerifyUserCoordenate { get; }
        #endregion

        #region Constructor
        public UpdateProjectCommand(
            ILogger<UpdateProjectCommand> logger,
            IVerifyUserCoordenate verifyUserCoordenate,
            IProjectRepository projectRepository)
        {
            Logger = logger;
            VerifyUserCoordenate = verifyUserCoordenate;
            ProjectRepository = projectRepository;
        }
        #endregion

        #region Implementation Handler
        public async Task<UpdateProjectResponse> Handle(UpdateProjectRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var currentProject = await ProjectRepository.GetProjectNameAsync(request?.Name);

                if (currentProject != null && currentProject.Id != request.Id)
                {
                    throw new UnprocessableEntityException("Project already exists");
                }

                if (request.CoordinatorId != currentProject.CoordinatorId)
                {
                    if (await VerifyUserCoordenate.IsCoordenate(request.CoordinatorId))
                    {
                        throw new UnprocessableEntityException("user not found or higher hierarchical level required");
                    }
                }

                await ProjectRepository.UpdateAsync(request.Id, (ProjectEntity)request);

                return (UpdateProjectResponse)(ProjectEntity)request;
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
