using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SmartwayFinal.Models;
using SmartwayFinal.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SmartwayFinal.Controllers;




var builder = WebApplication.CreateBuilder(args);
var nameVue = "VueApp";

//Inserción de Dependencias
builder.Services.AddScoped<IAgenteService, AgentesController>();
builder.Services.AddScoped<IEquipoService, EquipoController>();
builder.Services.AddScoped<IOperacionService, OperacionController>();

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddSingleton<JWTHandler>();
builder.Services.AddSwaggerGen(c => {

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement(){
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type= ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });

});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer( o => {
    var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);
    o.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(); 

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

//Habilitar CORS. Si se usa JavaScript para recuperar archivos estáticos,
//debe ir antes que UseStaticFiles
app.UseCors(nameVue);


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
