using FluentValidation.AspNetCore;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Commands.Autor;
using ProjetoAPI.Application.Queries.Autor;
using ProjetoAPI.Infrastructure;
using ProjetoAPI.Infrastructure.Services;
using System.Reflection;
using ProjetoAPI.Application.Validators.Assunto;
using ProjetoAPI.Application.Validators.Autor;
using ProjetoAPI.Application.Commands.Assunto;
using ProjetoAPI.Application.Queries.Assunto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddMediatR(typeof(CriarAutorCommand).Assembly);
builder.Services.AddMediatR(typeof(AlterarAutorCommand).Assembly);
builder.Services.AddMediatR(typeof(RemoverAutorCommand).Assembly);
builder.Services.AddMediatR(typeof(BuscarAutoresQuery).Assembly);
builder.Services.AddMediatR(typeof(BuscarAutorPorIdQuery).Assembly);

builder.Services.AddMediatR(typeof(CriarAssuntoCommand).Assembly);
builder.Services.AddMediatR(typeof(AlterarAssuntoCommand).Assembly);
builder.Services.AddMediatR(typeof(RemoverAssuntoCommand).Assembly);
builder.Services.AddMediatR(typeof(BuscarAssuntosQuery).Assembly);
builder.Services.AddMediatR(typeof(BuscarAssuntoPorIdQuery).Assembly);

builder.Services.AddFluentValidationAutoValidation(); // Habilita validação automática
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddValidatorsFromAssembly(typeof(CriarAutorDtoValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(AlterarAutorDtoValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(CriarAssuntoDtoValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(AlterarAssuntoDtoValidator).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy",
        policy => policy
            .WithOrigins("http://localhost:4200") // Domínios permitidos
            .WithMethods("GET", "POST", "PUT", "DELETE") // Métodos permitidos
            .WithHeaders("Content-Type", "Authorization")); // Cabeçalhos permitidos
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FrontendPolicy");

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await RoleInitializer.InitializeAsync(services);
}

app.UseAuthentication(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
