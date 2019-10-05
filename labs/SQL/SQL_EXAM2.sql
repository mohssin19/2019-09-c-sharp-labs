use master 
go
drop database if exists SpartansDB
go
create database SpartansDB
go
use SpartansDB

create table Spartans (
SpartanId INT NOT NULL IDENTITY PRIMARY KEY,
Firstname NVARCHAR(50) NULL,
Surename NVARCHAR(50) NULL,
University NVARCHAR(50) NULL,
Course NVARCHAR(30) NULL,
Grade NVARCHAR(10) NULL,
)
insert into Spartans values('Tom','Hardy','Surrey','IT/AI','1st')
insert into Spartans values('Arthur','Shelby','Surrey','Economics','2:1')
insert into Spartans values('Frank','Martin','Queens Mary Uni','Public Services','1st')