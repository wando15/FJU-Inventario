using FJU.Inventario.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Common.ValidateCoordenate
{
    public class VerifyUserCoordenate : IVerifyUserCoordenate
    {
        #region Properties
        public ILogger<VerifyUserCoordenate> Logger { get; set; }
        public IUserRepository UserRepository { get; set; }

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
