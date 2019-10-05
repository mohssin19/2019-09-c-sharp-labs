use master 
go
drop database if exists OrangeDB
go
create database OrangeDB
go
use OrangeDB

create table Categories(
CategoryId INT NOT NULL IDENTITY PRIMARY KEY,
CategoryName NVARCHAR(50) NULL
)
create table Oranges(
OrangeId int not null IDENTITY PRIMARY KEY,
OrangeName NVARCHAR(50) NULL, 
DateHarvested Date NULL,
IsLuxuryGrade Bit NULL,
OrangeCategoryId int null FOREIGN KEY REFERENCES Categories(CategoryId)

)

create table Batch(
BatchId int NOT NULL IDENTITY PRIMARY KEY,
OrangeId int NULL FOREIGN KEY REFERENCES Oranges(OrangeId),
Quantity int NULL,
DespatchDate Date NULL
)

insert into Categories values('clementines');
insert into Categories values('red');
insert into Categories values('easy peelers');

insert into Oranges values('Clementine','2019-09-07',0,2);
insert into Oranges values('Blood Orange','2019-09-07',1,1);
insert into Oranges values('Tangerine','2019-09-07','false',3);
insert into Oranges values ('Clementine','2018-12-25',0,1)

insert into Batch values (1,100,GETDATE())
insert into Batch values (2,100,GETDATE())
insert into Batch values (3,100,GETDATE())
insert into Batch values (4,50,'2019-08-01')


select * from Oranges;
select * from Categories;

select * from Oranges
inner join Categories
ON Oranges.OrangeCategoryId = categories.CategoryId

select orangeid, orangename, categoryname, dateharvested, DATEADD(d,90,dateharvested) as 'expirydate' from oranges
inner join Categories
ON Oranges.OrangeCategoryId = categories.CategoryId

select *, (DATEDIFF(d, dateharvested, GETDATE())) AS 'SinceHarvested',
CASE
WHEN (DATEDIFF(d, dateharvested, GETDATE())) > 90 THEN 'yes'
ELSE 'no'
END 
AS 'IsExpired'
from Batch
inner join oranges on oranges.OrangeId= batch.orangeId


update Categories set CategoryName='red' where CategoryId=2
select * from Categories

insert into Oranges values ('Dummy','2019-09-07',0,2)
select * from Oranges
delete from Oranges  where OrangeId = 5
select * from Oranges