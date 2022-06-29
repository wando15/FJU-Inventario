using System.Net;

namespace FJU.Inventario.Domain.Entities
{
    public class BaseResult<TResult>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public TResult? Data { get; set; }



    }
}
