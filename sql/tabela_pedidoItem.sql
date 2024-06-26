create table public.PedidoItem (
	id uuid primary key,
	Nome varchar(20) not null,
	Preco double not null,
	Descricao text not null,
	DataCriacao timestamp not null default current_timestamp,
	DataAtualizacao timestamp,
	DataDelecao timestamp,
	Ativo boolean not null,
	PedidoId uuid not null,
	constraint FK_Pedido foreign key (PedidoId) references public.Pedido(Id),
	ItemId uuid not null,
	constraint FK_Item foreign key (ItemId) references public.Item(Id)
);