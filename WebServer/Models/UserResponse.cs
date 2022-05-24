using System.Text.Json.Serialization;

namespace WebServer.Models
{
    public class BaseResponse
    {
        public int Page { get; set; }
        public int Total { get; set; }
        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
    }

    public class UserResponse : BaseResponse
    {
        public IList<Data> Data { get; set; } = default!;
    }

    public class Data
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; } = default!;

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; } = default!;

        [JsonPropertyName("last_name")]
        public string LastName { get; set; } = default!;

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; } = default!;
    }
}
