CREATE TYPE StatusPedido AS ENUM ('Criado', 'EmPreparacao', 'EmEntrega', 'Entregue', 'Cancelado');

CREATE TABLE public.Pedido (
	Id UUID PRIMARY KEY,
	Status StatusPedido NOT NULL,
	PrevisaoEntrega DATE NOT NULL,
	DataCriacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	DataAtualizacao TIMESTAMP,
	DataDelecao TIMESTAMP,
	Ativo BOOLEAN NOT NULL,
	ClienteId UUID NOT NULL,
	CONSTRAINT FK_Cliente FOREIGN KEY (ClienteId) REFERENCES public.Cliente(Id),
	EnderecoId UUID NOT NULL,
	CONSTRAINT FK_Endereco FOREIGN KEY (EnderecoId) REFERENCES public.Endereco(Id),
	ContatoId UUID NOT NULL,
	CONSTRAINT FK_Contato FOREIGN KEY (ContatoId) REFERENCES public.Contato(Id),
	UsuarioId UUID NOT NULL,
	CONSTRAINT FK_Usuario FOREIGN KEY (UsuarioId) REFERENCES public.Usuario(Id),
);

INSERT INTO public.Pedido (Id, Status, PrevisaoEntrega, DataCriacao, Ativo, ClienteId, EnderecoId, ContatoId, UsuarioId)
VALUES

    ('d0725597-8365-4d14-bf25-ce0d1bf6fb88', 'Pendente', '2024-07-10', current_timestamp, TRUE, '84bae1d3-6463-4e05-958b-3e531038eea3', '23301ef2-e8e3-4628-9fac-19ffb035e8ca', '60cc1b17-6bf7-4058-9c0e-7ce194d3559d', '7b60647b-86d4-49e4-84ed-737d64da2120'),
    ('3209d974-0d4c-4601-8362-045f995401d6', 'Processando', '2024-07-12', CURRENT_TIMESTAMP, TRUE, '78dd2ca2-10e1-4185-8d43-0a964fdee0af', '7e1044c2-1de6-4294-a57a-a7a1ebce3248', '4c6fb5e9-8073-4bfe-8095-49c173108983', '9adcd1c6-e295-447a-87ba-1a70c2d418fe'),
    ('fdfd664d-dc1a-41b5-9297-d58acb5c8be3', 'Enviado', '2024-07-15', CURRENT_TIMESTAMP, TRUE, '458e5b2c-c1e9-424b-91f7-1dabefc696b5', '9332dd1c-7700-4e1d-846f-464d6bdacb7c', 'f2dd29b7-8592-4166-9f09-fb57dd1cb83d', '49f07c24-1895-4751-8cad-91512886fe3a'),
    ('e3307e6f-8a80-44d9-93dc-6fe7e2fd1f9b', 'Entregue', '2024-07-20', CURRENT_TIMESTAMP, TRUE, 'bda25244-669e-4f38-9fd8-8041bcffad79', '4612fb3c-60b9-4347-9ab4-a0ae7a967b68', 'a999c838-0c75-4d70-8f64-d560cac90965', 'cb3471a7-31fd-4e97-a12d-6b9085cbe1a0'),
    ('a6f96265-63a7-4eed-86e2-d0d66133293c', 'Cancelado', '2024-07-25', CURRENT_TIMESTAMP, TRUE, 'aaa4a53a-4bd4-42ce-a03f-1c0afbf69379', '08d7ff4f-e7e9-4e82-9fa2-b6a002aecf65', '257c9a52-f4b7-4e29-af5e-7406ff11c6e2', '50fc31cc-2b53-4283-8348-cd23c9e26442');