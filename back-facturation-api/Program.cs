using back_facturation_api.Data;
using back_facturation_api.Helpers;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

// Env var
//DotNetEnv.Env.Load(@"../.env");
DotNetEnv.Env.Load(@"../env.dev");

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:8080")  // URL d'origine autorisée
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

// Db Connection
// Construire la chaîne de connexion en utilisant les variables d'environnement
var connectionString = 
    $"Host={Environment.GetEnvironmentVariable("POSTGRES_HOST")};" +
    $"Database={Environment.GetEnvironmentVariable("POSTGRES_DB")};" +
    $"Username={Environment.GetEnvironmentVariable("POSTGRES_USER")};" +
    $"Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")}";

builder.Services.AddDbContext<UserContext>(options =>
    options.UseNpgsql(connectionString));
    //options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<JwtService>();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins); // Utilise la politique CORS configurée

app.UseAuthorization();

app.MapControllers();

app.Run();
