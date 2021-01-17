using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.DTO.DTOModel
{
    public class TokenDTo
    {
        public string Token { get; set; }
        public RefreshTokenDTO RefreshTokenDTO { get; set; }
    }

    public class RefreshTokenDTO
    {
        public string RefreshToken { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
    }
}
