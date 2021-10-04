
USE InLock
GO


INSERT INTO Estudio(nomeEstudio)
VALUES ('EA Games'),('Ubisoft'),('Nintendo');
GO

INSERT INTO TipoUsuario(Titulo)
VALUES ('Administrador'),('Comum');
GO


INSERT INTO Jogo(idEstudio,nomeJogo,DataLan,Valor,Descricao)
VALUES (1,'FIFA 20','24/07/2019','139','jogo de futebol.'),
	   (2,'Assassins Creed: Orings','27/10/2017','109','mais um jogo da saga assassins creed.');
GO

INSERT INTO Usuario(idTipoUser, Email, Senha)
VALUES (1,'admin@gmail.com','admin'),
	   (2,'cliente@gmail.com','cliente');
GO



