USE ECommerce

INSERT INTO Produto(NomeProduto, Descricao, Preco, EstoqueDisponível, CategoriaProduto, Imagem)
VALUES
('Mouse', 'Mouse Logitech', 99.90, 50, 'Informatica', ''),
('Teclado', 'Teclado Dell', 209.50, 100, 'Informatca', '')

DELETE FROM Pagamento WHERE IdPagamento = 2;

SELECT * FROM Cliente;