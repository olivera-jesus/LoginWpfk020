CREATE TABLE [dbo].[Usuarios]
(
	Id INT NOT NULL identity (1,1) PRIMARY KEY,
	Username  varchar (50) not null,
	password varchar (50) not null,
	Nombre_Completo varchar (200)

);
SELECT * FROM Usuarios;