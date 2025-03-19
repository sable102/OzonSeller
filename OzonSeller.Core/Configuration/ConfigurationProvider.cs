using Microsoft.Extensions.Configuration;

namespace OzonSeller.Core.Configuration
{
	public class ConfigurationProvider
	{
		public static OzonSettings GetOzonSettings()
		{
			// Создаем конфигурацию
			var configuration = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
				.Build();

			// Создаем экземпляр модели
			var ozonSettings = new OzonSettings();

			// Связываем конфигурацию с моделью
			configuration.GetSection(nameof(OzonSettings)).Bind(ozonSettings);

			return ozonSettings;
		}
	}
}
