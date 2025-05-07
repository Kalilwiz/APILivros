using ProjetoLivros.Context;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Repository;

var builder = WebApplication.CreateBuilder(args);

//  avisa que a aplicacao vai usar controllers
builder.Services.AddControllers();

//  crio um gerador do swegger
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

//  informo onde esta meu contexto
builder.Services.AddDbContext<LivrosContext>();

//  constroe a aplicacao
var app = builder.Build();

// informa para o .net que tem controlladores e inicia eles
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(options => 
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();
