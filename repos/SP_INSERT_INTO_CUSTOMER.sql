--VERSION 1.0
--DATE 4th JUN 2022
--@DEV 67562

/*
select * from category
select * from customer
EXEC sp_CustomerProfile 1001
EXEC sp_InsertInToCustomer 15,'Akshaya','9154298746','akshaya@gmail.com',pass@999;
EXEC sp_InsertInToCustomer 16,'AkshayaBalineni','9154298746','akshaya@gmail.com',pass@999;
*/

IF EXISTS(
	SELECT 1 FROM sys.objects WHERE type = 'p' AND OBJECT_ID =OBJECT_ID('[dbo].[sp_InsertInToCustomer]')
	)
	BEGIN
		DROP PROC [dbo].[sp_InsertInToCustomer]
	END
GO
CREATE PROC [dbo].[sp_InsertInToCustomer]
	@customerId INT,
	@customerName NVARCHAR(30),
	@mobileNum VARCHAR(30),
	@emaild NVARCHAR(50),
	@password NVARCHAR(20)
AS
BEGIN
	IF EXISTS(SELECT 1 FROM dbo.customer AS c WITH(NOLOCK) where c.customerid = @customerId)
	BEGIN 
		THROW 60005,'Customer Already Exists',18
	END
	IF EXISTS
	(
	SELECT 1  from dbo.customer AS c WITH(NOLOCK) where c.emailid = @emaild
	)
	BEGIN
	   THROW 60006, 'Email Already Exists',18
	END
	INSERT INTO dbo.customer
	(
		customerid,customername,mobileno,emailid,[password]
	)
	VALUES
	( 
		@customerId,@customerName,@mobileNum,@emaild,@password
	)
END