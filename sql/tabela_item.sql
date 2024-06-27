CREATE TYPE TipoItem AS ENUM ('AlimentosBasicos', 'FrutasVegetais', 'Carnes', 'Laticinios', 'LimpezaDomestica', 'LimpezaPessoal', 'CuidadosDomesticos', 'Bebidas', 'Padaria', 'Racoes');

CREATE TABLE public.Item (
	Id UUID PRIMARY KEY,
	Nome VARCHAR(50) NOT NULL,
	Peso VARCHAR(10) NOT NULL,
	Descricao TEXT NOT NULL,
	Preco MONEY NOT NULL,
	TipoItem TipoItem NOT NULL,
	ItemEmEstoque BOOLEAN NOT NULL,
	QuantidadeUnidade INTEGER NOT NULL,
	QuantidadeFardo INTEGER NOT NULL,
	DataCriacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	DataAtualizacao TIMESTAMP,
	DataDelecao TIMESTAMP,
	Ativo BOOLEAN NOT NULL
);

INSERT INTO public.Item (Id, Nome, Peso, Descricao, Preco, TipoItem, ItemEmEstoque, QuantidadeUnidade, QuantidadeFardo, DataCriacao, DataAtualizacao, Ativo)
VALUES

    -- Alimentos Básicos
    ('1', 'Arroz', '1kg', 'Arroz tipo parboilizado', 10.00, 'AlimentosBasicos', true, 100, 0, current_timestamp, current_timestamp, true),
    ('2', 'Feijão', '1kg', 'Feijão carioca', 8.00, 'AlimentosBasicos', true, 80, 10, current_timestamp, current_timestamp, true),
    ('3', 'Sal', '500g', 'Sal refinado', 5.00, 'AlimentosBasicos', true, 150, 2, current_timestamp, current_timestamp, true),
    ('4', 'Azeite', '500ml', 'Azeite de oliva extra virgem', 20.00, 'AlimentosBasicos', true, 50, 0, current_timestamp, current_timestamp, true),
    ('5', 'Farinha de Trigo', '1kg', 'Farinha de trigo tipo 1', 6.00, 'AlimentosBasicos', true, 90, 0, current_timestamp, current_timestamp, true),

    -- Frutas e Vegetais
    ('6', 'Maçã', '200g', 'Maçã Fuji', 2.50, 'FrutasVegetais', true, 200, 0, current_timestamp, current_timestamp, true),
    ('7', 'Alface', '300g', 'Alface crespa', 3.00, 'FrutasVegetais', true, 120, 0, current_timestamp, current_timestamp, true),
    ('8', 'Tomate', '250g', 'Tomate italiano', 4.00, 'FrutasVegetais', true, 150, 0, current_timestamp, current_timestamp, true),
    ('9', 'Banana', '150g', 'Banana nanica', 1.80, 'FrutasVegetais', true, 250, 0, current_timestamp, current_timestamp, true),
    ('10', 'Cenoura', '200kg', 'Cenoura orgânica', 2.50, 'FrutasVegetais', true, 180, 0, current_timestamp, current_timestamp, true),

    -- Carnes
    ('11', 'Carne Bovina', '1kg', 'Carne bovina para churrasco', 30.00, 'Carnes', true, 50, 0, current_timestamp, current_timestamp, true),
    ('12', 'Frango', '1kg', 'Peito de frango sem osso', 15.00, 'Carnes', true, 70, 0, current_timestamp, current_timestamp, true),
    ('13', 'Peixe', '500g', 'Filé de peixe tilápia', 25.00, 'Carnes', true, 30, 0, current_timestamp, current_timestamp, true),
    ('14', 'Linguiça', '300g', 'Linguiça calabresa defumada', 12.00, 'Carnes', true, 90, 0, current_timestamp, current_timestamp, true),
    ('15', 'Cordeiro', '800g', 'Costeletas de cordeiro', 40.00, 'Carnes', true, 20, 0, current_timestamp, current_timestamp, true),

    -- Laticínios
    ('16', 'Leite', '1L', 'Leite integral', 5.00, 'Laticinios', true, 200, 50, current_timestamp, current_timestamp, true),
    ('17', 'Queijo', '300g', 'Queijo minas frescal', 12.00, 'Laticinios', true, 60, 0, current_timestamp, current_timestamp, true),
    ('18', 'Iogurte', '200g', 'Iogurte natural desnatado', 3.50, 'Laticinios', true, 120, 0, current_timestamp, current_timestamp, true),
    ('19', 'Manteiga', '600g', 'Manteiga sem sal', 8.00, 'Laticinios', true, 80, 0, current_timestamp, current_timestamp, true),
    ('20', 'Creme de Leite', '200g', 'Creme de leite fresco', 6.00, 'Laticinios', true, 100, 10, current_timestamp, current_timestamp, true),

    -- Limpeza Doméstica
    ('21', 'Detergente', '500ml', 'Detergente neutro', 4.00, 'LimpezaDomestica', true, 150, 0, current_timestamp, current_timestamp, true),
    ('22', 'Desinfetante', '1L', 'Desinfetante floral', 8.00, 'LimpezaDomestica', true, 80, 0, current_timestamp, current_timestamp, true),
    ('23', 'Sabão em Pó', '1kg', 'Sabão em pó para roupas', 10.00, 'LimpezaDomestica', true, 90, 0, current_timestamp, current_timestamp, true),
    ('24', 'Esponja', '50g', 'Esponja de limpeza multiuso', 2.50, 'LimpezaDomestica', true, 200, 0, current_timestamp, current_timestamp, true),
    ('25', 'Água Sanitária', '1L', 'Água sanitária concentrada', 6.00, 'LimpezaDomestica', true, 120, 0, current_timestamp, current_timestamp, true),

    -- Limpeza Pessoal
    ('26', 'Shampoo', '300ml', 'Shampoo para cabelos ressecados', 15.00, 'LimpezaPessoal', true, 100, 0, current_timestamp, current_timestamp, true),
    ('27', 'Condicionador', '300ml', 'Condicionador hidratante', 12.00, 'LimpezaPessoal', true, 120, 0, current_timestamp, current_timestamp, true),
    ('28', 'Sabonete', '90g', 'Sabonete líquido intímo', 3.50, 'LimpezaPessoal', true, 200, 0, current_timestamp, current_timestamp, true),
    ('29', 'Creme Dental', '90g', 'Creme dental com flúor', 4.00, 'LimpezaPessoal', true, 180, 0, current_timestamp, current_timestamp, true),
    ('30', 'Desodorante', '150ml', 'Desodorante aerosol 24hrs', 10.00, 'LimpezaPessoal', true, 150, 0, current_timestamp, current_timestamp, true),

    -- Cuidados Domésticos
    ('31', 'Vassoura', '1 unidade', 'Vassoura de pelo sintético', 18.00, 'CuidadosDomesticos', true, 60, 0, current_timestamp, current_timestamp, true),
    ('32', 'Rodo', '1 unidade', 'Rodo de alumínio com borracha', 15.00, 'CuidadosDomesticos', true, 70, 0, current_timestamp, current_timestamp, true),
    ('33', 'Pano de Limpeza', '5 unidades', 'Panos de limpeza multiuso', 6.00, 'CuidadosDomesticos', true, 120, 0, current_timestamp, current_timestamp, true),
    ('34', 'Esponja de Aço', '1 unidade', 'Esponja de aço para limpeza', 3.50, 'CuidadosDomesticos', true, 200, 0, current_timestamp, current_timestamp, true),
    ('35', 'Inseticida', '300ml', 'Inseticida spray', 12.00, 'CuidadosDomesticos', true, 80, 0, current_timestamp, current_timestamp, true),

    -- Bebidas
    ('36', 'Água Mineral', '1.5L', 'Água mineral sem gás', 2.50, 'Bebida', true, 200, 0, current_timestamp, current_timestamp, true),
    ('37', 'Refrigerante', '2L', 'Refrigerante de cola', 7.00, 'Bebida', true, 120, 10, current_timestamp, current_timestamp, true),
    ('38', 'Suco de Laranja', '1L', 'Suco de laranja integral concentrado', 6.00, 'Bebida', true, 80, 5, current_timestamp, current_timestamp, true),
    ('39', 'Cerveja', '350ml', 'Cerveja pilsen', 3.00, 'Bebida', true, 150, 0, current_timestamp, current_timestamp, true),
    ('40', 'Vinho', '750ml', 'Vinho tinto seco', 25.00, 'Bebida', true, 50, 0, current_timestamp, current_timestamp, true);

    -- Padaria
    ('41', 'Pão Francês', '50g', 'Pão francês fresco', 0.50, 'Padaria', true, 500, 0, current_timestamp, current_timestamp, true),
    ('42', 'Pão de Forma', '500g', 'Pão de forma integral', 5.00, 'Padaria', true, 60, 10, current_timestamp, current_timestamp, true),
    ('43', 'Bolo de Chocolate', '1kg', 'Bolo de chocolate com cobertura', 20.00, 'Padaria', true, 20, 0, current_timestamp, current_timestamp, true),
    ('44', 'Croissant', '100g', 'Croissant de manteiga', 3.00, 'Padaria', true, 100, 0, current_timestamp, current_timestamp, true),
    ('45', 'Biscoito', '200g', 'Biscoito amanteigado', 6.00, 'Padaria', true, 80, 5, current_timestamp, current_timestamp, true);

    -- Rações
    ('46', 'Ração para Cães', '3kg', 'Ração premium para cães adultos', 45.00, 'Rações', true, 40, 0, current_timestamp, current_timestamp, true),
    ('47', 'Ração para Gatos Filhotes', '2kg', 'Ração premium para gatos filhotes', 35.00, 'Rações', true, 50, 0, current_timestamp, current_timestamp, true),
    ('48', 'Ração para Pássaros', '1kg', 'Ração para pássaros caiçara', 15.00, 'Rações', true, 70, 5, current_timestamp, current_timestamp, true),
    ('49', 'Ração para Peixes', '500g', 'Ração em flocos para peixes ornamentais', 10.00, 'Rações', true, 60, 10, current_timestamp, current_timestamp, true),
    ('50', 'Ração para Gatos Castrados', '1kg', 'Ração balanceada para gatos adultos e castrados', 20.00, 'Rações', true, 30, 0, current_timestamp, current_timestamp, true);