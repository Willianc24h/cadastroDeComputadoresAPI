using CadastroDeComputadores.DataContext;
using CadastroDeComputadores.Service.CadastroService;
using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Configura��o de CORS
//builder.Services.AddCors(options => {
//    options.AddPolicy("AllowSpecificOrigin", policy => {
//        policy.WithOrigins("http://localhost:5173") // Origem do frontend
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});

//// Add services to the container.
//builder.Services.AddControllers();

//// Swagger para gerar a documenta��o da API
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<ICadastroInterface, CadastroService>();

//// Configura��o do Kestrel para escutar nas portas espec�ficas
//builder.WebHost.ConfigureKestrel(options => {
//    options.ListenAnyIP(5108); // HTTP na porta 5108
//    options.ListenAnyIP(7001, listenOptions => // HTTPS na porta 7001
//    {
//        // Usando certificado autoassinado ou certificado espec�fico
//        listenOptions.UseHttps(); // Voc� pode adicionar um certificado customizado aqui se necess�rio
//    });
//});

//// Configura��o do DbContext com a string de conex�o
//builder.Services.AddDbContext<AplicationDbContext>(options => {
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection"));
//});

//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

//// Cria o app depois de registrar todos os servi�os
//var app = builder.Build();

//// Configura��o do pipeline de requisi��o
//if (app.Environment.IsDevelopment()) {
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//// Pol�tica de CORS configurada
//app.UseCors("AllowSpecificOrigin");

//// Redirecionamento autom�tico para HTTPS
//app.UseHttpsRedirection();

//app.UseAuthorization();

//// Mapeamento dos controladores
//app.MapControllers();

//// Executa a aplica��o
//app.Run();

var builder = WebApplication.CreateBuilder(args);

// Configura��o de CORS
builder.Services.AddCors(options => {
    options.AddPolicy("AllowSpecificOrigin", policy => {
        // Permite tanto HTTP quanto HTTPS
        policy.WithOrigins("http://localhost:5173", "https://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Outros servi�os e configura��es
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICadastroInterface, CadastroService>();

builder.WebHost.ConfigureKestrel(options => {
    options.ListenAnyIP(5108); // HTTP na porta 5108
    options.ListenAnyIP(7001, listenOptions => // HTTPS na porta 7001
    {
        listenOptions.UseHttps(); // Usa o certificado autoassinado
    });
});

// Configura��o do DbContext
builder.Services.AddDbContext<AplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection"));
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configura��o do pipeline de requisi��o
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use a pol�tica de CORS configurada antes do redirecionamento HTTPS
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();  // Redirecionamento para HTTPS

app.UseAuthorization();
app.MapControllers();

app.Run();
