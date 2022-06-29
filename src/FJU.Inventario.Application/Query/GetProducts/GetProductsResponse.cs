using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Query.GetProducts
{
    public class GetProductsResponse
    {
        public BaseResult<IList<ProductEntity>>? Result { get; set; }
    }
}
