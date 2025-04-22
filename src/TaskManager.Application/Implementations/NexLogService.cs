using TaskManager.Application.Interfaces;
using TaskManager.Core.DTO.NexLog.Request;
using TaskManager.Core.DTO.NexLog.Response;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace TaskManager.Application.Implementations
{
    public class NexLogService : INexLogService
    {
        private readonly HttpClient _httpClient;

        public NexLogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método para autenticar e obter o token
        public TokenResponse GetAuthenticationToken(string companyKey, string language, NexLogAuthenticationRequest authRequest)
        {
            var content = new StringContent(JsonConvert.SerializeObject(authRequest), Encoding.UTF8, "application/json");

            // Add companyKey and language to the headers
            _httpClient.DefaultRequestHeaders.Add("CompanyKey", companyKey);
            _httpClient.DefaultRequestHeaders.Add("Language", language);

            var response = _httpClient.PostAsync(Environment.GetEnvironmentVariable("API_TAREFAS__NexLogSettings__UrlAuth"), content).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TokenResponse>(jsonResponse);
            }
            else
            {
                throw new Exception($"Falha ao autenticar: {response.StatusCode}");
            }
        }

        public QuotationResponse QuotationRequest(QuotationRequest quotationRequest, TokenResponse tokenResponse)
        {

            var urlBase = Environment.GetEnvironmentVariable("API_TAREFAS__NexLogSettings__UrlBase");
            var requestUri = urlBase + "/sales/transportorder/quotation";

            // Serializar o objeto quotationRequest para JSON com as opções de camelCase
            var jsonContent = System.Text.Json.JsonSerializer.Serialize(quotationRequest, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = content
            };

            // Adicionar os headers necessários
            requestMessage.Headers.Add("accept", "application/json");
            requestMessage.Headers.Add("companyKey", "G3");
            requestMessage.Headers.Add("sessionId", tokenResponse.SessionId);
            requestMessage.Headers.Add("sessionToken", tokenResponse.SessionToken);
            requestMessage.Headers.Add("language", "pt-BR");

            var response = _httpClient.Send(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<List<QuotationResponse>>(jsonResponse);

                return data.FirstOrDefault();

            }
            else
            { 
                var errorMessage = response.Content.ReadAsStringAsync();
                throw new Exception($"Erro na requisição do QuotationRequest: {response.StatusCode}. Detalhes: {errorMessage.Result}");
            }
        }

        public Document GetCustomerPerson(
            string customerDocument,
            string sessionId,
            string sessionToken,
            string companyKey = "G3",
            string language = "pt-BR")
        {
            var urlBase = Environment.GetEnvironmentVariable("API_TAREFAS__NexLogSettings__UrlBase");
            var requestUri = urlBase + $"/customer/person/{customerDocument}";

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);

            // Configuração dos headers
            requestMessage.Headers.Add("accept", "application/json");
            requestMessage.Headers.Add("companyKey", companyKey);
            requestMessage.Headers.Add("sessionId", sessionId);
            requestMessage.Headers.Add("sessionToken", sessionToken);
            requestMessage.Headers.Add("language", language);

            // Envio da requisição e tratamento da resposta
            var response = _httpClient.SendAsync(requestMessage).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<Document>(jsonResponse);

                return data;
            }
            else
            {
                var errorMessage = response.Content.ReadAsStringAsync();
                throw new Exception($"Erro na requisição do GetCustomerPerson: {response.StatusCode}. Detalhes: {errorMessage.Result}");
            }
        }
    }

}
