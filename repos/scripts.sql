CREATE DATABASE db_TicketLogging
use db_TicketLogging;

CREATE TABLE Employee
(
EId NVARCHAR(10) primary key Not NUll,
Employee_name NVARCHAR(30) null,
Hire_Date Date null,
Dept VARCHAR(30) null
);

Create table Ticket(
TicketId int primary key,
LoggedBy NVARCHAR(10) null,
RaisedDate Date null,
Severity Varchar(30) null,
TicketDescription Nvarchar(40) null,
ResolvedBy NVarchar(40) null,
Resolution NVarchar(40) null,
ResolvedDate Date null,
TicketStatus Nvarchar(10) null
);

Alter table ticket ADD  CONSTRAINT EmpId_fk foreign key (LoggedBy) references employee(Eid)

insert into employee values('E100100','venkat','2004-1-10','MGM')
insert into employee values('E100101','krishna','2004-1-10','MGM')
insert into employee values('E100102','ChandraShekar','2005-3-11','DEV')
insert into employee values('E100104','Saheer ali khan','2008-10-13','DEV')
insert into employee values('E100105','Shashikanth','2007-2-17','DEV')
insert into employee values('M100103','Avinash','2007-3-10','DEVOPS')
insert into employee values('M100105','Ashok','2008-3-18','DEVOPS')


insert into Ticket values('1','E100101','2012-10-3','Major','Appserver not working','M100103','Need to restart with LAN cable','2012-10-4','closed')
insert into Ticket values('2','E100104','2013-7-10','Critical','Laptop restart problem',null,null,'2013-7-11','Open')
delete from ticket where TicketId = 12;
select * from ticket
