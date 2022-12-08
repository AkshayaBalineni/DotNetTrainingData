--VERSION 1.0
--DATE 4th JUN 2022
--@DEV 67562

IF EXISTS(
	SELECT 1 FROM sys.objects WHERE type = 'p' AND OBJECT_ID =OBJECT_ID('[dbo].[sp_InsertOrder]')
	)
	BEGIN
		DROP PROC [dbo].[sp_InsertOrder]
	END
GO
CREATE PROC [dbo].[sp_InsertOrder]
 @orderDate DATETIME,
 @customerId INT,
 @totalAmount FLOAT,
 @orderId INT OUT
AS
BEGIN
 DECLARE @orderStatus NVARCHAR(20) ='NEW'
	IF NOT EXISTS(
	SELECT 1 FROM dbo.customer AS c WITH(NOLOCK)
		WHERE c.customerid = @customerId
	)
	BEGIN
		THROW 60001 ,'No Such Customer Exists',18
	END
	INSERT INTO dbo.orderd
	(
		orderdate,
		customerid,
		orderstatus,
		totalAmount
	)
	VALUES
	(
	@orderDate,
	@customerId,
	@orderStatus,
	@totalAmount
	)
	SET @orderId = @@IDENTITY
END