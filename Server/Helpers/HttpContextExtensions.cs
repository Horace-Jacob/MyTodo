using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Helpers
{
    public static class HttpContextExtensions
    {
        public static async Task PageParameters<T>(this HttpContext httpContext, IQueryable<T> queryable, int pageSize)
        {
            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / pageSize);
            httpContext.Response.Headers.Add("pagesQuantity", pagesQuantity.ToString());
           
        }
    }
}