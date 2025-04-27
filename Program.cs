using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Reflection;
using FluxoCaixa.Repositories;
using FluxoCaixa.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Kestrel
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080);
});

// Serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 🔥 Só adiciona Swagger se não for "Testing"
if (!builder.Environment.IsEnvironment("Testing"))
{
    builder.Services.AddSwaggerGen(options =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    });
}

// Injeção de dependências
builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();
builder.Services.AddScoped<FluxoCaixaService>();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    if (!app.Environment.IsEnvironment("Testing")) // 🔥 Só ativa Swagger fora de Testing
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "FluxoCaixa API V1");
            options.RoutePrefix = "swagger";
        });
    }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
