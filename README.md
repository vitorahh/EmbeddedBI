<h1 align="center">
 📊 <strong>Embedded | BI</strong>
</h1>

# :rocket: Tecnologias
Esse projeto foi desenvolvido com as seguintes tecnologias:

- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/)
- [Newtonsoft](https://www.newtonsoft.com/json)
- [RestSharp](http://restsharp.org/)

## 💻 Projeto
Um pacote de DLL com 2 funções essenciais para aquisição do AccessToken de autenticação Microsoft e de EmbeddedToken para autenticação Microsoft no power BI Embedded, logo a baixo você vera mais sobre como chamar estas 2 funções lembrando que alem da DLL BIEmbedded e preciso ter os 2 pacotes [Newtonsoft](https://www.newtonsoft.com/json) e [RestSharp](http://restsharp.org/) instalados no seu projeto.


```
Embedded BI = new Embedded();

var response = JsonConvert.SerializeObject(BI.AccessTokenAsync("{APLICATION_ID}", "{EMAIL-POWERBI}", "{SENHA-POWERBI}").Result);
JObject AccessJson = JObject.Parse(response);
RespAccessToken Resp = JsonConvert.DeserializeObject<RespAccessToken>(AccessJson.ToString());

var TokenEmbedded = JsonConvert.SerializeObject(BI.EmbeddedTokenAsync(Resp.AccessToken, "{EMAIL-POWERBI}", "{GROUP_ID}", "{REPORT_ID}", "{DATASETS_ID}").Result);
JObject json = JObject.Parse(TokenEmbedded);
RespEmbeddedToken Embedded = JsonConvert.DeserializeObject<RespEmbeddedToken>(TokenEmbedded);
 
Console.WriteLine(Embedded.Token);
Console.ReadKey();

```

<br/>
<p align="center">Feito por Willian Gomes Vitor durante as aulas da semana OmniStack</center>


