using System;
using BIEmbedded;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleLog
{
    class Program
    {
        static void Main(string[] args)
        {

            Embedded BI = new Embedded();

            var response = JsonConvert.SerializeObject(BI.AccessTokenAsync("{APLICATION_ID}", "{EMAIL-POWERBI}", "{SENHA-POWERBI}").Result);
            JObject AccessJson = JObject.Parse(response);
            RespAccessToken Resp = JsonConvert.DeserializeObject<RespAccessToken>(AccessJson.ToString());

            var TokenEmbedded = JsonConvert.SerializeObject(BI.EmbeddedTokenAsync(Resp.AccessToken, "{EMAIL-POWERBI}", "{GROUP_ID}", "{REPORT_ID}", "{DATASETS_ID}").Result);
            JObject json = JObject.Parse(TokenEmbedded);
            RespEmbeddedToken Embedded = JsonConvert.DeserializeObject<RespEmbeddedToken>(TokenEmbedded);
 
            Console.WriteLine(Embedded.Token);
            Console.ReadKey();
        }
    }
}
