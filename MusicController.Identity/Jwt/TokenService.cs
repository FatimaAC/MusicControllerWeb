using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MusicController.Common.Constants;
using MusicController.Identity.Constant;
using MusicController.Identity.IdentityContext;
using MusicController.Identity.Model;
using MusicController.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MusicController.Identity.Jwt
{
    public  class TokenServices : ITokenServices
    {
       
        private readonly ApplicationDbContext _applicationDbContext;
        public TokenServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public AuthenticateResponse Authenticate(long outletId ,string deviceId, string ipAddress)
        {
           
            var jwtToken = GenerateJwtToken(outletId , deviceId, ipAddress);
            var refreshToken = GenerateRefreshToken(ipAddress);
            refreshToken.OutletId = outletId;
            refreshToken.DeviceId = deviceId;
            AddRefreshToken(refreshToken);
            return new AuthenticateResponse(jwtToken, refreshToken.Token);
        }

        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            var refreshToken = GetRefreshToken(token);
            // replace old refresh token with a new one and save
            var newRefreshToken = GenerateRefreshToken(ipAddress);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            _applicationDbContext.Update(refreshToken);
            // generate new jwt
            var jwtToken = GenerateJwtToken(refreshToken.OutletId ,refreshToken.DeviceId ,ipAddress);

            return new AuthenticateResponse(jwtToken, newRefreshToken.Token);
        }

        public bool RevokeToken(string token, string ipAddress)
        {
            var refreshToken = GetRefreshToken(token);
            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            UpdateRefreshToken(refreshToken);
            return true;
        }

        // helper methods
        private string GenerateJwtToken(long outletId, string deviceId, string ipAddress)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtConstant.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("OutletId", outletId.ToString()),
                    new Claim("DeviceId", deviceId.ToString()),
                    new Claim("IpAddress", ipAddress)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.UtcNow.AddDays(8),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }

        private void AddRefreshToken(RefreshToken applicationToken)
        {
            _applicationDbContext.Add(applicationToken);
            _applicationDbContext.SaveChanges();
        }
        private void UpdateRefreshToken(RefreshToken applicationToken)
        {
            _applicationDbContext.Entry(applicationToken).State = EntityState.Modified;
            _applicationDbContext.SaveChanges();
        }

        private RefreshToken GetRefreshToken(string token)
        {
            var refreshToken = _applicationDbContext.RefreshTokens.FirstOrDefault(e => e.Token == token);
            if (refreshToken==null)
            {
                throw new Exception("No refresh Token Found");
            }
            if (!refreshToken.IsActive)
            {
                throw new Exception("Token expire");
            }
              
            return refreshToken;

        }

    }
}
