using System.Text.Json;
using Techwiz.Errors;

namespace Techwiz.Utilities
{
    public class ErrorHelper
    {
        public static async Task SendErrorResponseAsJson(HttpResponse response, int statusCode, BaseError error)
        {  
            response.StatusCode = statusCode;
            response.ContentType = "application/json";
            var json = JsonSerializer.Serialize(error);
            await response.WriteAsync(json);
        }
    }
}