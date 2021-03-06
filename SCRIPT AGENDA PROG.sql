CREATE DATABASE AGENDA
GO
USE AGENDA
GO
CREATE TABLE [dbo].[Contacto](
	[NOMBRE COMPLETO] [nvarchar] (30) NOT NULL,
	[TELEFONO] [int] NULL,
	[TELEFONO TRABAJO] [int] NULL,
	[CORREO ELECTRONICO] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar] (50) NOT NULL,
	)

CREATE PROC [dbo].[BUSCARCONTACTOS]
@NOMBRE NVARCHAR(30),
@TELEFONO NVARCHAR(10),
@TELEFONO_TRABAJO NVARCHAR(10),
@CORREOELECTRONICO nvarchar(256),
@Direccion nvarchar(50)
AS 
SELECT * FROM Contacto
WHERE [NOMBRE COMPLETO] = @NOMBRE;
GO

CREATE PROC [dbo].[EDITARCONTACTOS]
@NOMBRE NVARCHAR(30),
@TELEFONO NVARCHAR(10),
@TELEFONOTRABAJO VARCHAR(10),
@CORREOELECTRONICO NVARCHAR(256),
@DIRECCION NVARCHAR(50)
AS
UPDATE Contacto SET [NOMBRE COMPLETO] = @NOMBRE, TELEFONO=@TELEFONO,
[TELEFONO TRABAJO] = @TELEFONOTRABAJO,[CORREO ELECTRONICO] = @CORREOELECTRONICO,
Direccion = @DIRECCION
WHERE [NOMBRE COMPLETO] = @NOMBRE
GO

CREATE  PROC [dbo].[ELIMINARCONTACTOS]
@NOMBRE NVARCHAR(30),
@TELEFONO NVARCHAR(10),
@TELEFONOTRABAJO NVARCHAR(10),
@CORREOELECTRONICO NVARCHAR(256),
@DIRECCION NVARCHAR(50)
AS
DELETE Contacto
WHERE [NOMBRE COMPLETO] = @NOMBRE
go

CREATE PROC [dbo].[INSERTARCONTACTOS]
@NOMBRE NVARCHAR(30),
@TELEFONO nvarchar(10),
@TELEFONO_TRABAJO nvarchar(10),
@CORREOELECTRONICO nvarchar(256),
@DIRECCION NVARCHAR(50)
AS
INSERT INTO Contacto VALUES (@NOMBRE,@TELEFONO,@TELEFONO_TRABAJO,@CORREOELECTRONICO,@DIRECCION)
GO

INSERT INTO Contacto([NOMBRE COMPLETO],[TELEFONO],[TELEFONO TRABAJO], [CORREO ELECTRONICO], [DIRECCION]) 
VALUES('JUAN CARLOS MEDRANO','809-567-3057','809-683-1919','JUAN_CARLOS@HOTMAIL.COM','DR DEFILLO CON 27');

