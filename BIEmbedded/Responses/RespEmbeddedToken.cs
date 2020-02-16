using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIEmbedded.Responses
{
    public class RespEmbeddedToken
    {
        [JsonProperty("@odata.context")]
        public string context { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("tokenId")]
        public string TokenId { get; set; }

        [JsonProperty("expiration")]
        public string Expiration { get; set; }
    }
}
