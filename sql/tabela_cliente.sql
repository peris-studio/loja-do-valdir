-- Script tabela Cliente

CREATE TABLE public.Cliente (
    id UUID PRIMARY KEY,  -- UUID para representar o Id como GUID
    nome VARCHAR(30) NOT NULL,
    sobrenome VARCHAR(50) NOT NULL,
    idade INTEGER NOT NULL,
    sexo CHAR(1) CHECK (sexo IN ('M', 'F')) not null,
    data_nascimento DATE NOT NULL,  -- Armazenar somente a data de nascimento
    data_criacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    data_atualizacao TIMESTAMP,
    data_delecao TIMESTAMP,
    ativo BOOLEAN NOT NULL
);

-- Inserção de dados de exemplo para a tabela Cliente
INSERT INTO public.Cliente (Id, Nome, Sobrenome, Idade, Sexo, DataNascimento, DataCriacao, Ativo)
VALUES
    ('1', 'João', 'Silva', 30, 'M', '1994-05-10', current_timestamp, true),
    ('2', 'Maria', 'Souza', 25, 'F', '1999-08-15', current_timestamp, true),
    ('3', 'Pedro', 'Ferreira', 28, 'M', '1996-12-20', current_timestamp, true),
    ('4', 'Ana', 'Martins', 35, 'F', '1989-04-05', current_timestamp, true),
    ('5', 'Lucas', 'Pereira', 22, 'M', '2002-02-28', current_timestamp, true);
