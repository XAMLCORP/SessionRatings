using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gaming.Foundation.WebClient
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private Uri BaseEndpoint { get; set; }
        private Guid _userId = Guid.Empty;

        public ApiClient(Uri baseEndpoint)
        {
            if (baseEndpoint == null)
                throw new ArgumentNullException("baseEndpoint");
            BaseEndpoint = baseEndpoint;
            _httpClient = new HttpClient();
        }

        public async Task<T> GetAsync<T>(Uri requestUrl, Guid userId)
        {
            _userId = userId;
            AddHeaders();
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var entity = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
            //var entity = JsonSerializer.Deserialize<T>(data);   // Strange Bug - not deserializing?
            return entity;
        }

        public async Task<T> PostAsync<T>(Uri requestUrl, T content, Guid userId)
        {
            _userId = userId;
            AddHeaders();
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var entity = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
            //var entity = JsonSerializer.Deserialize<T>(data);   // Strange Bug - not deserializing?
            return entity;
        }
        public async Task<T1> PostAsync<T1, T2>(Uri requestUrl, T2 content, Guid userId)
        {
            _userId = userId;
            AddHeaders();
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T2>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var entity = Newtonsoft.Json.JsonConvert.DeserializeObject<T1>(data);
            //var entity = JsonSerializer.Deserialize<T1>(data);   // Strange Bug - not deserializing?
            return entity;
        }

        public Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

        public HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonSerializer.Serialize(content, SerializerOptions);
            return new StringContent(json, Encoding.Unicode, "application/json");
        }

        protected static JsonSerializerOptions SerializerOptions
        {
            get
            {
                return new JsonSerializerOptions
                {
                    IgnoreNullValues = true
                };
            }
        }

        protected void AddHeaders()
        {
            _httpClient.DefaultRequestHeaders.Remove("userIP");
            _httpClient.DefaultRequestHeaders.Remove("Ubi-UserId");
            if (_userId != Guid.Empty)
                _httpClient.DefaultRequestHeaders.Add("Ubi-UserId", "88a4b287-a170-4a13-bb1e-91c4bdaa259c");
        }
    }
}
