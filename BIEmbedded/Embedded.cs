using BIEmbedded.Components;
using BIEmbedded.Requests;
using BIEmbedded.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BIEmbedded
{
    public class Embedded
    {

        public async Task<RespAccessToken> AccessTokenAsync(string ClientId, string Username, string Password)
        {
            var Params = new ReqAccessToken
            {
                GrantType = "password",
                Scope = "openid",
                Resource = "https://analysis.windows.net/powerbi/api",
                ClientId = ClientId,
                Username = Username,
                Password = Password
            };
            
            var api = new RestClient("https://login.microsoftonline.com");
            var request = new RestRequest("/common/oauth2/token", Method.GET)
                  .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                  .AddParameter("grant_type", Params.GrantType, ParameterType.GetOrPost)
                  .AddParameter("scope", Params.GrantType, ParameterType.GetOrPost)
                  .AddParameter("resource", Params.Resource, ParameterType.GetOrPost)
                  .AddParameter("client_id", Params.ClientId, ParameterType.GetOrPost)
                  .AddParameter("username", Params.Username, ParameterType.GetOrPost)
                  .AddParameter("password", Params.Password, ParameterType.GetOrPost);
        

           var response = await api.PostAsync<RespAccessToken>(request);
            
            return response;
        }
        
        
        
        public async Task<RespEmbeddedToken> EmbeddedTokenAsync(string bearerToken, string Username, string groupID, string reportID, string dataSets)
        {
            List<string> datasets = new List<string>();
            datasets.Add(dataSets);

            List<string> report = new List<string>();
            report.Add(reportID);

            Identities Ident = new Identities();
            Ident.Username = Username;
            Ident.DataSets = datasets;
            Ident.Reports = report;

            List<Identities> ListIdent = new List<Identities>();
            ListIdent.Add(Ident);

            var Params = new ReqEmbeddedToken
            {
                accessLevel = "View",
                identities = new List<Identities>(ListIdent)
            };

            var json = JsonConvert.SerializeObject(Params, Formatting.None);

            var api = new RestClient("https://api.powerbi.com");
            var request = new RestRequest("/v1.0/myorg/groups/{groupID}/reports/{reportID}/GenerateToken",Method.POST)
                    .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                    .AddHeader("Authorization", string.Format("Bearer {0}", bearerToken))
                    .AddParameter("groupID", groupID, ParameterType.UrlSegment)
                    .AddParameter("reportID", reportID, ParameterType.UrlSegment)
                    .AddJsonBody(json);

            var response = await api.PostAsync<RespEmbeddedToken>(request);
 
            return response;
        }  
    }
}
