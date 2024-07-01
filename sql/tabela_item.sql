CREATE TYPE TIPOITEM AS ENUM ('AlimentosBasicos', 'FrutasVegetais', 'Carnes', 'Laticinios', 'LimpezaDomestica', 'LimpezaPessoal', 'CuidadosDomesticos', 'Bebidas', 'Padaria', 'Racoes');

CREATE TABLE public.Item (
	Id UUID PRIMARY KEY,
	Nome VARCHAR(50) NOT NULL,
	Peso VARCHAR(10) NOT NULL,
	Descricao TEXT NOT NULL,
	Preco MONEY NOT NULL,
	TipoItem TIPOITEM NOT NULL,
	ItemEmEstoque BOOLEAN NOT NULL,
	QuantidadeUnidade INTEGER NOT NULL,
	QuantidadeFardo INTEGER NOT NULL,
	DataCriacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	DataAtualizacao TIMESTAMP,
	DataDelecao TIMESTAMP,
	Ativo BOOLEAN NOT NULL
);

select * from public.Item

INSERT INTO public.Item (Id, Nome, Peso, Descricao, Preco, TipoItem, ItemEmEstoque, QuantidadeUnidade, QuantidadeFardo, DataCriacao, Ativo)
VALUES

    -- Alimentos Básicos
    ('43e0c350-e5b5-475f-8535-af8e17eb02cf', 'Arroz', '1kg', 'Arroz tipo parboilizado', 10.00, 'AlimentosBasicos', TRUE, 100, 0, CURRENT_TIMESTAMP, TRUE),
    ('85b6b60d-0d39-4658-a8d2-f669596a77fa', 'Feijão', '1kg', 'Feijão carioca', 8.00, 'AlimentosBasicos', TRUE, 80, 10, CURRENT_TIMESTAMP, TRUE),
    ('ff1059d5-6100-49c9-80f5-c934701c3481', 'Sal', '500g', 'Sal refinado', 5.00, 'AlimentosBasicos', TRUE, 150, 2, CURRENT_TIMESTAMP, TRUE),
    ('3d7a90cd-959e-4a44-b2df-29b923b9cfbc', 'Azeite', '500ml', 'Azeite de oliva extra virgem', 20.00, 'AlimentosBasicos', TRUE, 50, 0, CURRENT_TIMESTAMP, TRUE),
    ('8c306e98-400a-44d9-bd1a-d34a95df4717', 'Farinha de Trigo', '1kg', 'Farinha de trigo tipo 1', 6.00, 'AlimentosBasicos', TRUE, 90, 0, CURRENT_TIMESTAMP, TRUE),

    -- Frutas e Vegetais
    ('cb4da4b3-6f34-4e50-81d3-8bb748b10e2d', 'Maçã', '200g', 'Maçã Fuji', 2.50, 'FrutasVegetais', TRUE, 200, 0, CURRENT_TIMESTAMP, TRUE),
    ('265915c8-57cd-4dbf-bb63-8c830aee1f45', 'Alface', '300g', 'Alface crespa', 3.00, 'FrutasVegetais', TRUE, 120, 0, CURRENT_TIMESTAMP, TRUE),
    ('f965eb60-cd04-4327-9433-6613b0cb9580', 'Tomate', '250g', 'Tomate italiano', 4.00, 'FrutasVegetais', TRUE, 150, 0, CURRENT_TIMESTAMP, TRUE),
    ('3e3a40e9-a4b4-4ed5-9ffd-dc873cee8762', 'Banana', '150g', 'Banana nanica', 1.80, 'FrutasVegetais', TRUE, 250, 0, CURRENT_TIMESTAMP, TRUE),
    ('68a9c547-5721-4a6d-afb1-a9367d2238c5', 'Cenoura', '200kg', 'Cenoura orgânica', 2.50, 'FrutasVegetais', TRUE, 180, 0, CURRENT_TIMESTAMP, TRUE),

    -- Carnes
    ('4a6543b4-cf74-497f-97f2-04758a36a514', 'Carne Bovina', '1kg', 'Carne bovina para churrasco', 30.00, 'Carnes', TRUE, 50, 0, CURRENT_TIMESTAMP, TRUE),
    ('04a12d87-ce08-4df3-bf26-838c86a75dcf', 'Frango', '1kg', 'Peito de frango sem osso', 15.00, 'Carnes', TRUE, 70, 0, CURRENT_TIMESTAMP, TRUE),
    ('10923fb2-6807-4054-b305-22dc1c9f15ac', 'Peixe', '500g', 'Filé de peixe tilápia', 25.00, 'Carnes', TRUE, 30, 0, CURRENT_TIMESTAMP, TRUE),
    ('4d6942a0-c317-45b6-8300-48915323a6b1', 'Linguiça', '300g', 'Linguiça calabresa defumada', 12.00, 'Carnes', TRUE, 90, 0, CURRENT_TIMESTAMP, TRUE),
    ('ba09bb88-57cc-479d-a2af-3f022bf86810', 'Cordeiro', '800g', 'Costeletas de cordeiro', 40.00, 'Carnes', TRUE, 20, 0, CURRENT_TIMESTAMP, TRUE),

    -- Laticínios
    ('5079bff3-4e6d-427d-96b2-6ca2e168c9af', 'Leite', '1L', 'Leite integral', 5.00, 'Laticinios', TRUE, 200, 50, CURRENT_TIMESTAMP, TRUE),
    ('44189eb6-7291-4e5f-9f51-c7ed9c2ffc6c', 'Queijo', '300g', 'Queijo minas frescal', 12.00, 'Laticinios', TRUE, 60, 0, CURRENT_TIMESTAMP, TRUE),
    ('71369a39-6d8d-47cb-b69c-adc416f6856d', 'Iogurte', '200g', 'Iogurte natural desnatado', 3.50, 'Laticinios', TRUE, 120, 0, CURRENT_TIMESTAMP, TRUE),
    ('670c640c-e6e0-4483-938f-aada8d83bb9c', 'Manteiga', '600g', 'Manteiga sem sal', 8.00, 'Laticinios', TRUE, 80, 0, CURRENT_TIMESTAMP, TRUE),
    ('7ff0f43b-8781-498b-a17f-b30da5afa0de', 'Creme de Leite', '200g', 'Creme de leite fresco', 6.00, 'Laticinios', TRUE, 100, 10, CURRENT_TIMESTAMP, TRUE),

    -- Limpeza Doméstica
    ('06e07332-4505-48d3-9f4e-cf0b73a1e34c', 'Detergente', '500ml', 'Detergente neutro', 4.00, 'LimpezaDomestica', TRUE, 150, 20, CURRENT_TIMESTAMP, TRUE),
    ('da9d056b-86ea-4156-9c00-8b9b3f48a4d2', 'Desinfetante', '1L', 'Desinfetante floral', 8.00, 'LimpezaDomestica', TRUE, 80, 0, CURRENT_TIMESTAMP, TRUE),
    ('837c47f7-d0d9-4c0a-84bd-a4ac1e011327', 'Sabão em Pó', '1kg', 'Sabão em pó para roupas', 10.00, 'LimpezaDomestica', TRUE, 90, 0, CURRENT_TIMESTAMP, TRUE),
    ('cc58e754-2fb5-4cfb-b70a-e80e7b7a257c', 'Esponja', '50g', 'Esponja de limpeza multiuso', 2.50, 'LimpezaDomestica', TRUE, 200, 40, CURRENT_TIMESTAMP, TRUE),
    ('ba2aa91b-c026-422a-bed2-0e30c699db5b', 'Água Sanitária', '1L', 'Água sanitária concentrada', 6.00, 'LimpezaDomestica', TRUE, 120, 0, CURRENT_TIMESTAMP, TRUE),

    -- Limpeza Pessoal
    ('2a68ba85-d072-47e2-8156-e484a4a8545f', 'Shampoo', '300ml', 'Shampoo para cabelos ressecados', 15.00, 'LimpezaPessoal', TRUE, 100, 0, CURRENT_TIMESTAMP, TRUE),
    ('69277292-a299-4df7-804e-aa20991ca3db', 'Condicionador', '300ml', 'Condicionador hidratante', 12.00, 'LimpezaPessoal', TRUE, 120, 0, CURRENT_TIMESTAMP, TRUE),
    ('dee3167f-0ac1-47fc-a60d-f5d2da2b681d', 'Sabonete', '90g', 'Sabonete líquido intímo', 3.50, 'LimpezaPessoal', TRUE, 200, 0, CURRENT_TIMESTAMP, TRUE),
    ('d005d754-fe07-4e6f-a60b-6a0f86ccfb62', 'Creme Dental', '90g', 'Creme dental com flúor', 4.00, 'LimpezaPessoal', TRUE, 180, 0, CURRENT_TIMESTAMP, TRUE),
    ('b90c5ee5-ada7-4cdf-8bb2-0b7abaff9e4e', 'Desodorante', '150ml', 'Desodorante aerosol 24hrs', 10.00, 'LimpezaPessoal', TRUE, 150, 0, CURRENT_TIMESTAMP, TRUE),

    -- Cuidados Domésticos
    ('59fdbb6e-9cf1-43b8-a494-483e8957fd87', 'Vassoura', '1 unidade', 'Vassoura de pelo sintético', 18.00, 'CuidadosDomesticos', TRUE, 60, 0, CURRENT_TIMESTAMP, TRUE),
    ('246d4869-5a4f-4f45-ba3b-d20ec43bdcd4', 'Rodo', '1 unidade', 'Rodo de alumínio com borracha', 15.00, 'CuidadosDomesticos', TRUE, 70, 0, CURRENT_TIMESTAMP, TRUE),
    ('f00a2504-78a5-4b69-9b0c-d8a8a7334899', 'Pano de Limpeza', '5 unidades', 'Panos de limpeza multiuso', 6.00, 'CuidadosDomesticos', TRUE, 120, 0, CURRENT_TIMESTAMP, TRUE),
    ('8a696c26-713f-475b-bbd4-c47edfab0cfc', 'Esponja de Aço', '1 unidade', 'Esponja de aço para limpeza', 3.50, 'CuidadosDomesticos', TRUE, 200, 0, CURRENT_TIMESTAMP, TRUE),
    ('9a5b31ba-8599-4d50-95bd-e9806365a891', 'Inseticida', '300ml', 'Inseticida spray', 12.00, 'CuidadosDomesticos', TRUE, 80, 0, CURRENT_TIMESTAMP, TRUE),

    -- Bebidas
    ('a32e4238-e187-47a3-8ebd-af0b1bcce570', 'Água Mineral', '1.5L', 'Água mineral sem gás', 2.50, 'Bebidas', TRUE, 200, 10, CURRENT_TIMESTAMP, TRUE),
    ('a18705aa-0985-429d-9624-52cd063c200f', 'Refrigerante', '2L', 'Refrigerante de cola', 7.00, 'Bebidas', TRUE, 120, 10, CURRENT_TIMESTAMP, TRUE),
    ('e145b919-5e68-478f-828a-dbfff896f5e4', 'Suco de Laranja', '1L', 'Suco de laranja integral concentrado', 6.00, 'Bebidas', TRUE, 80, 5, CURRENT_TIMESTAMP, TRUE),
    ('4af3b91a-3aca-4184-b39a-795221c25b82', 'Cerveja', '350ml', 'Cerveja pilsen', 3.00, 'Bebidas', TRUE, 150, 30, CURRENT_TIMESTAMP, TRUE),
    ('35d2b40f-0026-414c-996d-47fcd3bfd377', 'Vinho', '750ml', 'Vinho tinto seco', 25.00, 'Bebidas', TRUE, 50, 0, CURRENT_TIMESTAMP, TRUE),

    -- Padaria
    ('e2ac8ed3-7ee8-4290-9e4b-e6df38a140df', 'Pão Francês', '50g', 'Pão francês fresco', 0.50, 'Padaria', TRUE, 500, 0, CURRENT_TIMESTAMP, TRUE),
    ('f9e9ccbd-0258-4d53-912f-a94547307735', 'Pão de Forma', '500g', 'Pão de forma integral', 5.00, 'Padaria', TRUE, 60, 10, CURRENT_TIMESTAMP, TRUE),
    ('203da816-320f-46af-940e-b28e4e5c22e8', 'Bolo de Chocolate', '1kg', 'Bolo de chocolate com cobertura', 20.00, 'Padaria', TRUE, 20, 0, CURRENT_TIMESTAMP, TRUE),
    ('a01ed367-90bb-4211-82bc-acbd7ed5a338', 'Croissant', '100g', 'Croissant de manteiga', 3.00, 'Padaria', TRUE, 100, 0, CURRENT_TIMESTAMP, TRUE),
    ('d3fd0a51-5e0c-4a5f-a305-9d4c7a2be01a', 'Biscoito', '200g', 'Biscoito amanteigado', 6.00, 'Padaria', TRUE, 80, 5, CURRENT_TIMESTAMP, TRUE),

    -- Rações
    ('c3cf3006-8638-47d2-a2c1-99eb4912f971', 'Ração para Cães', '3kg', 'Ração premium para cães adultos', 45.00, 'Racoes', TRUE, 40, 0, CURRENT_TIMESTAMP, TRUE),
    ('1801a6c6-e2d9-440f-89fc-114039a8decc', 'Ração para Gatos Filhotes', '2kg', 'Ração premium para gatos filhotes', 35.00, 'Racoes', TRUE, 50, 0, CURRENT_TIMESTAMP, TRUE),
    ('aa07b5ca-7a8f-41d9-82fa-a48b62aee3e2', 'Ração para Pássaros', '1kg', 'Ração para pássaros caiçara', 15.00, 'Racoes', TRUE, 70, 5, CURRENT_TIMESTAMP, TRUE),
    ('ae34c73d-9bdb-43b8-a681-7666f97b3692', 'Ração para Peixes', '500g', 'Ração em flocos para peixes ornamentais', 10.00, 'Racoes', TRUE, 60, 10, CURRENT_TIMESTAMP, TRUE),
    ('eef2a19f-893e-46c2-a42e-90718b226e9d', 'Ração para Gatos Castrados', '1kg', 'Ração balanceada para gatos adultos e castrados', 20.00, 'Racoes', TRUE, 30, 0, CURRENT_TIMESTAMP, TRUE);