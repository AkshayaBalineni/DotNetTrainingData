--VERSION 1.0
--DATE 4th JUN 2022
--@DEV 67562

/*
select * from orderd
select * from orderd where orderid=2
EXEC sp_orderdetails 2
*/

IF EXISTS(
	SELECT 1 FROM sys.objects WHERE type = 'p' AND OBJECT_ID =OBJECT_ID('[dbo].[sp_orderdetails]')
	)
	BEGIN
		DROP PROC [dbo].[sp_orderdetails]
	END
GO
CREATE PROC [dbo].[sp_orderdetails]
	@orderId INT
AS
BEGIN
IF NOT EXISTS(SELECT 1 FROM dbo.orderd AS o WITH(NOLOCK) where o.orderid=@orderId)
	BEGIN 
		THROW 60002,'no such order exists',18
	END
SELECT * FROM dbo.orderd AS o WITH(NOLOCK)
WHERE o.orderid=@orderId ;
END