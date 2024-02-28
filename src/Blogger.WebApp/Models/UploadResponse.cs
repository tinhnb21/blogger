using System.Text.Json.Serialization;

namespace Blogger.WebApp.Models
{
    public class UploadResponse
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }
    }
}
