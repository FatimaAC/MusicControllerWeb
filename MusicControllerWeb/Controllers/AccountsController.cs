using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.OutletServices;
using MusicController.DTO.APiResponesClass;
using MusicController.DTO.RequestModel;
using MusicController.Identity.Jwt;
using MusicController.Identity.Model;
using System;
using System.Threading.Tasks;


namespace MusicControllerWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IOutletService _outletService;
        private readonly ITokenServices _tokenServices;
        public AccountsController(IOutletService outletService, ITokenServices tokenServices)
        {
            _outletService = outletService;
            _tokenServices = tokenServices;

        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<Response<AuthenticateResponse>> Authenticate(LoginRequest loginRequest)
        {
            await _outletService.ValidateOutletandDevice(loginRequest);
            var token = _tokenServices.Authenticate(loginRequest.OutletId, loginRequest.DeviceId, IpAddress());
            SetTokenCookie(token.RefreshToken);
            var respone = new Response<AuthenticateResponse>(token);
            return respone;
        }

        [AllowAnonymous]
        [HttpGet("RefreshToken")]
        public Response<AuthenticateResponse> RefreshToken()
        {
            var refreshToken = _tokenServices.RefreshToken(Request.Cookies["refreshToken"], IpAddress());
            SetTokenCookie(refreshToken.RefreshToken);
            var respone = new Response<AuthenticateResponse>(refreshToken);
            return respone;
        }

        [HttpGet("RevokeToken")]
        public IActionResult RevokeToken([FromBody] RevokeTokenRequest model)
        {
            // accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            var response = _tokenServices.RevokeToken(token, IpAddress());

            if (!response)
                return NotFound(new { message = "Token not found" });

            return Ok(new { message = "Token revoked" });
        }

        //helper Method
        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(14)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
