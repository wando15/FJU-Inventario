using FJU.Inventario.Infrastructure.CunstomException;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace FJU.Inventario.CrossCutting.Middleware.ExceptionHandler
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate Next;

        public ErrorHandlerMiddleware(
            RequestDelegate next)
        {
            Next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (Exception error)
            {
                switch (error)
                {
                    case NotFoundException:
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                            break;
                        }
                    case UnauthorizedException:
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            break;
                        }
                    case UnprocessableEntityException:
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                            break;
                        }
                    case Exception:
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            break;
                        }
                    default:
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            break;
                        }
                }

                context.Response.ContentType = "application/json";
                var json = new
                {
                    context.Response.StatusCode,
                    Message = error?.Message,
                    Detailed = error
                };

                var result = JsonConvert.SerializeObject(json);

                await context.Response.WriteAsync(result);
            }
        }
    }
}
