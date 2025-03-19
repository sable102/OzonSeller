// Создаем сервисный коллекцион
using Microsoft.Extensions.DependencyInjection;
using OzonSeller.Core.Registrar;
using OzonSeller.Core.Services;

var serviceCollection = new ServiceCollection();


serviceCollection.RegistrarCore();
// Создаем сервисный провайдер
var serviceProvider = serviceCollection.BuildServiceProvider();

// Получаем экземпляр сервиса
var service = serviceProvider.GetService<IFinanceService>();
var d = await service.GetFinanceTransaction(12,2024);
var j = await service.GetFinanceTransaction(01,2025);
var f = await service.GetFinanceTransaction(02,2025);
var m = await service.GetFinanceTransaction(03,2025);

// Освобождаем ресурсы
serviceProvider.Dispose();
