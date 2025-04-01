using Microsoft.EntityFrameworkCore;
using OzonSeller.Store.Application;
using OzonSeller.Store.Domain.Interfaces;
using OzonSeller.Store.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlite(builder.Configuration.GetConnectionString("StoretConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IProductArticleRepository, ProductArticleRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductArticleService>();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowLocalhost",
		builder => builder
			.WithOrigins("http://localhost:4173", "http://localhost:5173")
			.AllowAnyMethod()
			.AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalhost");

app.UseAuthorization();

app.MapControllers();

app.Run();
