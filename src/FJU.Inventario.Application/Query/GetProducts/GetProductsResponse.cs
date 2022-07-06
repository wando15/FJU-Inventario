using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Application.Query.GetProducts
{
    public class GetProductsResponse
    {
        public BaseResult<IList<ProductEntity>>? Result { get; set; }
    }
}
