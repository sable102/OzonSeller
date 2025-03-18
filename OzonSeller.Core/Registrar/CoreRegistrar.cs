using Microsoft.Extensions.DependencyInjection;
using OzonSeller.Core.ApiClient;
using OzonSeller.Core.Enums;

namespace OzonSeller.Core.Registrar
{
	public static class CoreRegistrar
	{
		public static void Registrar(this IServiceCollection services)
		{
			var ozonSettings = Configuration.ConfigurationProvider.GetOzonSettings();

			services.AddSingleton<IOzonApiClient>(provider =>
			{
				var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
				var httpClient = httpClientFactory.CreateClient(HttpClientName.OzonClient);
				httpClient.BaseAddress = new Uri(ozonSettings.Url);

				return new OzonApiClient(httpClient, ozonSettings.ClientId, ozonSettings.ClientSecret, ozonSettings.GrantType);
			});
		}
	}
}
