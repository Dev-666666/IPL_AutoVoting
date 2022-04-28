select * from Users;
select * from UserRoles;
create table Admins(adminId int primary key identity ,adminName varchar(30) not null,
adminPassword varchar(30) not null,RoleId int foreign key references UserRoles(RoleId));
select * from Admins;
create table Questionary(qId int primary key ,Question varchar(100));
select * from Questionary;

create table Options(optionId int primary key ,option1 varchar(50),option2 varchar(50),
option3 varchar(50),option4 varchar(50),qId int foreign key references Questionary(qId));
select * from Options;
create table Responces(Id int primary key identity,QId int foreign key references Questionary(qId)
,UId int references Users(UId));
select * from Responces;
drop table Responces;

