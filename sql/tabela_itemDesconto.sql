CREATE TABLE public.ItemDesconto (
	Id UUID PRIMARY KEY,
	Nome VARCHAR(20) NOT NULL,
	PrecoComum MONEY NOT NULL,
	PorcentagemDesconto DECIMAL(5, 2) NOT NULL,
	PrecoDescontado MONEY NOT NULL,
	DataInicio TIMESTAMP NOT NULL,
	DataTermino TIMESTAMP NOT NULL,
	DataCriacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	DataAtualizacao TIMESTAMP,
	DataDelecao TIMESTAMP,
	Ativo BOOLEAN NOT NULL,
	ItemId UUID NOT NULL,
	CONSTRAINT FK_Item FOREIGN KEY (ItemId) REFERENCES public.Item(Id)
);

INSERT INTO public.ItemDesconto (Id, Nome, PrecoComum,  PorcentagemDesconto, PrecoDescontado, DataInicio, DataTermino, DataCriacao, Ativo, ItemId)
VALUES

    ('33d2a193-659c-4514-a9e8-be3f971833dc', 'Desconto Arroz', 10.00, 10.00, 9.00, '2024-07-01 00:00:00', '2024-07-31 23:59:59', CURRENT_TIMESTAMP, TRUE, '43e0c350-e5b5-475f-8535-af8e17eb02cf'),
    ('b282264f-ab05-4f96-b9d7-3d4b610782f4', 'Desconto Feijão', 8.00, 15.00, 6.80, '2024-07-01 00:00:00', '2024-07-31 23:59:59', CURRENT_TIMESTAMP, TRUE, '85b6b60d-0d39-4658-a8d2-f669596a77fa'),
    ('838c1355-c0bb-4ba0-b042-8ab5dd6fedb9', 'Desconto Sal', 5.00, 5.00, 4.75, '2024-07-01 00:00:00', '2024-07-31 23:59:59', CURRENT_TIMESTAMP, TRUE, 'ff1059d5-6100-49c9-80f5-c934701c3481'),
    ('48669a23-b41c-42e4-8ec4-b5363c45e704', 'Desconto Azeite', 20.00, 20.00, 16.00, '2024-07-01 00:00:00', '2024-07-31 23:59:59', CURRENT_TIMESTAMP, TRUE, '3d7a90cd-959e-4a44-b2df-29b923b9cfbc'),
    ('cc455483-1461-468d-b60d-4e634a5a6153', 'Desconto Farinha', 6.00, 10.00, 5.40, '2024-07-01 00:00:00', '2024-07-31 23:59:59', CURRENT_TIMESTAMP, TRUE, '8c306e98-400a-44d9-bd1a-d34a95df4717');