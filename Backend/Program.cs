using Microsoft.EntityFrameworkCore;
using SmartwayFinal.Models;

var builder = WebApplication.CreateBuilder(args);
var nameVue = "VueApp";
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Añadir Cross Origin Resource Sharing (CORS)
builder.Services.AddCors(o =>
{
    o.AddPolicy(name: nameVue,
    policy =>
    {
        policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Configuración de la aplicación para atender archivos estáticos y habilitar la asignación de archivos predeterminada.
app.UseDefaultFiles();
app.UseStaticFiles();

//Habilitar CORS. Si se usa JavaScript para recuperar archivos estáticos,
//debe ir antes que UseStaticFiles
app.UseCors(nameVue);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
