using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MusicController.Identity.UserService
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        public string UserRole => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
        public string DeviceId => _httpContextAccessor.HttpContext?.User?.FindFirstValue("DeviceId");
        public string OutletId => _httpContextAccessor.HttpContext?.User?.FindFirstValue("OutletId");
    }
}
