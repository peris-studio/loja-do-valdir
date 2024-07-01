CREATE TABLE public.Endereco (
    Id UUID PRIMARY KEY,
    Logradouro VARCHAR(50) NOT NULL,
    Numero VARCHAR(10) NOT NULL,
    Bairro VARCHAR(50) NOT NULL,
    Cidade VARCHAR(50) NOT NULL,
    UF CHAR(2) NOT NULL,
    DataCriacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao TIMESTAMP,
    DataDelecao TIMESTAMP,
    Ativo BOOLEAN NOT NULL,
    ClienteId UUID NOT NULL,
    CONSTRAINT FK_ClienteId FOREIGN KEY (ClienteId) REFERENCES public.Cliente(Id)
);

INSERT INTO public.Endereco (Id, Logradouro, Numero, Bairro, Cidade, UF, DataCriacao, Ativo, ClienteId)
VALUES

    ('23301ef2-e8e3-4628-9fac-19ffb035e8ca', 'Rua 02 Norte', '275', 'Residencial Kairós', 'Dourados', 'MS', CURRENT_TIMESTAMP, TRUE, '84bae1d3-6463-4e05-958b-3e531038eea3'),
    ('7e1044c2-1de6-4294-a57a-a7a1ebce3248', 'Rua João Quirino', '135A', 'Setor Tradicional (Planaltina)', 'Brasília', 'DF', CURRENT_TIMESTAMP, TRUE, '78dd2ca2-10e1-4185-8d43-0a964fdee0af'),
    ('9332dd1c-7700-4e1d-846f-464d6bdacb7c', 'Quadra 605 Sul Alameda 29', '903', 'Plano Diretor Sul', 'Itanhaém', 'SP', CURRENT_TIMESTAMP, TRUE, '458e5b2c-c1e9-424b-91f7-1dabefc696b5'),
    ('4612fb3c-60b9-4347-9ab4-a0ae7a967b68', 'Rua Flávio Iosif Pires', '603', 'Parque Residencial Cândido Portinari', 'Ribeirão Preto', 'SP', current_timestamp, TRUE, 'bda25244-669e-4f38-9fd8-8041bcffad79'),
    ('08d7ff4f-e7e9-4e82-9fa2-b6a002aecf65', 'Rua Laranjeiras', '1399', 'Tenoné', 'Praia Grande', 'SP', CURRENT_TIMESTAMP, TRUE, 'aaa4a53a-4bd4-42ce-a03f-1c0afbf69379');