using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.OutletServices;
using MusicController.DTO.RequestModel;
using MusicController.Identity.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicController.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IOutletService _outletService;
        public AccountsController(IOutletService outletService)
        {
            _outletService = outletService;
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(LoginRequest loginRequest)
        {
            try
            {
                string token = string.Empty;
                var Isverify = await _outletService.ValidateOutletandDevice(loginRequest);
                if (Isverify)
                {
                    token = TokenService.CreateToken(loginRequest.OutletId, loginRequest.DeviceId);
                }
                return Ok(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken(string token, string refreshToken)
        {
            var principal = TokenService.GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;
            //var savedRefreshToken = TokenService.GetRefreshToken(username); //retrieve the refresh token from a data store
            //if (savedRefreshToken != refreshToken)
            //    throw new SecurityTokenException("Invalid refresh token");

            var newJwtToken = TokenService.CreateToken(1 ,2+"");
            var newRefreshToken = TokenService.GenerateRefreshToken();

            return new ObjectResult(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        }
    }
}
