using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Shared.ExpectionHelper
{
    public class UserFriendlyException : Exception
    {
        public int StatusCode { get; set; }
        public string Error { get; set; }
        public UserFriendlyException(Exception ex, int statusCode = 500) : base(ex.Message)
        {
            StatusCode = statusCode;
        }
        public UserFriendlyException(string Message, int statusCode = 500) : base(Message)
        {
            StatusCode = statusCode;
        }
    }
}
