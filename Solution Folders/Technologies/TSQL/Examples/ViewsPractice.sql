use [InsideTSQL2008]
GO

IF OBJECT_ID('Sales.MyCustOrders', 'v') IS NOT NULL
	DROP VIEW Sales.MyCustOrders;
GO

CREATE VIEW Sales.MyCustOrders 
AS
Select TOP(20) custid, companyname, contactname
FROM Sales.Customers c
WHERE EXISTS
	(SELECT * FROM Sales.CustOrders o
	 WHERE c.custid = o.custid)
ORDER BY contactname;                 -- used by TOP clause. Does not guarantee order 
GO

SELECT custid, companyname, contactname
FROM Sales.MyCustOrders
ORDER BY contactname;