CREATE TABLE public.PedidoItem (
    Id UUID PRIMARY KEY,
    Nome VARCHAR(20) NOT NULL,
    Preco MONEY NOT NULL,
    Descricao TEXT NOT NULL,
    DataCriacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao TIMESTAMP,
    DataDelecao TIMESTAMP,
    Ativo BOOLEAN NOT NULL,
    PedidoId UUID NOT NULL,
    CONSTRAINT FK_Pedido FOREIGN KEY (PedidoId) REFERENCES public.Pedido(Id),
    ItemId UUID NOT NULL,
    CONSTRAINT FK_Item FOREIGN KEY (ItemId) REFERENCES public.Item(Id)
);

INSERT INTO public.PedidoItem(Id, Nome, Preco, Descricao, DataCriacao, Ativo, PedidoId, ItemId)
VALUES

    ('47babe27-5441-483d-baa3-2cdae08b29e1', 'Arroz', 10.00, 'Arroz tipo parboilizado', CURRENT_TIMESTAMP, TRUE, 'd0725597-8365-4d14-bf25-ce0d1bf6fb88', '43e0c350-e5b5-475f-8535-af8e17eb02cf'),
    ('11a1df31-ed60-4459-b722-9a9e36f0e0c2', 'Feijão', 8.00, 'Feijão carioca', CURRENT_TIMESTAMP, TRUE, '3209d974-0d4c-4601-8362-045f995401d6', '85b6b60d-0d39-4658-a8d2-f669596a77fa'),
    ('49079aa0-9c41-4991-8e2b-3055227ff121', 'Sal', 5.00, 'Sal refinado', CURRENT_TIMESTAMP, TRUE, 'fdfd664d-dc1a-41b5-9297-d58acb5c8be3', 'ff1059d5-6100-49c9-80f5-c934701c3481'),
    ('3673bfa3-cea9-41de-804d-5e12dab3f647', 'Azeite', 20.00, 'Azeite de oliva extra virgem', CURRENT_TIMESTAMP, TRUE, 'e3307e6f-8a80-44d9-93dc-6fe7e2fd1f9b', '3d7a90cd-959e-4a44-b2df-29b923b9cfbc'),
    ('b65e78f7-1966-44fa-baac-3351b1f37441', 'Farinha de Trigo', 6.00, 'Farinha de trigo tipo 1', CURRENT_TIMESTAMP, TRUE, 'a6f96265-63a7-4eed-86e2-d0d66133293c', '8c306e98-400a-44d9-bd1a-d34a95df4717');