create table userlist
(uid int primary key identity,uname varchar(20),pass varchar(20),fullname varchar(20));
select * from userlist;

alter table userlist drop column uid;
alter table userlist add uid int primary key identity;
drop table userlist;
