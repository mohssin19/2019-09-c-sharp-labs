--drop database if exists RabbitDb
--go

--create database RabbitDb 
--go

--Select 'Here is a comment'

--use RabbitDb
--go

--CREATE TABLE Rabbits(
--	RabbitID INT NOT NULL IDENTITY PRIMARY KEY,
--	Age INT NULL,
--	Name NVARCHAR(50) NULL
--	);

	--select 'Here is a comment'

	INSERT INTO Rabbits (Age) VALUES (1);
	UPDATE Rabbits SET Name = 'Jeff' WHERE RabbitID = 1; --updates records

	INSERT INTO Rabbits (Name) values ('Jimbo');

	delete from rabbits where RabbitID >1;

	update Rabbits SET Age = '12' WHERE RabbitID =1;

	INSERT INTO Rabbits (Age, Name) VALUES (10, 'Jimbo')

	SELECT * FROM Rabbits

	