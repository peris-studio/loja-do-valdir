CREATE TABLE public.Contato (
	Id UUID PRIMARY key,
	CodigoDDI VARCHAR(5) NOT NULL,
	CodigoDDD CHAR(2) NOT NULL,
	CodigoTelefone VARCHAR(9) NOT NULL,
	TelefonePrincipal BOOLEAN NOT NULL,
	DataCriacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	DataAtualizacao TIMESTAMP,
	DataDelecao TIMESTAMP,
	Ativo BOOLEAN NOT NULL,
	ClienteId  UUID NOT NULL, 
	CONSTRAINT FK_ClienteId FOREIGN KEY (ClienteId) REFERENCES public.Cliente(Id)
);


INSERT INTO public.Contato (Id, CodigoDDI, CodigoDDD, CodigoTelefone, TelefonePrincipal, DataCriacao, Ativo, ClienteId)
VALUES

    ('60cc1b17-6bf7-4058-9c0e-7ce194d3559d', '+55', '21', '996842570', TRUE, CURRENT_TIMESTAMP, TRUE, '84bae1d3-6463-4e05-958b-3e531038eea3'),
    ('4c6fb5e9-8073-4bfe-8095-49c173108983', '+55', '11', '936694527', TRUE, CURRENT_TIMESTAMP, TRUE, '78dd2ca2-10e1-4185-8d43-0a964fdee0af'),
    ('f2dd29b7-8592-4166-9f09-fb57dd1cb83d', '+55', '31', '926280754', TRUE, CURRENT_TIMESTAMP, TRUE, '458e5b2c-c1e9-424b-91f7-1dabefc696b5'),
    ('a999c838-0c75-4d70-8f64-d560cac90965', '+55', '41', '992569835', TRUE, CURRENT_TIMESTAMP, TRUE, 'bda25244-669e-4f38-9fd8-8041bcffad79'),
    ('257c9a52-f4b7-4e29-af5e-7406ff11c6e2', '+55', '51', '936800104', TRUE, CURRENT_TIMESTAMP, TRUE, 'aaa4a53a-4bd4-42ce-a03f-1c0afbf69379');