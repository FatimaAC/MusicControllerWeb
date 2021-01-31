using MusicController.Common.Enumerration;
using System;

namespace MusicController.Shared.ExpectionHelper
{
    // Override Expection
    public class UserFriendlyException : Exception
    {
        public StatusApiEnum StatusCode { get; set; }
        public string Error { get; set; }
        public UserFriendlyException(Exception ex, StatusApiEnum statusCode = StatusApiEnum.InternalServerError) : base(ex.Message)
        {
            StatusCode = statusCode;
        }
        public UserFriendlyException(string Message, StatusApiEnum statusCode = StatusApiEnum.InternalServerError) : base(Message)
        {
            StatusCode = statusCode;
        }
    }
}
