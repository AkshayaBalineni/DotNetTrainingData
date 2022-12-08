--VERSION 1.0
--DATE 4th JUN 2022
--@DEV 67562

/*
SELECT * FROM dbo.orderitem
*/

IF EXISTS(
	SELECT 1 FROM sys.objects WHERE type = 'F' AND OBJECT_ID = OBJECT_ID('[dbo].[fn_GetAmount1]')
	)
BEGIN
	DROP FUNCTION [dbo].[fn_GetAmount1]
END
GO 
CREATE FUNCTION [dbo].[fn_GetAmount1]
(
	@pId INT,
	@Qty INT
)
RETURNS FLOAT
AS
BEGIN
	DECLARE @price FLOAT,@total FLOAT
	SELECT @price = price FROM dbo.product as p WITH(NOLOCK)
			WHERE p.pid = @pId
	SET @total = @price * @Qty
	RETURN @total
END

----------
--select * from dbo.fn_GetAmount1(1,2)