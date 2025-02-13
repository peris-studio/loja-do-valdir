namespace LojaDoValdir.Modules;

public static class ClienteModule
{
    private static List<Cliente> listaClientes = new List<Cliente>
    {
        Cliente.Inserir("Cauã Fernando", "Nascimento", 27, 'M', new DateOnly(1997, 06, 07)),
        Cliente.Inserir("Francisco", "Novais Lima", 24, 'M', new DateOnly(2000, 05, 19)),
        Cliente.Inserir("Sônia Helena", "da Paz", 43, 'F', new DateOnly(1980, 11, 01))
    };

    public static void MapClienteEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/cliente").WithTags("Cliente");

        // I N S E R I R
        group.MapPost("/inserir", (Cliente novoCliente) =>
        {
            var cliente = Cliente.Inserir(novoCliente.Nome, novoCliente.Sobrenome, novoCliente.Idade, novoCliente.Sexo, novoCliente.DataNascimento);
            listaClientes.Add(cliente);

            return Results.Created($"/api/cliente/inserir/{cliente.Id}/", "Cliente cadastrado com sucesso!");
        });

        // O B T E R    I D
        group.MapGet("/obter-por-id/{id}", (Guid id) =>
        {
            if (id == Guid.Empty)
            {
                return Results.BadRequest("Id inválido");
            }

            var cliente = listaClientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return Results.NotFound("Cliente não encontrado.");
            }

            return Results.Ok(cliente);
        });

        // L I S T A R
        group.MapGet("/listar", () =>
        {
            return Results.Ok(listaClientes);
        });

        // A T U A L I Z A R
        group.MapPut("/atualizar/{id}", (Guid id, Cliente clienteAtualizado) =>
        {
            var cliente = listaClientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return Results.NotFound("Cliente não encontrado.");
            }

            cliente = Cliente.Atualizar(cliente, clienteAtualizado.Nome, clienteAtualizado.Sobrenome, clienteAtualizado.Idade, clienteAtualizado.Sexo, clienteAtualizado.DataNascimento);

            return Results.Ok(new { mensagem = "Cliente atualizado com sucesso!", cliente });
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", (Guid id) =>
        {
            var cliente = listaClientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return Results.NotFound("Cliente não encontrado.");
            }

            cliente = Cliente.Remover(cliente);
            listaClientes.Remove(cliente);

            return Results.Ok(new { mensagem = "Cliente removido com sucesso!", cliente });
        });
    }
}