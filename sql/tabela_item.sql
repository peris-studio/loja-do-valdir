create type TipoItem as enum ('AlimentosBasicos', 'FrutasVegetais', 'Carnes', 'Laticinios', 'LimpezaDomestica', 'LimpezaPessoal', 'CuidadosDomesticos', 'Bebidas', 'Padaria', 'Racoes');

create table public.Item (
	id uuid primary key,
	Nome varchar(50) not null,
	Peso varchar(10) not null,
	Descricao text not null,
	Preco double not null,
	TipoItem TipoItem not null,
	ItemEmEstoque boolean not null,
	QuantidadeUnidade integer not null,
	QuantidadeFardo integer not null,
	DataCriacao timestamp not null default current_timestamp,
	DataAtualizacao timestamp,
	DataDelecao timestamp,
	Ativo boolean not null
);

-- Inserção de dados de exemplo para a tabela Item
INSERT INTO public.Item (Id, Nome, Peso, Descricao, Preco, TipoItem, ItemEmEstoque, QuantidadeUnidade, QuantidadeFardo, DataCriacao, DataAtualizacao, Ativo)
VALUES

    -- Alimentos Básicos
    ('1', 'Arroz', '1kg', 'Arroz tipo parboilizado', 10.00, 'AlimentosBasicos', true, 100, 0, current_timestamp, current_timestamp, true),
    ('2', 'Feijão', '1kg', 'Feijão carioca', 8.00, 'AlimentosBasicos', true, 80, 0, current_timestamp, current_timestamp, true),
    ('3', 'Sal', '500g', 'Sal refinado', 5.00, 'AlimentosBasicos', true, 150, 0, current_timestamp, current_timestamp, true),
    ('4', 'Azeite', '500ml', 'Azeite de oliva extra virgem', 20.00, 'AlimentosBasicos', true, 50, 0, current_timestamp, current_timestamp, true),
    ('5', 'Farinha de Trigo', '1kg', 'Farinha de trigo tipo 1', 6.00, 'AlimentosBasicos', true, 90, 0, current_timestamp, current_timestamp, true),

    -- Frutas e Vegetais
    ('6', 'Maçã', '0.2 kg', 'Maçã Fuji', 2.50, 'FrutasVegetais', true, 200, 0, current_timestamp, current_timestamp, true),
    ('7', 'Alface', '0.3 kg', 'Alface crespa', 3.00, 'FrutasVegetais', true, 120, 0, current_timestamp, current_timestamp, true),
    ('8', 'Tomate', '0.25 kg', 'Tomate italiano', 4.00, 'FrutasVegetais', true, 150, 0, current_timestamp, current_timestamp, true),
    ('9', 'Banana', '0.15 kg', 'Banana nanica', 1.80, 'FrutasVegetais', true, 250, 0, current_timestamp, current_timestamp, true),
    ('10', 'Cenoura', '0.2 kg', 'Cenoura orgânica', 2.50, 'FrutasVegetais', true, 180, 0, current_timestamp, current_timestamp, true),

    -- Carnes
    ('11', 'Carne Bovina', '1 kg', 'Carne bovina para churrasco', 30.00, 'Carnes', true, 50, 0, current_timestamp, current_timestamp, true),
    ('12', 'Frango', '1 kg', 'Peito de frango sem osso', 15.00, 'Carnes', true, 70, 0, current_timestamp, current_timestamp, true),
    ('13', 'Peixe', '0.5 kg', 'Filé de peixe tilápia', 25.00, 'Carnes', true, 30, 0, current_timestamp, current_timestamp, true),
    ('14', 'Linguiça', '0.3 kg', 'Linguiça calabresa defumada', 12.00, 'Carnes', true, 90, 0, current_timestamp, current_timestamp, true),
    ('15', 'Cordeiro', '0.8 kg', 'Costeletas de cordeiro', 40.00, 'Carnes', true, 20, 0, current_timestamp, current_timestamp, true),

    -- Laticínios
    ('16', 'Leite', '1 L', 'Leite integral', 5.00, 'Laticinios', true, 200, 0, current_timestamp, current_timestamp, true),
    ('17', 'Queijo', '0.3 kg', 'Queijo minas frescal', 12.00, 'Laticinios', true, 60, 0, current_timestamp, current_timestamp, true),
    ('18', 'Iogurte', '200 g', 'Iogurte natural desnatado', 3.50, 'Laticinios', true, 120, 0, current_timestamp, current_timestamp, true),
    ('19', 'Manteiga', '200 g', 'Manteiga sem sal', 8.00, 'Laticinios', true, 80, 0, current_timestamp, current_timestamp, true),
    ('20', 'Creme de Leite', '200 g', 'Creme de leite fresco', 6.00, 'Laticinios', true, 100, 0, current_timestamp, current_timestamp, true),

    -- Limpeza Doméstica
    ('21', 'Detergente', '500 ml', 'Detergente neutro', 4.00, 'LimpezaDomestica', true, 150, 0, current_timestamp, current_timestamp, true),
    ('22', 'Desinfetante', '1 L', 'Desinfetante floral', 8.00, 'LimpezaDomestica', true, 80, 0, current_timestamp, current_timestamp, true),
    ('23', 'Sabão em Pó', '1 kg', 'Sabão em pó para roupas', 10.00, 'LimpezaDomestica', true, 90, 0, current_timestamp, current_timestamp, true),
    ('24', 'Esponja', '50 g', 'Esponja de limpeza multiuso', 2.50, 'LimpezaDomestica', true, 200, 0, current_timestamp, current_timestamp, true),
    ('25', 'Água Sanitária', '1 L', 'Água sanitária concentrada', 6.00, 'LimpezaDomestica', true, 120, 0, current_timestamp, current_timestamp, true),

    -- Limpeza Pessoal
    ('26', 'Shampoo', '300 ml', 'Shampoo para cabelos normais', 15.00, 'LimpezaPessoal', true, 100, 0, current_timestamp, current_timestamp, true),
    ('27', 'Condicionador', '300 ml', 'Condicionador hidratante', 12.00, 'LimpezaPessoal', true, 120, 0, current_timestamp, current_timestamp, true),
    ('28', 'Sabonete', '90 g', 'Sabonete líquido suave', 3.50, 'LimpezaPessoal', true, 200, 0, current_timestamp, current_timestamp, true),
    ('29', 'Creme Dental', '90 g', 'Creme dental com flúor', 4.00, 'LimpezaPessoal', true, 180, 0, current_timestamp, current_timestamp, true),
    ('30', 'Desodorante', '150 ml', 'Desodorante aerosol', 10.00, 'LimpezaPessoal', true, 150, 0, current_timestamp, current_timestamp, true),

    -- Cuidados Domésticos
    ('31', 'Vassoura', '1 unidade', 'Vassoura de pelo sintético', 18.00, 'CuidadosDomesticos', true, 60, 0, current_timestamp, current_timestamp, true),
    ('32', 'Rodo', '1 unidade', 'Rodo de alumínio com borracha', 15.00, 'CuidadosDomesticos', true, 70, 0, current_timestamp, current_timestamp, true),
    ('33', 'Pano de Limpeza', '5 unidades', 'Panos de limpeza multiuso', 6.00, 'CuidadosDomesticos', true, 120, 0, current_timestamp, current_timestamp, true),
    ('34', 'Esponja de Aço', '1 unidade', 'Esponja de aço para limpeza', 3.50, 'CuidadosDomesticos', true, 200, 0, current_timestamp, current_timestamp, true),
    ('35', 'Inseticida', '300 ml', 'Inseticida spray', 12.00, 'CuidadosDomesticos', true, 80, 0, current_timestamp, current_timestamp, true),

    -- Bebidas
    ('36', 'Água Mineral', '500 ml', 'Água mineral sem gás', 1.50, 'Bebidas', true, 300, 0, current_timestamp, current_timestamp, true),
    ('37', 'Refrigerante', '2 L', 'Refrigerante sabor cola', 5.00, 'B
