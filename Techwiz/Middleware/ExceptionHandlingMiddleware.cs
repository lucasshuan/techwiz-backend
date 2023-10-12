using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Techwiz.Errors;
using Techwiz.Utilities;

namespace Techwiz.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DbUpdateException ex) when (IsDuplicateEntryException(ex))
            {
                await ErrorHelper.SendErrorResponseAsJson(context.Response, 409, new DuplicateEntryError());
            }
            catch
            {
                await ErrorHelper.SendErrorResponseAsJson(context.Response, 500, new InternalServerError());
            }
        }

        private bool IsDuplicateEntryException(DbUpdateException ex) =>
            ex?.InnerException is MySqlException mysqlEx && 
            mysqlEx.Number == (int)MySqlErrorCode.DuplicateKeyEntry;
    }
}