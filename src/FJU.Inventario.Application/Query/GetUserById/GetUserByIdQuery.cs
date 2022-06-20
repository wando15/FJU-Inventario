using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Query.GetUserById
{
    public class GetUserByIdQuery : IRequestHandler<GetUserByIdParams, GetUserByIdResponse>
    {
        #region Properties
        private ILogger<GetUserByIdQuery> Logger { get; }
        private IUserRepository Repository { get; }
        #endregion

        #region Constructor
        public GetUserByIdQuery(
            ILogger<GetUserByIdQuery> logger,
            IUserRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation Handler
        public async Task<GetUserByIdResponse> Handle(GetUserByIdParams request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await Repository.GetAsync(request?.Id);

                if(user is null)
                {
                    throw new NotFoundException("User not found");
                }

                return (GetUserByIdResponse)user;
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
