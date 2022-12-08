--VERSION 1.0
--DATE 4th JUN 2022
--@DEV 67562
/*
DECLARE 
	@orderId INT
EXEC sp_InsertOrder '5918e2af-56b2-4766-9183-21f5e7329eac','2022-07-04',null,25000,@orderId OUT;
PRINT @orderId
SELECT * FROM dbo.orderd
*/
IF EXISTS(
	SELECT 1 FROM sys.objects WHERE type = 'p' AND OBJECT_ID =OBJECT_ID('[dbo].[sp_InsertOrder]')
	)
	BEGIN
		DROP PROC [dbo].[sp_InsertOrder]
	END
GO
CREATE PROC [dbo].[sp_InsertOrder]
 @aspCustomerID NVARCHAR(450) = null,
 @orderDate DATETIME,
 @customerId INT = null,
 @totalAmount FLOAT,
 @orderId INT OUT
AS
BEGIN
 DECLARE @orderStatus NVARCHAR(20) ='NEW'
	IF NOT EXISTS(
	SELECT 1 FROM dbo.customer AS c WITH(NOLOCK)
		WHERE c.customerid = @customerId  
	) AND 
	NOT EXISTS(SELECT 1 FROM dbo.AspNetUsers AS ac WITH(NOLOCK)
		WHERE ac.Id = @aspCustomerID )
	BEGIN
		THROW 60001 ,'No Such Customer Exists',18
	END
	INSERT INTO dbo.orderd
	(
		orderdate,
		customerid,
		orderstatus,
		totalAmount,
		aspCustomerId
	)
	VALUES
	(
	@orderDate,
	@customerId,
	@orderStatus,
	@totalAmount,
	@aspCustomerID
	)
	SET @orderId = @@IDENTITY
END
GO

