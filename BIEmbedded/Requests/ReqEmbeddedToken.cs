using BIEmbedded.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIEmbedded.Requests
{
    public class ReqEmbeddedToken
    {
        [JsonProperty(PropertyName = "accessLevel")]
        public string accessLevel { get; set; }

        [JsonProperty(PropertyName = "identities")]
        public List<Identities> identities { get; set; }

    }
}
