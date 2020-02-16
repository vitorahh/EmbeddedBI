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

## 🎯 Code
O exemplo a baixo e de como fazer a chamada da API e Deserializar ela em um Objeto RespAccessToken e RespEmbeddedToken
ou você pode usar JSON with LINQ Exemplo AccessJson["access_token"].ToString(); para pegar a informação de dentro da resposta sem necessariamente ter uma classe so para deserialização.
Obs.: Mais a baixo deixo o codigo das 2 classes para deserializar.
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

- <strong>APLICATION_ID</strong>: ID de Aplicação que e gerado pelo Azure
- <strong>EMAIL-POWERBI</strong>: Email da conta que possue o serviço de Embedded do Power BI
- <strong>SENHA-POWERBI</strong>: Senha da conta que possue o serviço de Embedded do Power BI
- <strong>GROUP_ID</strong>: Tambem conhecido como Workspace_ID do Report que seja Embeddar
- <strong>REPORT_ID></strong>: ID do report que deseja Embeddar

## 📎 Em caso de Duvidas
[Power BI API Documentação](https://docs.microsoft.com/en-us/rest/api/power-bi/embedtoken)
[Willian Gomes Vitor](https://www.linkedin.com/in/vitorwillian/)

<br/>
<p align="center">Feito por Willian Gomes Vitor em um Sabado Qualquer...</center>


