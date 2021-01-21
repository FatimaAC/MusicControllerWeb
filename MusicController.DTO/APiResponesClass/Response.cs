using MusicController.Common.Enumerration;
using Newtonsoft.Json;

namespace MusicController.DTO.APiResponesClass
{
    public class Response<T>
    {
     
        public string Message { get; set; }
        public T Data { get; set; }
        public StatusApiEnum StatusCode { get; set; }
        
        public Response(T data)
        {
            Message = Message;
            StatusCode = StatusApiEnum.Success;
            Data = data;
        }
        public Response(string message, StatusApiEnum statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}
