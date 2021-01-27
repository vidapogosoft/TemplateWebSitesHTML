----crea la base de datos

--CREATE DATABASE Inventario

----coloca la BD TURISMO en memoria para poder hacer modificaciones

--USE Inventario

--USE [Inventario]
--GO

--INSERT INTO [dbo].[Pruebas]([Nombre],[Apellido],[Domicilio],[Fecha_Nacimiento])
--     VALUES('Diego','Tierra','Fertiza',GETDATE())
--	 INSERT INTO [dbo].[Pruebas]([Nombre],[Apellido],[Domicilio],[Fecha_Nacimiento])
--     VALUES('Fernando','Tierra','Guasmo Oeste',GETDATE())
--GO

--select *from [dbo].[Pruebas]



--CREATE TABLE Productos (
--Id INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--Descripcion VARCHAR(100) NOT NULL,
--Categoria VARCHAR(100) NOT NULL,
--Proveedor VARCHAR(100) NOT NULL,
--Marca VARCHAR(100) NOT NULL,
--Modelo VARCHAR(40) NOT NULL,
--Cantidad int NOT NULL,
--PrecioUnitario decimal not null,
--fechaRegistro DATETIME not null

--);



--INSERT INTO [dbo].[Productos]([Descripcion],[Categoria],[Proveedor],[Marca],[Modelo],[Cantidad], [PrecioUnitario], [fechaRegistro])
--     VALUES
--           ('Galletas Oreos','Galletas','Arca','Arca','Galletas',5, 1.00, getdate())

		   
--INSERT INTO [dbo].[Productos]([Descripcion],[Categoria],[Proveedor],[Marca],[Modelo],[Cantidad], [PrecioUnitario], [fechaRegistro])
--     VALUES
--           ('Galletas Ricas','Galletas','Arca','Arca','Galletas',15, 3.00, getdate())
--GO



--CREATE TABLE HistorialProductos (
--Id_ INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--id int NOT NULL,
--Descripcion VARCHAR(100) NOT NULL,
--Categoria VARCHAR(100) NOT NULL,
--Proveedor VARCHAR(100) NOT NULL,
--Marca VARCHAR(100) NOT NULL,
--Modelo VARCHAR(40) NOT NULL,
--Cantidad int NOT NULL,
--PrecioUnitario decimal not null,
--fechaRegistro DATETIME not null,
--actividad VARCHAR(50) NOT NULL
--);
