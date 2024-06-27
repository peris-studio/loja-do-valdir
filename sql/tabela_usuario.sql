CREATE TYPE TipoUsuario AS ENUM ('Usuario', 'Administrador');

CREATE TABLE public.Usuario (
    Id UUID PRIMARY KEY,
    Nome VARCHAR(20) NOT NULL,
    Email VARCHAR(225) CHECK (LENGTH(Email) > 3) NOT NULL,
    Senha VARCHAR(20) CHECK (LENGTH(Senha) >= 8) NOT NULL,
    TipoUsuario TipoUsuario NOT NULL,
    DataCriacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao TIMESTAMP,
    DataDelecao TIMESTAMP,
    Ativo BOOLEAN NOT NULL
);

INSERT INTO public.Usuario(Id, Nome, Email, Senha, TipoUsuario, DataCriacao, Ativo)
VALUES
    ('7b60647b-86d4-49e4-84ed-737d64da2120', 'Kaique Antonio', 'kaiqueantonio@beminvestir.com.br', '6o4jpoxKKA', Usuario, CURRENT_TIMESTAMP, TRUE),
    ('9adcd1c6-e295-447a-87ba-1a70c2d418fe', 'Maria', 'mariadesouza@gmail.com', 'bTs1afYRyb', Usuario, CURRENT_TIMESTAMP, TRUE),
    ('49f07c24-1895-4751-8cad-91512886fe3a', 'Pedro', 'pedroferreirapaixao@hotmail.com', 'OSpfl5XfOw', Usuario, CURRENT_TIMESTAMP, TRUE),
    ('cb3471a7-31fd-4e97-a12d-6b9085cbe1a0', 'Ana Bárbara', 'aba_barba_martins@outlook.com', 'qp6DAkafnX', Usuario, CURRENT_TIMESTAMP, TRUE),
    ('50fc31cc-2b53-4283-8348-cd23c9e26442', 'Lucas', 'lucas.pg@lol.com', 'ksyFuck38', Usuario, CURRENT_TIMESTAMP, TRUE);