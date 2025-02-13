namespace LojaDoValdir.Modules;

public static class ItemModule
{
    private static List<Item> listaItens = new List<Item>
    {
        Item.Inserir("Leite Fermentado Yakult", "80g", "O Leite Fermentado Yakult é um alimento à base de leite desnatado, fermentado por lactobacilo selecionado, o exclusivo probiótico Lactobacillus casei Shirota, que resiste à acidez do estômago e chega vivo em grande quantidade ao intestino. A ingestão regular deste lactobacilo, juntamente com uma alimentação equilibrada, pode contribuir com a saúde do trato gastrointestinal.",
                    5.90, TipoItem.Laticinios, true, 40, 10),
        Item.Inserir("Pão Francês", "", "Fresco e Crocante", 0.50, TipoItem.Padaria, true, 100, 0),
        Item.Inserir("Maçã Gala", "A variar", "Maçã doce e suculente, rica em fibras e vitaminas.",
                    1.29, TipoItem.FrutasVegetais, true, 13, 0)
    };

    public static void MapItemEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/item").WithTags("Item");

        // I N S E R I R 
        group.MapPost("/inserir", (Item novoItem) =>
        {
            var item = Item.Inserir(novoItem.Nome, novoItem.Peso, novoItem.Descricao, novoItem.Preco, novoItem.TipoItem, novoItem.ItemEmEstoque, novoItem.QuantidadeUnidade, novoItem.QuantidadeFardo);
            listaItens.Add(item);

            return Results.Created($"/api/item/inserir/{item.Id}/", "Item cadastrado com sucesso!");
        });

        // O B T E R    I D
        group.MapGet("/obter-por-id/{id}", (Guid id) =>
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
        });

        // L I S T A R
        group.MapGet("/listar", () =>
        {
            return Results.Ok(listaItens);
        });

        // A T U A L I Z A R
        group.MapPut("/atualizar/{id}", (Guid id, Item itemAtualizado) =>
        {
            var item = listaItens.FirstOrDefault(c => c.Id == id);

            if (item == null)
            {
                return Results.NotFound("Item não encontrado.");
            }

            item = Item.Atualizar(item, itemAtualizado.Nome, itemAtualizado.Peso, itemAtualizado.Descricao, itemAtualizado.Preco, itemAtualizado.TipoItem, itemAtualizado.ItemEmEstoque, itemAtualizado.QuantidadeUnidade, itemAtualizado.QuantidadeFardo);

            return Results.Ok(new { mensagem = "Item atualizado com sucesso!", item });
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", (Guid id) =>
        {
            var item = listaItens.FirstOrDefault(c => c.Id == id);

            if (item == null)
            {
                return Results.NotFound("Item não encontrado.");
            }

            item = Item.Remover(item);
            listaItens.Remove(item);

            return Results.Ok(new { mensagem = "Item removido com sucesso!", item });
        });
    }
}