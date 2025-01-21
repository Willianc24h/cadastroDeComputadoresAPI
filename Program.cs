using CadastroDeComputadores.DataContext;
using CadastroDeComputadores.Service.CadastroService;
using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Configuração de CORS
//builder.Services.AddCors(options => {
//    options.AddPolicy("AllowSpecificOrigin", policy => {
//        policy.WithOrigins("http://localhost:5173") // Origem do frontend
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});

//// Add services to the container.
//builder.Services.AddControllers();

//// Swagger para gerar a documentação da API
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<ICadastroInterface, CadastroService>();

//// Configuração do Kestrel para escutar nas portas específicas
//builder.WebHost.ConfigureKestrel(options => {
//    options.ListenAnyIP(5108); // HTTP na porta 5108
//    options.ListenAnyIP(7001, listenOptions => // HTTPS na porta 7001
//    {
//        // Usando certificado autoassinado ou certificado específico
//        listenOptions.UseHttps(); // Você pode adicionar um certificado customizado aqui se necessário
//    });
//});

//// Configuração do DbContext com a string de conexão
//builder.Services.AddDbContext<AplicationDbContext>(options => {
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection"));
//});

//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

//// Cria o app depois de registrar todos os serviços
//var app = builder.Build();

//// Configuração do pipeline de requisição
//if (app.Environment.IsDevelopment()) {
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//// Política de CORS configurada
//app.UseCors("AllowSpecificOrigin");

//// Redirecionamento automático para HTTPS
//app.UseHttpsRedirection();

//app.UseAuthorization();

//// Mapeamento dos controladores
//app.MapControllers();

//// Executa a aplicação
//app.Run();

var builder = WebApplication.CreateBuilder(args);

// Configuração de CORS
builder.Services.AddCors(options => {
    options.AddPolicy("AllowSpecificOrigin", policy => {
        // Permite tanto HTTP quanto HTTPS
        policy.WithOrigins("http://localhost:5173", "https://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Outros serviços e configurações
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

// Configuração do DbContext
builder.Services.AddDbContext<AplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection"));
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configuração do pipeline de requisição
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use a política de CORS configurada antes do redirecionamento HTTPS
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();  // Redirecionamento para HTTPS

app.UseAuthorization();
app.MapControllers();

app.Run();
