using System.Security.Claims;

namespace ProductApi.Helpers
{
    public static class ClaimHelper
    {
        public static int GetUserId(ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public static string GetRole(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Role);
        }
    }
}
