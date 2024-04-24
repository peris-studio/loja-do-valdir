var builder = WebApplication.CreateBuilder(args);

// adicionando swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "LojaDoValdir", Version = "v1" });
});

// pipeline
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LojaDoValdir v1");
    c.RoutePrefix = string.Empty; // acessar documentação raiz 
});

// rotas
app.MapGet("/api/rota1", () => "Hello, World!").WithTags(new[] { " Grupo 1 "});
app.MapGet("/api/rota2", () => "¡Hola, Mundo!").WithTags(new[] { " Grupo 1 "});;
app.MapPost("/api/rota3", (string mensagem) => $"Mensagem recebida com sucesso: {mensagem}!").WithTags(new[] { " Grupo 2 "});;

app.Run();