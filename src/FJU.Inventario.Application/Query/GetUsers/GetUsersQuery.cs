using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Query.GetUsers
{
    public class GetUsersQuery : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        #region Properties
        private ILogger<GetUsersQuery> Logger { get; }
        private IUserRepository Repository { get; }
        #endregion

        #region Constructor
        public GetUsersQuery(
            ILogger<GetUsersQuery> logger,
            IUserRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation Handler
        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await Repository.GetAsync();

                if (users is null || users.Count < 1)
                {
                    throw new NotFoundException("no user found");
                }

                return (GetUsersResponse)users;
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
