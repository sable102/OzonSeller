using System.Text.Json;
using System.Text;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace OzonSeller.Core.ApiClient
{
	internal class OzonApiClient : IOzonApiClient
	{
		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _options;

		public OzonApiClient(HttpClient httpClient, string clientId, string clientSecret, string grantType)
		{
			_httpClient = httpClient;

			_httpClient.DefaultRequestHeaders.Add("client-id", $"{clientId}");
			_httpClient.DefaultRequestHeaders.Add("api-key", $"{clientSecret}");
			_httpClient.DefaultRequestHeaders.Add("grant-type", $"{grantType}");

			_options = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				WriteIndented = true,
				Converters =
				{
					new JsonStringEnumConverter(),
					new Converters.DateTimeConverter()
				}
			};
		}

		public async Task<T> PostAsync<T>(string endpoint, object requestData)
		{


			var json = JsonSerializer.Serialize(requestData, _options);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync(endpoint, content);
			response.EnsureSuccessStatusCode();
			var responseBody = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<T>(responseBody);
		}

		public async Task Test()
		{
			await Task.CompletedTask;
		}
	}
}
