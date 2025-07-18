using CadastroDeComputadores.DataContext;
using CadastroDeComputadores.Service.CadastroService;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CadastroDeComputadores.Service;


var builder = WebApplication.CreateBuilder(args);

// Configuração de CORS
builder.Services.AddCors(options => {
    options.AddPolicy("AllowSpecificOrigin", policy => {
        // Permite tanto HTTP quanto HTTPS
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var jwtSecret = builder.Configuration.GetValue<string>("JwtSettings:Secret");

if (string.IsNullOrEmpty(jwtSecret)) {
    throw new Exception("A variável de ambiente JWT_SECRET não está definida.");
}

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });


// Outros serviços e configurações
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICadastroInterface, CadastroService>();

builder.WebHost.ConfigureKestrel(options => {
    options.ListenAnyIP(5108); // HTTP na porta 5108
});

// Configuração do DbContext
builder.Services.AddDbContext<AplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Registro dos serviços
builder.Services.AddScoped<ICadastroInterface, CadastroService>();
builder.Services.AddScoped<TokenService>(); // Adiciona TokenService à injeção de dependência


var app = builder.Build();

// Configuração do pipeline de requisição
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use a política de CORS configurada antes do redirecionamento HTTPS
app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "API protegida com JWT!").RequireAuthorization();
app.MapControllers();

app.Run();