using MusicController.Identity.Model;

namespace MusicController.Identity.Jwt
{
    public interface ITokenServices
    {
        AuthenticateResponse Authenticate(long outletId, string deviceId, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        bool RevokeToken(string token, string ipAddress);
    }
}
