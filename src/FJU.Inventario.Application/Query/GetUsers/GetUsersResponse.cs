using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Application.Query.GetUsers
{
    public class GetUsersResponse
    {
        public BaseResult<IList<UserEntity>>? Result { get; set; }
    }
}
