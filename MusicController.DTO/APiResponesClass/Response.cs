using MusicController.Common.Enumerration;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MusicController.DTO.APiResponesClass
{
    // APi generic Response Class
    public class Response<T>
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("data")]
        public T Data { get; set; }
        [JsonPropertyName("statusCode")]
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
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
