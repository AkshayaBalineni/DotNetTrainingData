--1.Print HELLO
PRINT 'HELLO'
GO
SELECT 'HELLO' AS msg
--2.HELLO With NAME
BEGIN
	DECLARE
		@name NVARCHAR(20) = 'Akshaya';
	SET @name ='AKSHAYA BALINENI';
	PRINT 'HELLO ' + @name;
	SELECT 'HELLO ' + @name AS MSG
END
--3. PRINT PRODUCT_ID AND NAME
DECLARE
	@pId INT =1,
	@pName NVARCHAR(20);
SELECT @pName = productName FROM dbo.product AS p
WHERE p.pid=@pId;
PRINT 'Prod name = '+ @pName;
--4 FINDING THE BIGGEST PRODUCT BY PRICE
BEGIN
DECLARE
	@pId1 INT, @pId2 INT, @price1 FLOAT,@price2 FLOAT,@pIdBig INT;
	SET @pId1=7; SET @pId2=1;
	SELECT @price1 = p.price FROM dbo.product as p WHERE p.pid=@pId1;
	SELECT @price2 = p.price FROM dbo.product as p WHERE p.pid=@pId2;
	if (@price1 > @price1) 
		set @pIdBig = @pId1;
	else
		set @pIdBig = @pId2
	SELECT @pIdBig AS BIG_PRODID_PRICE
	SELECT * FROM product as p WHERE p.pid=@pIdBig;
END
SELECT * FROM product where pid in(1,7);