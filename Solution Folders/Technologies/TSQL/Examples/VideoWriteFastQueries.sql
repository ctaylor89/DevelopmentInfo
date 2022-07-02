-- Write faster queries video
http://www.youtube.com/watch?v=H7tPyVA7tRY

-- Database performance optimization part 1 (Indexing strategies) from CodeProject
-- http://www.codeproject.com/Articles/234399/Database-performance-optimization-part-Indexing?fid=1643149&df=90&mpp=25&noise=3&prof=False&sort=Position&view=Normal&spc=Relaxed&fr=26#xx0xx
-------------------------------------------------------
-- From video tutorial Writing Faster Queries
-------------------------------------------------------
USE AdventureWorks2012;

SET STATISTICS IO ON;
GO
---
SELECT c.ModifiedDate
FROM Sales.Customer c
WHERE YEAR (ModifiedDate) = 2008;

-- Use a range based seekx
SELECT c.ModifiedDate
FROM Sales.Customer c
WHERE ModifiedDate >= '20080101' AND ModifiedDate < '20090101';
---
SELECT c.ModifiedDate
FROM Sales.Customer c
WHERE DATEADD(YEAR, 2, ModifiedDate) < '12/16/2010';

-- Use a range based seek
SELECT c.ModifiedDate
FROM Sales.Customer c
WHERE ModifiedDate < DATEADD(YEAR, -2, '12/16/2010');
---
CREATE NONCLUSTERED INDEX IX_Customer_ModifiedDate
	ON Sales.Customer(ModifiedDate);

DROP INDEX IX_Customer_ModifiedDate
	ON Sales.Customer;
-------------------------------------------------------
