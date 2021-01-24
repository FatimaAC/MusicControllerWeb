using MusicController.Common.Enumerration;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MusicController.DTO.APiResponesClass
{
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
            StatusCode = StatusApiEnum.Failure;
        }
        public override string ToString()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            return JsonSerializer.Serialize(this , options);
        }
    }
}
