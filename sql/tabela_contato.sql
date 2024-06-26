CREATE TABLE public.Contato (
	id UUID PRIMARY key,
	Codigo_DDI varchar(5) not null,
	Codigo_DDD char(2) not null,
	Codigo_Telefone char(9) not null,
	Telefone_Principal boolean not null,
	Data_Criacao timestamp not null default current_timestamp,
	DataAtualizacao timestamp,
	DataDelecao timestamp,
	Ativo boolean not null,
	ClienteId  UUID not null, 
	CONSTRAINT fk_cliente_id FOREIGN KEY (ClienteId) REFERENCES public.Cliente(Id)
);

-- Inserção de dados de exemplo para a tabela Contato
INSERT INTO public.Contato (Id, CodigoDDI, CodigoDDD, CodigoTelefone, TelefonePrincipal, DataCriacao, Ativo, ClienteId)
VALUES
    ('1', '+55', '21', '9999-9999', true, current_timestamp, true, '1'),
    ('2', '+55', '11', '8888-8888', false, current_timestamp, true, '2'),
    ('3', '+55', '31', '7777-7777', true, current_timestamp, true, '3'),
    ('4', '+55', '41', '6666-6666', true, current_timestamp, true, '4'),
    ('5', '+55', '51', '5555-5555', false, current_timestamp, true, '5');
