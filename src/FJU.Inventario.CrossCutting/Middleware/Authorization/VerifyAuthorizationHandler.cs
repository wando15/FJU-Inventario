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

                    if (ConvertToTimestamp(DateTime.UtcNow) < ConvertToTimestamp(AddTime(userInfo.Timestamp)))
                    {
                        throw new UnauthorizedException("access not allowed");
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

        private static DateTime AddTime(long value)
        {
            DateTime dat_Time = new DateTime(1965, 1, 1, 0, 0, 0, 0);
            dat_Time.AddDays(1);
            return dat_Time.AddSeconds(value);
        }
    }
}
