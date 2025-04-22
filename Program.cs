using CrudApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionando contexto do banco de dados (MySQL)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Registrando controladores
builder.Services.AddControllers();

var app = builder.Build();

// Configurando o Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usando redirecionamento HTTPS (pode comentar se não for usar HTTPS)
app.UseHttpsRedirection();

// Habilitando rotas para os controladores
app.MapControllers();

// Rodando a aplicação
app.Run();
