CREATE DATABASE db_test;
--drop database db_test;
GO
USE db_test;
GO
CREATE TABLE customer(
customerId INT NOT NULL PRIMARY KEY,
customerName NVARCHAR(30));
GO
CREATE TABLE balance(
customerId INT ,
amount FLOAT);
GO
CREATE TABLE customerTransaction
(customer_TId int,
withdraw char(1),
deposit char(1),
transDate date,
Amount float);
alter table customertransaction add constraint f_key foreign key(customer_TId) references customer(customerId);
GO
INSERT INTO dbo.customer (customerId,customerName) VALUES(101,'Akshaya');
GO
CREATE TRIGGER t_InsertCustomer ON customer
FOR INSERT
AS
BEGIN 
	DECLARE
		@CustId INT;
	SELECT @CustId = customerId FROM inserted AS c
	WHERE
		customerId = c.customerId;
	INSERT INTO balance(customerId,amount)
	VALUES
	(
		@CustId,0
	)
END
GO
select * from customer;
SELECT * FROM balance;
SELECT * FROM customerTransaction;
GO

create trigger t_UpdateBalance on customerTransaction
for insert
as 
begin
	declare
		@balance float,
		@customerid int,
		@Wd char(1),
		@dp char(1),
		@amount float
		select @customerid=customer_TId,@amount=Amount,@Wd=withdraw,@dp=deposit from inserted i where customer_TId=i.customer_TId;
		select @balance=amount from balance AS bt where bt.customerId=@customerid;
		if(@Wd='y'and @dp='y')
		begin
			THROW 60007,'Deposit and Withdraw can be done at same time',18
			rollback transaction;
			return;
		end
		else if(@wd like 'y')
		begin
			if(@balance-@amount>=1000)
			begin
			update balance set balance.amount=(@balance-@amount) where balance.customerId=@customerid;
			end
			else
				begin
					THROW 60008,'Insufficient Balance',18;
					rollback transaction;
				end
		end
		else if(@dp like 'y')
		begin
			update balance set  balance.amount=(@balance+@amount) where  balance.customerId=@customerid; 
		end
 end
 GO

 insert into customerTransaction(Amount,customer_TId,transDate,deposit,withdraw) values(2000,101,'07-07-2022','y','n');
  insert into customerTransaction(Amount,customer_TId,transDate,deposit,withdraw) values(800,101,'07-07-2022','n','y');
