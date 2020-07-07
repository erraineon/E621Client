using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace E621
{
    public class E621Client
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver {NamingStrategy = new SnakeCaseNamingStrategy()},
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        //limit requests to one per second, as per API guideline
        private static readonly RateLimiter RequestLimiter = new RateLimiter(1, TimeSpan.FromSeconds(1));

        private readonly HttpClient _httpClient = new HttpClient();

        public E621Client(string userAgent)
        {
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
        }

        public async Task<IList<E621Post>> Search(E621SearchOptions options)
        {
            const string baseUri = "https://e621.net/posts.json";
            var parameters = ToDictionary(options);
            if (options.BeforeId is { } beforeId)
                parameters["page"] = $"b{beforeId}";
            else if (options.AfterId is { } afterId)
                parameters["page"] = $"a{afterId}";
            var requestUri = QueryHelpers.AddQueryString(baseUri, parameters);
            var response = await Request(requestUri);
            var root = JsonConvert.DeserializeObject<E621PostsRoot>(response, JsonSerializerSettings);
            return root.Posts;
        }

        private async Task<string> Request(string requestUri)
        {
            await RequestLimiter.WaitToProceed();
            var response = await _httpClient.GetStringAsync(requestUri);
            return response;
        }

        private static Dictionary<string, string> ToDictionary(object value)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(
                JsonConvert.SerializeObject(value, JsonSerializerSettings));
        }
    }
}