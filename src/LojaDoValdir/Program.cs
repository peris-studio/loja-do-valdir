var builder = WebApplication.CreateSlimBuilder(args);

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
    c.SwaggerEndpoint("/swagger/v1/swagger.json/", "LojaDoValdir v1");
    c.RoutePrefix = string.Empty; // acessar documentação raiz 
});

// R O T A S

// CLIENTE

List<Cliente> listaClientes = new List<Cliente>
{
    Cliente.Inserir("Cauã Fernando", "Nascimento", 27, 'M',new DateOnly(1997, 06, 07)),
    Cliente.Inserir("Francisco", "Novais Lima", 24, 'M', new DateOnly(2000, 05, 19)),
    Cliente.Inserir("Sônia Helena", "da Paz", 43, 'F', new DateOnly(1980, 11, 01))
};


// I N S E R I R 
app.MapPost("/api/cliente/inserir/", (Cliente novoCliente) =>
{
    var cliente = Cliente.Inserir(novoCliente.Nome, novoCliente.Sobrenome, novoCliente.Idade, novoCliente.Sexo, novoCliente.DataNascimento);
    listaClientes.Add(cliente);

    return Results.Created($"/api/cliente/inserir/{cliente.Id}/", "Cliente cadastrado com sucesso!");
}).WithTags(new[] { "Cliente" });


// O B T E R    I D
app.MapGet("/api/cliente/obter-por-id/{id}", (Guid id) =>
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
}).WithTags(new[] { "Cliente" });


// L I S T A R
app.MapGet("/api/cliente/listar/", () =>
{
    return Results.Ok(listaClientes);
}).WithTags(new[] { "Cliente" });


// A T U A L I Z A R
app.MapPut("/api/cliente/atualizar/{id}", (Guid id, Cliente clienteAtualizado) =>
{
    var cliente = listaClientes.FirstOrDefault(c => c.Id == id);

    if (cliente == null)
    {
        return Results.NotFound("Cliente não encontrado.");
    }

    cliente = Cliente.Atualizar(cliente, clienteAtualizado.Nome, clienteAtualizado.Sobrenome, clienteAtualizado.Idade, clienteAtualizado.Sexo, clienteAtualizado.DataNascimento);


    return Results.Ok(new { mensagem = "Cliente atualizado com sucesso!", cliente });
}).WithTags(new[] { "Cliente" });


// R E M O V E R
app.MapDelete("/api/cliente/remover/{id}", (Guid id) =>
{
    var cliente = listaClientes.FirstOrDefault(c => c.Id == id);

    if (cliente == null)
    {
        return Results.NotFound("Cliente não encontrado.");
    }

    cliente = Cliente.Remover(cliente);
    listaClientes.Remove(cliente);

    return Results.Ok(new { mensagem = "Cliente removido com sucesso!", cliente });
}).WithTags(new[] { "Cliente" });




// CONTATO

List<Contato> listaContatos = new List<Contato>
{
    Contato.Inserir("+55", "71", "983623115", true, Guid.Parse("6bcda3fa-16e3-4d90-974c-5d8b14fe7ea6")),
    Contato.Inserir("+55", "11", "995351893", true, Guid.Parse("7a9c3246-6cfe-4e49-b6b3-2000d00369ab")),
    Contato.Inserir("+55", "13", "988390610", true, Guid.Parse("296e2886-aa84-4023-9ffe-430f09b127fb"))
};


// I N S E R I R 
app.MapPost("/api/contato/inserir/", (Contato novoContato) =>
{
    var contato = Contato.Inserir(novoContato.CodigoDDI, novoContato.CodigoDDD, novoContato.CodigoTelefone, novoContato.TelefonePrincipal, novoContato.ClienteId);
    listaContatos.Add(novoContato);

    return Results.Created($"/api/contato/inserir/{contato.Id}/", "Contato cadastrado com sucesso!");
}).WithTags(new[] { "Contato" });


// O B T E R    I D
app.MapGet("/api/contato/obter-por-id/{id}", (Guid id) =>
{
    if (id == Guid.Empty)
    {
        return Results.BadRequest("Id inválido");
    }

    var contato = listaContatos.FirstOrDefault(c => c.Id == id);

    if (contato == null)
    {
        return Results.NotFound("Contato não encontrado.");
    }

    return Results.Ok(contato);
}).WithTags(new[] { "Contato" });


// L I S T A R
app.MapGet("/api/contato/listar/", () =>
{
    return Results.Ok(listaContatos);
}).WithTags(new[] { "Contato" });


// A T U A L I Z A R
app.MapPut("/api/contato/atualizar/{id}", (Guid id, Contato contatoAtualizado) =>
{
    var contato = listaContatos.FirstOrDefault(c => c.Id == id);

    if (contato == null)
    {
        return Results.NotFound("Contato não encontrado.");
    }

    contato = Contato.Atualizar(contato, contatoAtualizado.CodigoDDI, contatoAtualizado.CodigoDDD, contatoAtualizado.CodigoTelefone, contatoAtualizado.TelefonePrincipal);

    return Results.Ok(new { mensagem = "Contato atualizado com sucesso!", contato });
}).WithTags(new[] { "Contato" });


// R E M O V E R
app.MapDelete("/api/contato/remover/{id}", (Guid id) =>
{
    var contato = listaContatos.FirstOrDefault(c => c.Id == id);

    if (contato == null)
    {
        return Results.NotFound("Contato não encontrado.");
    }

    contato = Contato.Remover(contato);
    listaContatos.Remove(contato);

    return Results.Ok(new { mensagem = "Contato removido com sucesso!", contato });
}).WithTags(new[] { "Contato" });




// E N D E R E Ç O

List<Endereco> listaEnderecos = new List<Endereco>
{
    Endereco.Inserir("Rua Hércules Florence", "154", "Marapé", "Santos", "SP", Guid.Parse("6bcda3fa-16e3-4d90-974c-5d8b14fe7ea6")),
    Endereco.Inserir("Rua A", "912", "Jardim Sueli", "Atibaia", "SP", Guid.Parse("7a9c3246-6cfe-4e49-b6b3-2000d00369ab")),
    Endereco.Inserir("Rua São Miguel", "414", "Tupiry", "Praia Grande", "SP", Guid.Parse("296e2886-aa84-4023-9ffe-430f09b127fb"))
};


// I N S E R I R 
app.MapPost("/api/endereco/inserir/", (Endereco novoEndereco) =>
{
    var endereco = Endereco.Inserir(novoEndereco.Logradouro, novoEndereco.Numero, novoEndereco.Bairro, novoEndereco.Cidade, novoEndereco.UF, novoEndereco.ClienteId);
    listaEnderecos.Add(endereco);

    return Results.Created($"/api/endereco/inserir/{endereco.Id}/", "Endereço cadastrado com sucesso!");
}).WithTags(new[] { "Endereço" });


// O B T E R    I D
app.MapGet("/api/endereco/obter-por-id/{id}", (Guid id) =>
{
    if (id == Guid.Empty)
    {
        return Results.BadRequest("Id inválido");
    }

    var endereco = listaEnderecos.FirstOrDefault(c => c.Id == id);

    if (endereco == null)
    {
        return Results.NotFound("Endereço não encontrado.");
    }

    return Results.Ok(endereco);
}).WithTags(new[] { "Endereço" });


// L I S T A R
app.MapGet("/api/endereco/listar/", () =>
{
    return Results.Ok(listaEnderecos);
}).WithTags(new[] { "Endereço" });


// A T U A L I Z A R
app.MapPut("/api/endereco/atualizar/{id}", (Guid id, Endereco enderecoAtualizado) =>
{
    var endereco = listaEnderecos.FirstOrDefault(c => c.Id == id);

    if (endereco == null)
    {
        return Results.NotFound("Endereço não encontrado.");
    }

    endereco = Endereco.Atualizar(endereco, enderecoAtualizado.Logradouro, enderecoAtualizado.Numero, enderecoAtualizado.Bairro, enderecoAtualizado.Cidade, enderecoAtualizado.UF);

    return Results.Ok(new { mensagem = "Endereço atualizado com sucesso!", endereco });
}).WithTags(new[] { "Endereço" });


// R E M O V E R
app.MapDelete("/api/endereco/remover/{id}", (Guid id) =>
{
    var endereco = listaEnderecos.FirstOrDefault(c => c.Id == id);

    if (endereco == null)
    {
        return Results.NotFound("Endereço não encontrado.");
    }

    endereco = Endereco.Remover(endereco);
    listaEnderecos.Remove(endereco);

    return Results.Ok(new { mensagem = "Endereço removido com sucesso!", endereco });
}).WithTags(new[] { "Endereço" });




// I T E M

List<Item> listaItens = new List<Item>
{
    Item.Inserir("Leite Fermentado Yakult", "80g", "O Leite Fermentado Yakult é um alimento à base de leite desnatado, fermentado por lactobacilo selecionado, o exclusivo probiótico Lactobacillus casei Shirota, que resiste à acidez do estômago e chega vivo em grande quantidade ao intestino. A ingestão regular deste lactobacilo, juntamente com uma alimentação equilibrada, pode contribuir com a saúde do trato gastrointestinal.",
                5.90, TipoItem.Laticinios, true, 40, 10), // Id = Guid.Parse("61ff80c6-e0f8-4464-9b46-cedc817b2fce"),
    Item.Inserir("Pão Francês", "", "Fresco e Crocante", 0.50, TipoItem.Padaria, true, 100, 0), //Id = Guid.Parse("e161fbad-57f0-4e90-95ae-d99a01998bcc"),
    Item.Inserir("Maçã Gala", "A variar", "Maçã doce e suculente, rica em fibras e vitaminas.",
                1.29, TipoItem.FrutasVegetais, true, 13, 0) //Id = Guid.Parse("2fbfc5bc-a680-4e62-bf6c-1a41a1e08d1c"),
};


// I N S E R I R 
app.MapPost("/api/item/inserir/", (Item novoItem) =>
{
    var item = Item.Inserir(novoItem.Nome, novoItem.Peso, novoItem.Descricao, novoItem.Preco, novoItem.TipoItem, novoItem.ItemEmEstoque, novoItem.QuantidadeUnidade, novoItem.QuantidadeFardo);
    listaItens.Add(novoItem);

    return Results.Created($"/api/item/inserir/{item.Id}/", "item cadastrado com sucesso!");
}).WithTags(new[] { "Item" });


// O B T E R    I D
app.MapGet("/api/item/obter-por-id/{id}", (Guid id) =>
{
    if (id == Guid.Empty)
    {
        return Results.BadRequest("Id inválido");
    }

    var item = listaItens.FirstOrDefault(c => c.Id == id);

    if (item == null)
    {
        return Results.NotFound("Item não encontrado.");
    }

    return Results.Ok(item);
}).WithTags(new[] { "Item" });


// L I S T A R
app.MapGet("/api/item/listar/", () =>
{
    return Results.Ok(listaItens);
}).WithTags(new[] { "Item" });


// A T U A L I Z A R
app.MapPut("/api/item/atualizar/{id}", (Guid id, Item itemAtualizado) =>
{
    var item = listaItens.FirstOrDefault(c => c.Id == id);

    if (item == null)
    {
        return Results.NotFound("Item não encontrado.");
    }

    item = Item.Atualizar(item, itemAtualizado.Nome, itemAtualizado.Peso, itemAtualizado.Descricao, itemAtualizado.Preco, itemAtualizado.TipoItem, itemAtualizado.ItemEmEstoque, itemAtualizado.QuantidadeUnidade, itemAtualizado.QuantidadeFardo);

    return Results.Ok(new { mensagem = "Item atualizado com sucesso!", item });
}).WithTags(new[] { "Item" });


// R E M O V E R
app.MapDelete("/api/item/remover/{id}", (Guid id) =>
{
    var item = listaItens.FirstOrDefault(c => c.Id == id);

    if (item == null)
    {
        return Results.NotFound("Item não encontrado.");
    }

    item = Item.Remover(item);
    listaItens.Remove(item);

    return Results.Ok(new { mensagem = "Item removido com sucesso!", item });
}).WithTags(new[] { "Item" });




// I T E M    com    D E S C O N T O

List<ItemDesconto> listaItensDescontados = new List<ItemDesconto>
{
    ItemDesconto.Inserir("Leite Fermentado Yakult", 5.90, 80, 1.80, new DateTime(2024, 06, 02), new DateTime(2024, 06, 22),
                        Guid.Parse("61ff80c6-e0f8-4464-9b46-cedc817b2fce")),
    ItemDesconto.Inserir("Pão Francês", 0.50, 50, 0.25, new DateTime(2024, 09, 30), new DateTime(2024, 10, 03),
                        Guid.Parse("e161fbad-57f0-4e90-95ae-d99a01998bcc")),
    ItemDesconto.Inserir("Maçã Gala", 1.29, 10, 1.17, new DateTime(2024, 02, 18), new DateTime(2024, 03, 25),
                        Guid.Parse("2fbfc5bc-a680-4e62-bf6c-1a41a1e08d1c"))
};


// I N S E R I R 
app.MapPost("/api/desconto/inserir/", (ItemDesconto novoDesconto) =>
{
    var desconto = ItemDesconto.Inserir(novoDesconto.Nome, novoDesconto.PrecoComum, novoDesconto.PorcentagemDesconto, novoDesconto.PrecoDescontado, novoDesconto.DataInicio, novoDesconto.DataTermino, novoDesconto.ItemId);
    listaItensDescontados.Add(novoDesconto);

    return Results.Created($"/api/desconto/inserir/{desconto.Id}/", "Desconto cadastrado com sucesso!");
}).WithTags(new[] { "Desconto" });


// O B T E R    I D
app.MapGet("/api/desconto/obter-por-id/{id}", (Guid id) =>
{
    if (id == Guid.Empty)
    {
        return Results.BadRequest("Id inválido");
    }

    var desconto = listaItensDescontados.FirstOrDefault(c => c.Id == id);

    if (desconto == null)
    {
        return Results.NotFound("Desconto não encontrado.");
    }

    return Results.Ok(desconto);
}).WithTags(new[] { "Desconto" });


// L I S T A R
app.MapGet("/api/desconto/listar/", () =>
{
    return Results.Ok(listaItensDescontados);
}).WithTags(new[] { "Desconto" });


// A T U A L I Z A R
app.MapPut("/api/desconto/atualizar/{id}", (Guid id, ItemDesconto descontoAtualizado) =>
{
    var desconto = listaItensDescontados.FirstOrDefault(c => c.Id == id);

    if (desconto == null)
    {
        return Results.NotFound("Desconto não encontrado.");
    }

    desconto = ItemDesconto.Atualizar(desconto, descontoAtualizado.Nome, descontoAtualizado.PrecoComum, descontoAtualizado.PorcentagemDesconto, descontoAtualizado.PrecoDescontado, descontoAtualizado.DataInicio, descontoAtualizado.DataTermino);

    return Results.Ok(new { mensagem = "Desconto atualizado com sucesso!", desconto });
}).WithTags(new[] { "Desconto" });


// R E M O V E R
app.MapDelete("/api/desconto/remover/{id}", (Guid id) =>
{
    var desconto = listaItensDescontados.FirstOrDefault(c => c.Id == id);

    if (desconto == null)
    {
        return Results.NotFound("Desconto não encontrado.");
    }

    desconto = ItemDesconto.Remover(desconto);
    listaItensDescontados.Remove(desconto);

    return Results.Ok(new { mensagem = "Desconto removido com sucesso!", desconto });
}).WithTags(new[] { "Desconto" });




// P E D I D O

List<Pedido> listaPedidos = new List<Pedido>
{
    Pedido.Inserir(Guid.Parse("6bcda3fa-16e3-4d90-974c-5d8b14fe7ea6"),
                   Guid.Parse("ffd14883-41a7-46c8-b1b8-706aca11d3b4"),
                   Guid.Parse("a63597d3-a5b1-493c-8779-0ac5aa0501d9"),
                   Guid.Parse("9e532084-a7fe-4bc6-8362-25bc43edb828"),
                   new DateOnly(2024, 06, 22)),
    Pedido.Inserir(Guid.Parse("7a9c3246-6cfe-4e49-b6b3-2000d00369ab"),
                    Guid.Parse("9a4c64af-497c-4c46-817b-0c54cb334c1a"),
                    Guid.Parse("b8e55cde-5d5f-467f-bb70-9d108d383750"),
                    Guid.Parse("a74293c0-6d46-4151-b159-4c50b22a19a9"),
                    new DateOnly(2024, 06, 23)),
    Pedido.Inserir(Guid.Parse("296e2886-aa84-4023-9ffe-430f09b127fb"),
                    Guid.Parse("9d807da0-c2b5-4f10-8983-23e4c1162a08"),
                    Guid.Parse("eb953cd6-5b1b-4dea-89a0-257b1fe4196c"),
                    Guid.Parse("c550ce44-5a46-41ae-8c86-486a9a43b839"),
                    new DateOnly(2024, 06, 21))
};


// I N S E R I R 
app.MapPost("/api/pedido/inserir/", (Pedido novoPedido) =>
{
    var pedido = Pedido.Inserir(novoPedido.ClienteId, novoPedido.EnderecoId, novoPedido.ContatoId, novoPedido.UsuarioId, novoPedido.PrevisaoEntrega);
    listaPedidos.Add(pedido);

    return Results.Created($"/api/pedido/inserir/{pedido.Id}", "Pedido cadastrado com sucesso!");
}).WithTags(new[] { "Pedido" });


// O B T E R    I D
app.MapGet("/api/pedido/obter-por-id/{id}", (Guid id) =>
{
    if (id == Guid.Empty)
    {
        return Results.BadRequest("Id inválido");
    }

    var pedido = listaPedidos.FirstOrDefault(c => c.Id == id);

    if (pedido == null)
    {
        return Results.NotFound("Pedido não encontrado.");
    }

    return Results.Ok(pedido);
}).WithTags(new[] { "Pedido" });


// L I S T A R
app.MapGet("/api/pedido/listar/", () =>
{
    return Results.Ok(listaPedidos);
}).WithTags(new[] { "Pedido" });


// A T U A L I Z A R
app.MapPut("/api/pedido/atualizar/{id}", (Guid id, Pedido pedidoAtualizado) =>
{
    var pedido = listaPedidos.FirstOrDefault(c => c.Id == id);

    if (pedido == null)
    {
        return Results.NotFound("Endereço não encontrado.");
    }

    pedido = Pedido.Atualizar(pedido, pedidoAtualizado.EnderecoId, pedidoAtualizado.ContatoId, pedidoAtualizado.PrevisaoEntrega, pedidoAtualizado.Status);

    return Results.Ok(new { mensagem = "Pedido atualizado com sucesso!", pedido });
}).WithTags(new[] { "Pedido" });


// R E M O V E R
app.MapDelete("/api/pedido/remover/{id}", (Guid id) =>
{
    var pedido = listaPedidos.FirstOrDefault(c => c.Id == id);

    if (pedido == null)
    {
        return Results.NotFound("Pedido não encontrado.");
    }

    pedido = Pedido.Remover(pedido);
    listaPedidos.Remove(pedido);

    return Results.Ok(new { mensagem = "Pedido removido com sucesso!", pedido });
}).WithTags(new[] { "Pedido" });




// P E D I D O    dos    I T E N S

List<PedidoItem> listaPedidoItens = new List<PedidoItem>
{
    PedidoItem.Inserir("1", "", 29.30, Guid.Parse("9e532084-a7fe-4bc6-8362-25bc43edb828"), Guid.Parse("61ff80c6-e0f8-4464-9b46-cedc817b2fce")),
    PedidoItem.Inserir("2", "", 100, Guid.Parse("a74293c0-6d46-4151-b159-4c50b22a19a9"), Guid.Parse("e161fbad-57f0-4e90-95ae-d99a01998bcc")),
    PedidoItem.Inserir("3", "", 73.20, Guid.Parse("c550ce44-5a46-41ae-8c86-486a9a43b839"), Guid.Parse("2fbfc5bc-a680-4e62-bf6c-1a41a1e08d1c"))
};


// I N S E R I R 
app.MapPost("/api/pedido-item/inserir/", (PedidoItem novoPedidoItem) =>
{
    var pedido = PedidoItem.Inserir(novoPedidoItem.Nome, novoPedidoItem.Descricao, novoPedidoItem.Preco, novoPedidoItem.PedidoId, novoPedidoItem.ItemId);
    listaPedidoItens.Add(pedido);

    return Results.Created($"/api/pedido-item/inserir/{pedido.Id}", "Item do pedido registrado com sucesso!");
}).WithTags(new[] { "Item de Pedido" });


// O B T E R    I D
app.MapGet("/api/pedido-item/obter-por-id/{id}", (Guid id) =>
{
    if (id == Guid.Empty)
    {
        return Results.BadRequest("Id inválido");
    }

    var pedidoItem = listaPedidoItens.FirstOrDefault(c => c.Id == id);

    if (pedidoItem == null)
    {
        return Results.NotFound("Pedido de item não encontrado.");
    }

    return Results.Ok(pedidoItem);
}).WithTags(new[] { "Item de Pedido" });


// L I S T A R
app.MapGet("/api/pedido-item/listar/", () =>
{
    return Results.Ok(listaPedidoItens);
}).WithTags(new[] { "Item de Pedido" });

// A T U A L I Z A R
app.MapPut("/api/pedido-item/atualizar/{id}", (Guid id, PedidoItem pedidoAtualizado) =>
{
    var pedidoItem = listaPedidoItens.FirstOrDefault(c => c.Id == id);

    if (pedidoItem == null)
    {
        return Results.NotFound("Pedido não encontrado.");
    }

    pedidoItem = PedidoItem.Atualizar(pedidoItem, pedidoAtualizado.Nome, pedidoAtualizado.Descricao, pedidoAtualizado.Preco);

    return Results.Ok(new { mensagem = "Item do pedido atualizado com sucesso!", pedidoItem });
}).WithTags(new[] { "Item de Pedido" });


// R E M O V E R
app.MapDelete("/api/pedido-item/remover/{id}", (Guid id) =>
{
    var pedidoItem = listaPedidoItens.FirstOrDefault(c => c.Id == id);

    if (pedidoItem == null)
    {
        return Results.NotFound("Pedido de item não encontrado.");
    }

    pedidoItem = PedidoItem.Remover(pedidoItem);
    listaPedidoItens.Remove(pedidoItem);

    return Results.Ok(new { mensagem = "Item do pedido removido com sucesso!", pedidoItem });
}).WithTags(new[] { "Item de Pedido" });




// U S U Á R I O

List<Usuario> listaUsuarios = new List<Usuario>
{

    Usuario.Inserir("Cauã Fernado", "caua.fernando@jetstar.com.br", "QEf3QeTi2w"), // Id = Guid.Parse("dcce74a1-af05-4ed3-8a61-1d1969eff104"),
    Usuario.Inserir("Francisco", "francisco12345@gmail.com", "F5KKtwLflu"), // Id = Guid.Parse("7dd48cf2-dad6-409b-8a5f-45c0e9dcb919"),
    Usuario.Inserir("Sônia Helena", "sonia_helena_gatinha@sabesp.com.br", "RSTK7plbqn") // Id = Guid.Parse("3051ae3a-602b-4fa8-8328-3b80efa41c4e"),
};


// I N S E R I R 
app.MapPost("/api/usuario/inserir/", (Usuario novoUsuario) =>
{
    var usuario = Usuario.Inserir(novoUsuario.Nome, novoUsuario.Email, novoUsuario.Senha);
    listaUsuarios.Add(usuario);

    return Results.Created($"api/usuario/inserir/{usuario.Id}", "Usuário cadastrado com sucesso!");
}).WithTags(new[] { "Usuário" });


// O B T E R    I D
app.MapGet("/api/usuario/obter-por-id/{id}", (Guid id) =>
{
    if (id == Guid.Empty)
    {
        return Results.BadRequest("Id inválido");
    }

    var usuario = listaUsuarios.FirstOrDefault(c => c.Id == id);

    if (usuario == null)
    {
        return Results.NotFound("Usuário não encontrado.");
    }

    return Results.Ok(usuario);
}).WithTags(new[] { "Usuário" });


// L I S T A R
app.MapGet("/api/usuario/listar/", () =>
{
    return Results.Ok(listaUsuarios);
}).WithTags(new[] { "Usuário" });


// A T U A L I Z A R
app.MapPut("/api/usuario/atualizar/{id}", (Guid id, Usuario usuarioAtualizado) =>
{
    var usuario = listaUsuarios.FirstOrDefault(c => c.Id == id);

    if (usuario == null)
    {
        return Results.NotFound("Usuario não encontrado.");
    }

    usuario = Usuario.Atualizar(usuario, usuarioAtualizado.Nome, usuarioAtualizado.Email, usuarioAtualizado.Senha, usuarioAtualizado.TipoUsuario);

    return Results.Ok(new { mensagem = "Usuário atualizado com sucesso!", usuario });
}).WithTags(new[] { "Usuário" });


// R E M O V E R
app.MapDelete("/api/usuario/remover/{id}", (Guid id) =>
{
    var usuario = listaUsuarios.FirstOrDefault(c => c.Id == id);

    if (usuario == null)
    {
        return Results.NotFound("Usuário não encontrado.");
    }

    usuario = Usuario.Remover(usuario);
    listaUsuarios.Remove(usuario);

    return Results.Ok(new { mensagem = "Usuário removido com sucesso!", usuario });
}).WithTags(new[] { "Usuário" });

app.Run();