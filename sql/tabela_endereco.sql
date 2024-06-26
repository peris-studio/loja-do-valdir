create table public.Endereco (
	id uuid primary key,
	Logradouro varchar(30) not null,
	Numero varchar(10) not null,
	Bairro varchar(20) not null,
	Cidade varchar(30) not null,
	UF char(2) not null,
	DataCriacao timestamp not null default current_timestamp,
	DataAtualizacao timestamp,
	DataDelecao timestamp,
	Ativo boolean not null,
	ClienteId uuid not null,
	constraint FK_ClienteId foreign key (ClienteId) references public.Cliente(Id)
);
