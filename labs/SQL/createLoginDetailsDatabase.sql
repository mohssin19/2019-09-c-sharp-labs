use master 
go
drop database if exists loginDb
go
create database loginDb 
go
use loginDb

create table loginDetails(
LoginId int not null IDENTITY PRIMARY KEY,
UserName NVARCHAR(50) NULL,
Password NVARCHAR(50) NULL,
)

create table statusDetails(
StatusId int not null IDENTITY PRIMARY KEY,
StatusCode NVARCHAR(50) NULL,
startDate DATE NULL,
LoginId int null FOREIGN KEY REFERENCES loginDetails(LoginId)
)

create table SpecDetails(
SpecId int not null IDENTITY PRIMARY KEY,
Speciality NVARCHAR(50) NULL,
datenow DATE NULL,
StatusId int null  FOREIGN KEY REFERENCES statusDetails(StatusId)
)

insert into loginDetails values('user1','pass1');
insert into loginDetails values('user2','pass2');
insert into loginDetails values('user3','pass3');

insert into statusDetails values ('123','2018-10-10');
insert into statusDetails values ('456','2018-10-09');
insert into statusDetails values ('789','2019-10-08');

insert into SpecDetails values ('coder',GETDATE());
insert into SpecDetails values ('doctor',GETDATE());
insert into SpecDetails values ('fighter',GETDATE());

select * from loginDetails;
select * from statusDetails;
select * from SpecDetails;

select * from loginDetails
inner join statusDetails
ON loginDetails.LoginId = statusDetails.StatusId

select loginDetails.LoginId, loginDetails.UserName, statusDetails.startDate DATEADD(d,7,startDate

 