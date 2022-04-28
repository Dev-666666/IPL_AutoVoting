create table userlist
(uid int primary key identity,uname varchar(20),pass varchar(20),fullname varchar(20));
select * from userlist;

alter table userlist drop column uid;
alter table userlist add uid int primary key identity;
drop table userlist;

alter table userlist add roll_id int foreign key references User_Roll(roll_id);

create table User_Roll(roll_id int primary key identity,roll_name varchar(30));
select * from User_Roll;
insert into User_Roll (roll_name) values('Admin'),('User');

