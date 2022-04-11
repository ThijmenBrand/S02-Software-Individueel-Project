using System.Security.Claims;

namespace ApiLayer.Helpers
{
    public class GetUserId
    {
        private static HttpContext _httpContext => new HttpContextAccessor().HttpContext;
        public static int getUserId()
        {
            return int.Parse(_httpContext.User.FindFirstValue("UserId"));
        }
    }
}
