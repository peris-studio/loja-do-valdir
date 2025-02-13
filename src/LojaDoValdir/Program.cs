var builder = WebApplication.CreateBuilder(args);

// adicionando swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "LojaDoValdir", Version = "v1" });
});

// 🔥 Adicionando serviço de Health Checks
builder.Services.AddHealthChecks();

// criando a aplicação
var app = builder.Build();

// usando o swagger 
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LojaDoValdir v1");
    c.RoutePrefix = string.Empty; // acessar documentação raiz 
});

app.UseHttpsRedirection();

// Registrando o Health Check corretamente
app.MapHealthChecks("/healthz");

// registrando os módulos de endpoints
app.MapClienteEndpoints();
app.MapContatoEndpoints();
app.MapEnderecoEndpoints();
app.MapUsuarioEndpoints();
app.MapItemEndpoints();
app.MapPedidoEndpoints();
app.MapPedidoItemEndpoints();
app.MapItemDescontoEndpoints();

// iniciando a aplicação
app.Run();