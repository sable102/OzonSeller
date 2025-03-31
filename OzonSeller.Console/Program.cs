// Создаем сервисный коллекцион
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Math;
using Microsoft.Extensions.DependencyInjection;
using OzonSeller.Core.Registrar;
using OzonSeller.Core.Services;
using OzonSeller.Core.Services.Models;
using System.Reflection;

var serviceCollection = new ServiceCollection();


serviceCollection.RegistrarCore();
// Создаем сервисный провайдер
var serviceProvider = serviceCollection.BuildServiceProvider();

// Получаем экземпляр сервиса
var service = serviceProvider.GetService<IFinanceService>();
var operations = new List<Operation>();

var startYear = 2024;
var startMonth = 11;

var endYear = 2025;
var endMonth = 3;

var currentYear = startYear;
var currentMonth = startMonth;

while (currentYear < endYear || (currentYear == endYear && currentMonth <= endMonth))
{
	var financeTransaction = await service.GetFinanceTransaction(currentMonth, currentYear);
	operations.AddRange(financeTransaction.Result.Operations ?? []);

	currentMonth++;
	if (currentMonth > 12)
	{
		currentMonth = 1;
		currentYear++;
	}
}


foreach (var operation in operations)
{
	operation.PostingNumber= operation.Posting.PostingNumber;
	operation.Skus = string.Join(";", operation.Items.Select(x => x.Sku));
	operation.Names = string.Join(";", operation.Items.Select(x => x.Name));

	if (operation.Type == "orders")
	{
		operation.ServiceAmount = operation.Services.Sum(x => x.Price);
	}

}


// Путь к файлу
string excelFilePath = $"output {DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.xlsx";

// Создание нового Excel-файла
using (var workbook = new XLWorkbook())
{
	// Добавление листа
	var worksheet = workbook.AddWorksheet("Sheet1");

	// Получение свойств типа данных
	PropertyInfo[] properties = typeof(Operation).GetProperties();

	// Запись заголовков
	for (int i = 0; i < properties.Length; i++)
	{
		worksheet.Cell(1, i + 1).Value = properties[i].Name;
	}

	// Запись данных
	for (int i = 0; i < operations.Count; i++)
	{
		for (int j = 0; j < properties.Length; j++)
		{
			var value = properties[j].GetValue(operations[i]);
			if (value is int intValue)
			{
				worksheet.Cell(i + 2, j + 1).Value = intValue;
			}
			else if (value is double doubleValue)
			{
				worksheet.Cell(i + 2, j + 1).Value = doubleValue;
			}
			else if (value is decimal decimalValue)
			{
				worksheet.Cell(i + 2, j + 1).Value = decimalValue;
			}
			else
			{
				worksheet.Cell(i + 2, j + 1).Value = value?.ToString();
			}
		}
	}

	// Сохранение файла
	workbook.SaveAs(excelFilePath);
}

// Освобождаем ресурсы
serviceProvider.Dispose();
