USE facebook;
INSERT INTO Usuarios VALUES
(NEWID(), 'Juninho', 'lauro.juniorspx@gmail.com', '123456', GETDATE());

USE facebook;
INSERT INTO Postagens VALUES
(NEWID(), 'Texto 19', GETDATE());

USE facebook;
INSERT INTO Comentarios VALUES
(NEWID(), 'At� aqui 50 digitoooooooooooooooooooooooooooooooos At� aqui 100 digitoooooooooooooooooooooooooooooos At� aqui 150 digitoooooooooooooooooooooooooooooos', '35B46D56-19E2-4AB4-B550-43853A132256', GETDATE());

UPDATE Comentarios 
SET Texto = 'At� aqui 50 digitoooooooooooooooooooooooooooooooosAt� aqui 100 digitooooooooooooooooooooooooooooooosAt� aqui 150 digitooooooooooooooooooooooooooooooos' 
WHERE Id = '41691355-9943-45EE-9EFA-14540B29FF1A';

USE facebook;
SELECT * FROM Usuarios;
SELECT * FROM Postagens ORDER BY DataCriacao;
SELECT * FROM Comentarios ORDER BY DataCriacao;