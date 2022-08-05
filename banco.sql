CREATE DATABASE  ProjetoEstoquev;
GO
use ProjetoEstoquev;
--DDL - DATA DEFINITION LANGUAGE
CREATE TABLE Nivel(
	codigo int PRIMARY KEY IDENTITY(1,1),
	nome varchar(80) not null
)

--DML - DATA MANIPULATION LANGUAGE
INSERT into Nivel(nome) VALUES ('Administrador');
INSERT into Nivel(nome) VALUES ('Usuario');

--DQL - DATA QUERY LANGUAGE

SELECT * FROM Nivel;
SELECT nome FROM Nivel order by codigo;

UPDATE Nivel SET nome='Desenvolvedor' WHERE codigo=2 ;

DELETE Nivel WHERE codigo=7;


-- Cria��o da tabela de usuario
CREATE TABLE Usuario(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(30) NOT NULL,
	sobreNome VARCHAR(80) NOT NULL,
	usuario VARCHAR(80) NOT NULL,
	senha VARCHAR (80) NOT NULL,
	codNivel INT NOT NULL ,
	FOREIGN KEY(codNivel)REFERENCES Nivel(codigo)
);

SELECT * FROM Usuario;

DROP TABLE Usuario;