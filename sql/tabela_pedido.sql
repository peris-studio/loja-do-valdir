create type StatusPedido as enum ('Criado', 'EmPreparacao', 'EmEntrega', 'Entregue', 'Cancelado');

create table public.Pedido (
	id uuid primary key,
	StatusPedido Status not null,
	PrevisaoEntrega date not null,
	DataCriacao timestamp not null default current_timestamp,
	DataAtualizacao timestamp,
	DataDelecao timestamp,
	Ativo boolean not null,
	ClienteId uuid not null,
	constraint FK_Cliente foreign key (ClienteId) references public.Cliente(Id),
	EnderecoId uuid not null,
	constraint FK_Endereco foreign key (EnderecoId) references public.Endereco(Id),
	ContatoId uuid not null,
	constraint FK_Contato foreign key (ContatoId) references public.Contato(Id),
	UsuarioId uuid not null,
	constraint FK_Usuario foreign key (UsuarioId) references public.Usuario(Id),
);