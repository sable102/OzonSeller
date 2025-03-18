namespace OzonSeller.Core.ApiClient
{
	internal class OzonApiClient : IOzonApiClient
	{
		private readonly HttpClient _httpClient;
		private readonly string _clientId;
		private readonly string _clientSecret;
		private readonly string _grantType;

		public OzonApiClient(HttpClient httpClient, string clientId, string clientSecret, string grantType)
		{
			_httpClient = httpClient;
			_clientId = clientId;
			_clientSecret = clientSecret;
			_grantType = grantType;
		}

		public async Task Test()
		{
			await Task.CompletedTask;
		}
	}
}
