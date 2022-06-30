using FJU.Inventario.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Common.ValidatePermision
{
    public class VerifyPermission : IVerifyPermission
    {
        #region Properties
        private ILogger<VerifyPermission> Logger { get; }
        private IUserRepository UserRepository { get; }
        private IHttpContextAccessor Context { get; }

        #endregion

        #region Constructor
        public VerifyPermission(
            ILogger<VerifyPermission> logger,
            IUserRepository userRepository,
            IHttpContextAccessor context)
        {
            Logger = logger;
            UserRepository = userRepository;
            Context = context;
        }
        #endregion

        #region Methods
        public async Task<bool> IsCoordenate()
        {
            try
            {
                var validateUser = await UserRepository.GetAsync(Context.HttpContext.Request.Headers["UserId"]);

                return !(validateUser is not null && validateUser.IsCoordinator);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<bool> IsAdmin()
        {
            try
            {
                var validateUser = await UserRepository.GetAsync(Context.HttpContext.Request.Headers["UserId"]);

                return !(validateUser is not null && validateUser.IsAdmin);
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
