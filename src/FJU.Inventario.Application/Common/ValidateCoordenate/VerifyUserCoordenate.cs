using FJU.Inventario.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Common.ValidateCoordenate
{
    public class VerifyUserCoordenate : IVerifyUserCoordenate
    {
        #region Properties
        private ILogger<VerifyUserCoordenate> Logger { get; }
        private IUserRepository UserRepository { get; }

        #endregion

        #region Constructor
        public VerifyUserCoordenate(
            ILogger<VerifyUserCoordenate> logger,
            IUserRepository userRepository)
        {
            Logger = logger;
            UserRepository = userRepository;
        }
        #endregion

        #region Methods
        public async Task<bool> IsCoordenate(string CoordinatorId)
        {
            try
            {
                var validateUser = await UserRepository.GetAsync(CoordinatorId);

                if (validateUser is null || !validateUser.IsCoordinator)
                {
                    return false;
                }

                return true;
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
