-- Script tabela Cliente

CREATE TABLE public.Cliente (
    Id UUID PRIMARY KEY,  -- UUID para representar o Id como GUID
    Nome VARCHAR(20) NOT NULL,
    Sobrenome VARCHAR(50) NOT NULL,
    Idade INTEGER NOT NULL,
    Sexo CHAR(1) CHECK (sexo IN ('M', 'F')) NOT NULL,
    DataNascimento DATE NOT NULL,  -- Armazenar somente a data de nascimento
    DataCriacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao TIMESTAMP,
    DataDelecao TIMESTAMP,
    Ativo BOOLEAN NOT NULL
);

-- Inserção de dados de exemplo para a tabela Cliente
INSERT INTO public.Cliente (Id, Nome, Sobrenome, Idade, Sexo, DataNascimento, DataCriacao, Ativo)
VALUES
    ('84bae1d3-6463-4e05-958b-3e531038eea3', 'Kaique Antonio', 'Silva', 30, 'M', '1994-05-10', CURRENT_TIMESTAMP, TRUE),
    ('78dd2ca2-10e1-4185-8d43-0a964fdee0af', 'Maria', 'de Souza', 25, 'F', '1999-08-15', CURRENT_TIMESTAMP, TRUE),
    ('458e5b2c-c1e9-424b-91f7-1dabefc696b5', 'Pedro', 'Ferreira da Paixão', 28, 'M', '1996-12-20', CURRENT_TIMESTAMP, TRUE),
    ('bda25244-669e-4f38-9fd8-8041bcffad79', 'Ana Bárbara', 'Martins', 35, 'F', '1989-04-05', CURRENT_TIMESTAMP, TRUE),
    ('aaa4a53a-4bd4-42ce-a03f-1c0afbf69379', 'Lucas', 'Pereira Gomes', 22, 'M', '2002-02-28', CURRENT_TIMESTAMP, TRUE);
