-- 1. List all the products
SELECT * FROM dbo.product;
-- 2. List product name and product price
SELECT productname,price from dbo.product;
-- 3. List all customers
SELECT * FROM dbo.customer;
-- 4. List Customername and mobile no
SELECT customername,mobileno FROM dbo.customer;
-- 5. List all orders
SELECT * FROM dbo.orderd;
-- 6. List customer id and orderd date
SELECT customerid,orderdate FROM dbo.orderd;
-- 7. List all the order item
SELECT * FROM dbo.orderitem;
-- 8. List all the product with product id 100
SELECT * FROM dbo.product WHERE pid=100;
-- 9. List all the info of product with name Vivo V3
SELECT * FROM dbo.product WHERE productname LIKE '%Vivo V3%';
-- 10. List pid, productname, price of the phone named "Samsung GalaxyNote-4"
SELECT pid, productname,price FROM dbo.product WHERE productname LIKE '%Samsung GalaxyNote-4%';
-- 11. Print product info for all the product with category id 2003
SELECT * FROM dbo.product WHERE categoryid = 2003;
-- 12. List all the customers address with city as 'Bangalore'
SELECT * FROM dbo.customeraddress WHERE  city like '%Bangalore%';
-- 13. List all the orders which was ordered on '2013-02-02'
SELECT * FROM dbo.orderd WHERE  orderdate = '2013-02-02';
-- 14. Print all the orders of the customer with id 1
SELECT * FROM dbo.orderd WHERE customerid = 1;
-- 15. List all the product with company id 1001 or 1002
SELECT * FROM dbo.product WHERE companyid IN (1001,1002) ;
-- 16. List all the product with price more than 30000
SELECT * FROM dbo.product WHERE price > 30000;
-- 17. List all the products of the category id 2001 or 2003 with 
-- the price more than 30000
SELECT * FROM dbo.product WHERE price > 30000 AND categoryid IN (2001,2003);
-- 18. List all the order of customer id 1 or 4 with ordered on '2013-02-02' 
-- or '2013-02-07'
SELECT * FROM dbo.orderd WHERE customerid IN (1,4) AND orderdate IN ('2013-02-02' ,'2013-02-07');
-- 19. List all the customer whos name starts with character 'A'
SELECT * FROM dbo.customer WHERE customername LIKE '%A%';
-- 20. List all the customer whos name ends with character 'i'
SELECT * FROM dbo.customer WHERE customername LIKE '%A';
-- 21. List all the customer whos name starts with 'R' and ends with 'i'
SELECT * FROM dbo.customer WHERE customername LIKE 'R%i';
-- 22. List all the orders for the year 2013
SELECT * FROM dbo.orderd WHERE orderdate LIKE '2013%';
-- 23. List all the products which are not from the category 2001
SELECT * FROM dbo.product WHERE categoryid NOT IN(2001);
-- 24. List all the products which are not from the category 2001
-- or 2003 with the price more than 30000 and product name has '6' in it
SELECT * FROM dbo.product WHERE price > 30000 AND categoryid NOT IN (2001,2003) AND productname LIKE '%6%';
-- 25. List all the customers whos mobile no doesnt start with 9
SELECT * FROM dbo.customer WHERE mobileno NOT LIKE '9%';
-- 26. List all the nokia phones
SELECT * FROM dbo.product AS p 
INNER JOIN dbo.company AS c ON c.companyid = p.companyid
WHERE c.companyname LIKE '%nokia%';
-- 27. List all the samsung phones
SELECT * FROM dbo.product WHERE productname LIKE '%samsung%';
-- 28. List all the Apple phones
SELECT * FROM dbo.product WHERE productname LIKE '%Apple%';
-- 29. List all the customers from Bangalore
SELECT * FROM dbo.customer as c INNER JOIN dbo.customeraddress AS ca 
ON c.customerid=ca.customerid WHERE ca.city LIKE '%Bangalore%';
-- 30. List all the customers who are not from Bangalore
SELECT * FROM dbo.customer as c INNER JOIN dbo.customeraddress AS ca 
ON c.customerid=ca.customerid WHERE ca.city NOT LIKE '%Bangalore%';
-- 31. List all the customer who have orderd on the date '2013-02-02'
SELECT * FROM dbo.customer as c INNER JOIN dbo.orderd AS o 
ON c.customerid=o.customerid WHERE o.orderdate LIKE '%2013-02-02%';
--SELECT * FROM dbo.customer where  customerid = (select customerid From orderd where orderdate Like '%2013-02-02%');
-- 32. List all the customer who have orderd for phone '6S'
SELECT * FROM dbo.customer AS c INNER JOIN dbo.orderd AS o 
ON c.customerid=o.customerid INNER JOIN dbo.orderitem AS oi ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p ON p.pid=oi.pid WHERE p.productname LIKE '%6S%';
-- 33. List all the customers who have ordered for Apple I-Pad Mini from bangalore
SELECT * FROM dbo.customer AS c INNER JOIN dbo.customeraddress as ca ON c.customerid=ca.customerid 
INNER JOIN dbo.orderd AS o 
ON c.customerid=o.customerid INNER JOIN dbo.orderitem AS oi ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p ON p.pid=oi.pid WHERE p.productname LIKE '%Apple I-Pad Mini%' 
AND ca.city LIKE '%bangalore%';
-- 34. List all the phones which Goutham orderd for
SELECT * FROM dbo.customer AS c INNER JOIN  dbo.orderd AS o 
ON c.customerid=o.customerid INNER JOIN dbo.orderitem AS oi ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p ON p.pid=oi.pid WHERE c.customername LIKE '%Goutham%';
-- 35. List all the phones which Amrutha orderd for in the 2014
SELECT * FROM dbo.customer AS c INNER JOIN  dbo.orderd AS o 
ON c.customerid=o.customerid INNER JOIN dbo.orderitem AS oi ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p ON p.pid=oi.pid WHERE c.customername LIKE '%Amruthi%' AND o.orderdate LIKE '2014%';
-- 36. List all the customer who have not bought any product
SELECT * FROM dbo.customer AS c LEFT OUTER  JOIN  dbo.orderd AS o 
ON c.customerid=o.customerid LEFT OUTER JOIN dbo.orderitem AS oi ON o.orderid=oi.orderid
LEFT OUTER  JOIN dbo.product AS p ON p.pid=oi.pid WHERE o.customerid NOT IN (c.customerid);
-- 37. List Fav phones of Bangalorean
SELECT * FROM dbo.customer AS c INNER JOIN dbo.customeraddress as ca ON c.customerid=ca.customerid 
INNER JOIN dbo.orderd AS o ON c.customerid=o.customerid 
INNER JOIN dbo.orderitem AS oi ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p ON p.pid=oi.pid WHERE ca.city LIKE '%bangalore%';
-- 38. List all the products which were sold in the year 2013
SELECT * FROM dbo.product AS p INNER JOIN
dbo.orderitem AS oi ON oi.pid=p.pid
INNER JOIN dbo.orderd AS o ON p.pid=oi.pid WHERE o.orderdate LIKE '2013%';
-- 39. List all the Nokia phones orderd by 'Ravi'
SELECT * FROM dbo.customer AS c INNER JOIN  dbo.orderd AS o 
ON c.customerid=o.customerid INNER JOIN dbo.orderitem AS oi ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p ON p.pid=oi.pid WHERE c.customername LIKE '%Ravi%' AND p.productname LIKE '%Nokia%';
-- 40. List all the phones with its company name
SELECT * FROM dbo.product AS p INNER JOIN dbo.company AS c ON p.companyid = c.companyid;
-- 41. List companyid, companyname, productname, product price of all products
SELECT c.companyid, p.productname,p.price,c.companyname FROM dbo.product AS p 
INNER JOIN dbo.company AS c ON p.companyid = c.companyid;
-- 42. List customer name, stname and city of all the customer.
SELECT c.customername,ca.stName,ca.city FROM dbo.customer AS c 
INNER JOIN dbo.customeraddress AS ca ON c.customerid=ca.customerid;
-- 43. List customer name and customer city  of all the customer
-- who have never bought any product

-- 44. List Customer id, customer name, orderdate, of all the orders
SELECT c.customerid,c.customername,o.orderdate FROM dbo.customer AS c INNER JOIN  dbo.orderd AS o 
ON c.customerid=o.customerid INNER JOIN dbo.orderitem AS oi ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p ON p.pid=oi.pid ;
-- 45. List Customer id, customer name, orderdate, company and 
-- product name with qty, price of all the orders
SELECT c.customerid,c.customername,o.orderdate,co.companyname,p.productname,oi.qty,p.price FROM dbo.customer AS c 
INNER JOIN  dbo.orderd AS o ON c.customerid=o.customerid 
INNER JOIN dbo.orderitem AS oi ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p ON p.pid=oi.pid 
INNER JOIN dbo.company AS co ON co.companyid = p.companyid;
-- 46. List Customer id, customer name, orderdate, company and 
-- product name with qty, price and amount of all the orders 
-- where amount is qty*price
SELECT c.customerid,c.customername,o.orderdate,co.companyname,p.productname,oi.qty,p.price,SUM(p.price*oi.qty) Amount 
FROM dbo.customer AS c WITH (NOLOCK)
INNER JOIN  dbo.orderd AS o WITH (NOLOCK)
ON c.customerid=o.customerid 
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
INNER JOIN dbo.company AS co WITH (NOLOCK)
ON co.companyid = p.companyid
GROUP BY o.orderid,c.customerid,c.customername,o.orderdate,co.companyname,p.productname,oi.qty,p.price;
/* 47. List Customer id, customer name, orderdate, company and 
product name with qty, price and amount of all the orders  
where amount > 50,000 (amount is qty*price) */
SELECT c.customerid,c.customername,o.orderdate,co.companyname,p.productname,oi.qty,p.price,SUM(p.price*oi.qty) Amount 
FROM dbo.customer AS c WITH (NOLOCK)
INNER JOIN  dbo.orderd AS o WITH (NOLOCK)
ON c.customerid=o.customerid 
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
INNER JOIN dbo.company AS co WITH (NOLOCK)
ON co.companyid = p.companyid
GROUP BY o.orderid ,c.customerid,c.customername,o.orderdate,co.companyname,p.productname,oi.qty,p.price
HAVING SUM(p.price*oi.qty) > 50000;
/* 48. List customerid, customername, city, companyname, productname,
qty, price and amount of all the products orderd */
SELECT c.customerid,c.customername,ca.city,co.companyname,p.productname,oi.qty,p.price,SUM(p.price*oi.qty) Amount 
FROM dbo.customer AS c WITH (NOLOCK)
INNER JOIN dbo.customeraddress as ca WITH(NOLOCK)
ON c.customerid =ca.customerid
INNER JOIN  dbo.orderd AS o WITH (NOLOCK)
ON c.customerid=o.customerid 
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
INNER JOIN dbo.company AS co WITH (NOLOCK)
ON co.companyid = p.companyid
GROUP BY o.orderid,c.customerid,c.customername,ca.city,co.companyname,p.productname,oi.qty,p.price;
/* 49. List all product, company, customer and 
customer address details for all orders
which were ordered in the year 2014
*/
SELECT c.customerid,c.customername,ca.city,co.companyname,p.productname,oi.qty,p.price ,YEAR(o.orderdate) OrderYear
FROM dbo.customer AS c WITH (NOLOCK)
INNER JOIN dbo.customeraddress as ca WITH(NOLOCK)
ON c.customerid =ca.customerid
INNER JOIN  dbo.orderd AS o WITH (NOLOCK)
ON c.customerid=o.customerid 
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
INNER JOIN dbo.company AS co WITH (NOLOCK)
ON co.companyid = p.companyid
GROUP BY YEAR(o.orderdate),o.orderid,c.customerid,c.customername,ca.city,co.companyname,p.productname,oi.qty,p.price;
/* 50. Update amount of order item */
BEGIN TRAN
UPDATE oi SET oi.amount = p.price * oi.qty
FROM dbo.orderitem AS oi INNER JOIN dbo.product AS p WITH(NOLOCK)
ON oi.pid=p.pid INNER JOIN dbo.orderd AS o WITH(NOLOCK)
ON o.orderid=oi.orderid WHERE oi.orderid != 0;
COMMIT
select * from dbo.orderitem;
/* 51. Get the total sales based on orderid  */
SELECT o.orderid,p.productname,SUM(p.price*oi.qty) Amount 
FROM  dbo.orderd AS o WITH (NOLOCK)
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
GROUP BY o.orderid,p.productname;
/* 52. Get the total sales based on given month  */
SELECT o.orderid,p.productname,SUM(p.price*oi.qty) Amount ,DATENAME(month, o.orderdate) AS  OrderedMonth
FROM  dbo.orderd AS o WITH (NOLOCK)
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
GROUP BY o.orderid,p.productname,DATENAME(month, o.orderdate);
/* 53. Get the total sales based on year  */
SELECT o.orderid,p.productname,SUM(p.price*oi.qty) Amount ,YEAR(o.orderdate) OrderedYear
FROM  dbo.orderd AS o WITH (NOLOCK)
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
GROUP BY o.orderid,p.productname,DATENAME(month, o.orderdate),YEAR(o.orderdate);
/* 54. Get the total sales based on month and year */
SELECT o.orderid,p.productname,SUM(p.price*oi.qty) Amount ,DATENAME(month, o.orderdate) AS  OrderedMonth,YEAR(o.orderdate) OrderedYear
FROM  dbo.orderd AS o WITH (NOLOCK)
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
GROUP BY o.orderid,p.productname,DATENAME(month, o.orderdate),YEAR(o.orderdate);
/* 55. Total sales based on product  */
SELECT p.productname,oi.qty,oi.amount 
FROM  dbo.orderd AS o WITH (NOLOCK)
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
GROUP BY p.productname,p.pid,oi.amount,oi.qty ;
/* 56. Total sales based on company  */
SELECT o.orderid,c.customerid,c.customername,ca.city,co.companyname,p.productname,p.price,oi.qty,oi.amount,YEAR(o.orderdate) OrderYear
FROM dbo.customer AS c WITH (NOLOCK)
INNER JOIN dbo.customeraddress as ca WITH(NOLOCK)
ON c.customerid =ca.customerid
INNER JOIN  dbo.orderd AS o WITH (NOLOCK)
ON c.customerid=o.customerid 
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
INNER JOIN dbo.company AS co WITH (NOLOCK)
ON co.companyid = p.companyid
GROUP BY YEAR(o.orderdate),o.orderid,c.customerid,c.customername,ca.city,co.companyname,p.productname,oi.qty,p.price,oi.amount;
/* 57. Display top 3 sold mobiles */
SELECT TOP 3 p.productname,SUM(p.price*oi.qty) Amount ,DATENAME(month, o.orderdate) AS  OrderedMonth,YEAR(o.orderdate) OrderedYear
FROM  dbo.orderd AS o WITH (NOLOCK)
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
GROUP BY p.productname,DATENAME(month, o.orderdate),YEAR(o.orderdate);
/* 58. Top 3 customers based on billing amount */
SELECT TOP 3 o.orderid, c.customername,p.productname,p.price,SUM(oi.qty*p.price) BillingAmount
FROM dbo.customer AS c WITH (NOLOCK)
INNER JOIN dbo.customeraddress as ca WITH(NOLOCK)
ON c.customerid =ca.customerid
INNER JOIN  dbo.orderd AS o WITH (NOLOCK)
ON c.customerid=o.customerid 
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
INNER JOIN dbo.company AS co WITH (NOLOCK)
ON co.companyid = p.companyid
GROUP BY o.orderid,c.customername,p.productname,p.price
ORDER BY BillingAmount DESC ;
/* 59. Top 3rd customer based on billing amount */
SELECT * FROM (SELECT c.customername,p.productname,p.price,SUM(oi.qty*p.price)AS BillingAmount,
DENSE_RANK() OVER(ORDER BY (p.price*oi.qty) DESC ) AS billingRank
FROM dbo.customer AS c WITH (NOLOCK)
INNER JOIN  dbo.orderd AS o WITH (NOLOCK)
ON c.customerid=o.customerid 
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
INNER JOIN dbo.company AS co WITH (NOLOCK)
ON co.companyid = p.companyid
GROUP BY o.orderid,c.customername,p.productname,p.price,oi.qty
)AS result WHERE  result.billingRank = 3
/* 60. Display all unique phones which are sold */
SELECT DISTINCT(p.productname),p.price
FROM  dbo.orderd AS o WITH (NOLOCK)
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
GROUP BY p.productname,p.price;
/* 61. Display all phones which are sold with the no. of quantity */
SELECT p.productname,p.price,oi.qty
FROM  dbo.orderd AS o WITH (NOLOCK)
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
GROUP BY p.productname,p.price ,oi.qty;
/* 62. Name of the top priced phone */
SELECT TOP 3 p.productname,p.price FROM dbo.product as p
GROUP BY p.price,p.productname
ORDER BY p.price DESC;
/*63. Updated Total Amount In ordered */
BEGIN TRAN
UPDATE o SET o.totalAmount = (select COUNT(o.orderid) FROM dbo.orderd AS o INNER JOIN dbo.orderitem AS oi WITH(NOLOCK)
ON o.orderid = oi.orderid INNER JOIN dbo.product AS p WITH(NOLOCK)
ON oi.pid=p.pid) * oi.amount
FROM dbo.orderd AS o INNER JOIN dbo.orderitem AS oi WITH(NOLOCK)
ON o.orderid = oi.orderid INNER JOIN dbo.product AS p WITH(NOLOCK)
ON oi.pid=p.pid
rollback;
COMMIT
--select * from orderd;
--Select o.orderid,SUM(p.price*oi.qty) as totalAMOUNT From dbo.orderd as o Inner join dbo.orderitem as oi
--on oi.orderid=o.orderid inner join dbo.product as p on p.pid =oi.pid
--GROUP BY o.orderid
--order by o.orderid ;

CREATE VIEW v_order
AS
SELECT TOP 3 o.orderid, c.customername,p.productname,p.price,SUM(oi.qty*p.price) BillingAmount
FROM dbo.customer AS c WITH (NOLOCK)
INNER JOIN dbo.customeraddress as ca WITH(NOLOCK)
ON c.customerid =ca.customerid
INNER JOIN  dbo.orderd AS o WITH (NOLOCK)
ON c.customerid=o.customerid 
INNER JOIN dbo.orderitem AS oi WITH (NOLOCK)
ON o.orderid=oi.orderid
INNER JOIN dbo.product AS p WITH (NOLOCK)
ON p.pid=oi.pid 
INNER JOIN dbo.company AS co WITH (NOLOCK)
ON co.companyid = p.companyid
WHERE p.isDeleted =0
GROUP BY o.orderid,c.customername,p.productname,p.price
ORDER BY BillingAmount DESC ;

select * from v_order;

BEGIN TRAN
UPDATE dbo.v_order SET customername = 'Amrutha' WHERE orderid = 48;
UPDATE dbo.customer SET customername = 'Amrutha' where customerid = 1;
ROLLBACK

SELECT * FROM dbo.customer;
----------------------------------------------------
CREATE VIEW v_customer
AS
SELECT * FROM dbo.customer;
GO
SELECT * FROM v_customer;
BEGIN TRAN
UPDATE v_customer SET customername = 'Amrutha' where customerid = 1;
rollback