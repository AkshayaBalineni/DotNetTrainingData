--VERSION 1.0
--DATE 4th JUN 2022
--@DEV 67562

/*
SELECT * FROM dbo.orderitem where orderId=2;
EXEC sp_orderItem 2,2,1
EXEC sp_orderItem 2,0,1
EXEC sp_orderItem 1000,0,1
EXEC sp_orderItem 2,0,1200
*/

IF EXISTS(
	SELECT 1 FROM sys.objects WHERE type = 'p' AND OBJECT_ID =OBJECT_ID('[dbo].[sp_orderItem]')
	)
	BEGIN
		DROP PROC [dbo].[sp_orderItem]
	END
GO
CREATE PROC [dbo].[sp_orderItem]
	@orderId INT,
	@Qty INT,
	@pId INT
AS
BEGIN
    DECLARE @totalAmount FLOAT
 IF NOT EXISTS( SELECT 1 FROM dbo.orderd AS o WITH(NOLOCK) WHERE o.orderid=@orderId)
	BEGIN
		THROW 60002,'no such order exist',18
	END
IF NOT EXISTS( SELECT 1 FROM dbo.product AS p WITH(NOLOCK) WHERE p.pid=@pId)
	BEGIN
		THROW 60003,'no such product exist',18
	END
IF @Qty = 0 
	BEGIN
		THROW 60004,'Invalid Qty',18
	END
	SET @totalAmount = [dbo].[fn_GetAmount1](@pId,@Qty)
	INSERT INTO dbo.orderitem 
	(
	 orderid,qty,amount,pid
	)
	values
	(
	@orderId,@Qty,@totalAmount,@pId
	)
END
