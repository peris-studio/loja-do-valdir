create table public.ItemDesconto (
	id uuid primary key,
	Nome varchar(20) not null,
	PrecoComum double not null,
	PorcentagemDesconto double not null,
	PrecoDescontado double not null,
	DataInicio timestamp not null,
	DataTermino timestamp not null,
	DataCriacao timestamp not null default current_timestamp,
	DataAtualizacao timestamp,
	DataDelecao timestamp,
	Ativo boolean not null,
	ItemId uuid not null,
	constraint FK_Item foreign key (ItemId) references public.Item(Id)
);