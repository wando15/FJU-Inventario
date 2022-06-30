using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Infrastructure.CunstomException;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace FJU.Inventario.CrossCutting.Middleware.Authorization
{
    public class VerifyAuthorizationHandler
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly RequestDelegate Next;

        public VerifyAuthorizationHandler(
            RequestDelegate next)
        {
            Next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (!context.Request.Path.Value.ToLower().Contains("login"))
                {
                    var Token = context.Request.Headers.Authorization.ToString();

                    if (!Token.Contains("Bearer"))
                    {
                        throw new UnauthorizedException("access not allowed");
                    }

                    Token = DecodeFrom64(Token.Replace("Bearer ", ""));

                    var userInfo = System.Text.Json.JsonSerializer.Deserialize<AccessToken>(Token);

                    if (userInfo.Validate < DateTime.UtcNow)
                    {
                        throw new UnauthorizedException("Session expired");
                    }

                    context.Request.Headers.Add("UserId", userInfo.UserId);
                }
                await Next(context);
            }
            catch (Exception)
            {
                throw;
            }
        }

        static public string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(encodedData);
            string returnValue = ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);

            return returnValue;
        }

        private static long ConvertToTimestamp(DateTime value)
        {
            TimeSpan elapsedTime = value - Epoch;
            return (long)elapsedTime.TotalSeconds;
        }

        private static long AddTime(long value)
        {
            var dat_Time = DateTime.MinValue;
            dat_Time.AddHours(6);
            return ConvertToTimestamp(dat_Time.AddSeconds(value));
        }
    }
}