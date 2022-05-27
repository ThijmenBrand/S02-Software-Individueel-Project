using System.Security.Claims;

namespace ApiLayer.Helpers
{
    public static class GetUserId
    {
#pragma warning disable CS8603 // Possible null reference return.
        private static HttpContext _httpContext => new HttpContextAccessor().HttpContext;
#pragma warning restore CS8603 // Possible null reference return.
        public static int getUserId()
        {
            return int.Parse(_httpContext.User.FindFirstValue("UserId"));
        }
    }
}
