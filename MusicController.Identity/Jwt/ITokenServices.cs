using MusicController.Identity.Model;
using MusicController.Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Identity.Jwt
{
   public  interface ITokenServices
    {
        AuthenticateResponse Authenticate(long outletId, string deviceId, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        bool RevokeToken(string token, string ipAddress);
        
        // string GenerateToken(long outletId, string deviceId, string ipAddress);
        // RefreshToken ValidateRefreshToken(string token);
        //bool RevokeToken(string token, string ipAddress);
        // RefreshToken GenerateRefreshToken(string ipAddress);
        // void AddRefreshToken(RefreshToken applicationToken);
        // RefreshToken RefreshToken(string token, string ipAddress);
        // void UpdateRefreshToken(RefreshToken applicationToken);
    }
}
