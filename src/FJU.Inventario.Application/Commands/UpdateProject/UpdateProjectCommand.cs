using FJU.Inventario.Application.Common.ValidatePermision;
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
        private IVerifyPermission Permission { get; }
        #endregion

        #region Constructor
        public UpdateProjectCommand(
            ILogger<UpdateProjectCommand> logger,
            IVerifyPermission permission,
            IProjectRepository projectRepository)
        {
            Logger = logger;
            Permission = permission;
            ProjectRepository = projectRepository;
        }
        #endregion

        #region Implementation Handler
        public async Task<UpdateProjectResponse> Handle(UpdateProjectRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (await Permission.IsCoordenate())
                {
                    throw new UnprocessableEntityException("User higher hierarchical level required");
                }

                var currentProject = await ProjectRepository.GetProjectNameAsync(request?.Name);

                if (currentProject is not null && currentProject.Id != request.Id)
                {
                    throw new UnprocessableEntityException("Project already exists");
                }

                if (request.CoordinatorId != currentProject.CoordinatorId)
                {
                    throw new UnprocessableEntityException("you not have permissionfot this operation");
                }

                await ProjectRepository.UpdateAsync((ProjectEntity)request);

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
