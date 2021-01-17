using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MusicController.Identity.Model
{
    public class AuthenticateResponse
    {
        public string JwtToken { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }

        public AuthenticateResponse( string jwtToken, string refreshToken)
        {
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}
