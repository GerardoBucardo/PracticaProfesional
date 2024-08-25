CREATE DATABASE PracticaDB
USE PracticaDB

CREATE TABLE Users(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	UserName VARCHAR(100),
	UserPassword VARCHAR(50),
	RoleId INT
    CONSTRAINT FK_Role FOREIGN KEY (RoleId) REFERENCES Roles(Id)
)

CREATE TABLE Roles(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(100)
)

CREATE TABLE Contacts(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(50),
	LastName VARCHAR(50),
	Email VARCHAR(50)
)

CREATE TABLE Usuario_Producto(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	IdUsuario INT REFERENCES Users(Id),
	IdProducto INT REFERENCES Producto(Id),
)

CREATE TABLE Producto(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	PName VARCHAR(10)
)

DROP TABLE Users
DROP TABLE Usuario_Producto
DROP TABLE Roles
DROP TABLE Producto

INSERT INTO Users (UserName, UserPassword, RoleId) VALUES ('m','n',2);
INSERT INTO Producto (PName) VALUES ('n'),
('s');
INSERT INTO Usuario_Producto (IdUsuario,IdProducto) VALUES
(2,1);

INSERT INTO Roles (Name) VALUES ('Admin'),
('User')

SELECT * FROM Usuario_Producto
SELECT * FROM Users
SELECT * FROM Roles

SELECT *, Producto.PName  FROM Usuario_Producto 
JOIN Producto ON Producto.Id = Usuario_Producto.IdProducto
WHERE IdUsuario = 1 