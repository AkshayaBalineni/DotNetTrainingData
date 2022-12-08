--VERSION 1.0
--DATE 4th JUN 2022
--@DEV 67562

/*
SELECT * FROM dbo.customer
EXEC sp_GetCustomerOrderDetails 1
EXEC sp_GetCustomerOrderDetails 0
*/

IF EXISTS(
	SELECT 1 FROM sys.objects WHERE type = 'p' AND OBJECT_ID =OBJECT_ID('[dbo].[sp_GetCustomerOrderDetails]')
	)
	BEGIN
		DROP PROC [dbo].[sp_GetCustomerOrderDetails]
	END
GO
CREATE PROC [dbo].[sp_GetCustomerOrderDetails]
	@customerId INT
AS
BEGIN
IF NOT EXISTS(SELECT 1 FROM dbo.customer AS c WITH(NOLOCK) where c.customerid = @customerId)
	BEGIN 
		THROW 60001,'no such customer exists',18
	END
SELECT * FROM dbo.customer AS c INNER JOIN  dbo.orderd AS o 
ON c.customerid=o.customerid INNER JOIN dbo.orderitem AS oi ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p ON p.pid=oi.pid
WHERE c.customerid = @customerId AND p.isDeleted =0;
END