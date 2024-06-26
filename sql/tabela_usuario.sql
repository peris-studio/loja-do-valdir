create type TipoUsuario as enum ('Usuario', 'Administrador');

create table Usuario public.Usuario (
	id uuid primary key,
	Nome varchar(20) not null,
	Email varchar(225) check (length(Email) >3) not null,
	Senha varchar(20) check (length(Senha) >=8) not null,
	TipoUsuario TipoUsuario not null,
	DataCriacao timestamp not null default current_timestamp,
	DataAtualizacao timestamp,
	DataDelecao timestamp,
	Ativo boolean not null
);

