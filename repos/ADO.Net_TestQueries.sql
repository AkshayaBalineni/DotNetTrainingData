SELECT p.pid,p.productname,p.price,p.availablestatus,p.imageUrl FROM dbo.product AS p WITH(NOLOCK) WHERE p.isDeleted=0;
SELECT p.pid, p.productname, p.price, p.availablestatus, p.imageUrl  FROM dbo.product AS p WITH(NOLOCK) WHERE p.isDeleted=0; 
insert into dbo.product (pid,productname,price,availablestatus,imageUrl,isDeleted) values(110,'Apple iphone 13 max',125000,'Y','img/i10max/pro.jpg',0);
select * from product;
delete from product where pid=110;
BEGIN TRAN
update dbo.product 
SET productname='Apple I-Pad Mini',price = 30000,availablestatus='Y',imageUrl='images/Apple/01.jpg',isDeleted = 0
WHERE pid=1;
rollback;