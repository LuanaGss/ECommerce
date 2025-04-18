-- DML - Inserir, alterar ou apagar dados
-- Linguagem de Manipulacao de Dados

-- DDL, DML e DQL

-- INSERT INTO - Inserir dados
USE ECommerce

INSERT INTO Produto (Nome, Descricao, Preco, EstoqueDisponivel, Categoria, Imagem)
VALUES
('Mouse', 'Mouse Logitech', 99.90, 50, 'Informática', ''),
('Teclado', 'Teclado Dell', 209.50, 100, 'Informática', '')

INSERT INTO Cliente (NomeCompleto, Email, Telefone, Endereco, DataCadastro, Senha)
VALUES
('Vinicio Santos', 'vinicio@senai.br', '(11) 999994444', 'Rua Niterói, 180 - São Paulo/SP', '05/04/2022', '123456'),
('Saulo Santos', 'saulo@senai.br', '(11) 2222333444', 'Rua Niterói, 250 - São Paulo/SP', '05/06/2022', '123456')

INSERT INTO Pedido (IdCliente, DataPedido, Status, ValorTotal)
VALUES
(1, '06/05/2023', 'Processando', 3200.99),
(2, '10/05/2023', 'Concluído', 450.90)

INSERT INTO Pagamento (IdPedido, FormaPagamento, Status, Data)
VALUES
(2, 'Cartão de Crédito', 'Aprovado', '08/05/2023 12:30:00'),
(3, 'Boleto', 'Aprovado', '18/05/2023 16:30:00')

INSERT INTO ItemPedido(IdPedido, IdProduto, Quantidade)
VALUES
(1, 1, 2),
(1, 2, 1),
(2, 1, 1)