using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIEmbedded.Components
{
    public class Identities
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "reports")]
        public List<string> Reports { get; set; }

        [JsonProperty(PropertyName = "datasets")]
        public List<string> DataSets { get; set; }
    }
}
