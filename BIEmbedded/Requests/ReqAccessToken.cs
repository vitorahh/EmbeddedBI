using Newtonsoft.Json;

namespace BIEmbedded.Requests
{
    public class ReqAccessToken
    {
        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType { get; set; }

        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }

        [JsonProperty(PropertyName = "resource")]
        public string Resource { get; set; }

        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
