
--VERSION 1.0
--DATE 4th JUN 2022
--@DEV 67562

---EXEC sp_Pagination 5
IF EXISTS(
	SELECT 1 FROM sys.objects WHERE type = 'p' AND OBJECT_ID =OBJECT_ID('[dbo].[sp_Pagination]')
	)
	BEGIN
		DROP PROC [dbo].[sp_Pagination]
	END
GO
CREATE PROC [dbo].[sp_Pagination]
	@pageNo INT
AS
BEGIN
declare @pageSize INT = 20
SELECT rownumber, pid,productname,price,availablestatus,imageUrl from(
select pid,productname,price,availablestatus,imageUrl, ROW_NUMBER() over (order by pid) as rownumber from product where isDeleted = 0) p
where (p.rownumber BETWEEN (@pageNo-1)*@pageSize + 1 AND @pageNo*@pageSize ) 
END
