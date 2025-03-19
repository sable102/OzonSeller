using Microsoft.Extensions.DependencyInjection;
using OzonSeller.Core.ApiClient;
using OzonSeller.Core.Enums;
using OzonSeller.Core.Services;

namespace OzonSeller.Core.Registrar
{
	public static class CoreRegistrar
	{
		public static void RegistrarCore(this IServiceCollection services)
		{
			var ozonSettings = Configuration.ConfigurationProvider.GetOzonSettings();

			services.AddHttpClient(HttpClientName.OzonClient, client =>
			{
				client.BaseAddress = new Uri(ozonSettings.Url);
				client.Timeout = TimeSpan.FromSeconds(30);
			});

			services.AddSingleton<IOzonApiClient>(provider =>
			{
				var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
				var httpClient = httpClientFactory.CreateClient(HttpClientName.OzonClient);


				return new OzonApiClient(httpClient, ozonSettings.ClientId, ozonSettings.ClientSecret, ozonSettings.GrantType);
			});

			services.AddScoped<IFinanceService, FinanceService>();
		}
	}
}
