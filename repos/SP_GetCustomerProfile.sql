--VERSION 1.0
--DATE 4th JUN 2022
--@DEV 67562

/*
EXEC sp_CustomerProfile 1001
EXEC sp_CustomerProfile 1
*/

IF EXISTS(
	SELECT 1 FROM sys.objects WHERE type = 'p' AND OBJECT_ID =OBJECT_ID('[dbo].[sp_CustomerProfile]')
	)
	BEGIN
		DROP PROC [dbo].[sp_CustomerProfile]
	END
GO
CREATE PROC [dbo].[sp_CustomerProfile]
	@customerId INT
AS
BEGIN
IF NOT EXISTS(SELECT 1 FROM dbo.customer AS c WITH(NOLOCK) where c.customerid = @customerId)
	BEGIN 
		THROW 60001,'no such Customer exists',18
	END
SELECT * FROM dbo.customer AS c WITH(NOLOCK)
WHERE c.customerid = @customerId 
END