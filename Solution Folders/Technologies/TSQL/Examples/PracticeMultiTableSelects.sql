USE AdventureWorks2012;

SELECT p.Name, od.ProductID, od.SalesOrderDetailID, od.OrderQty
FROM Production.Product AS p
INNER JOIN Sales.SalesOrderDetail AS od   -- INNER JOIN same as JOIN
ON p.ProductID = od.ProductID
WHERE od.OrderQty > 5
ORDER BY p.Name, od.OrderQty;

SELECT p.Name, p.ProductID, od.ProductID, od.SalesOrderDetailID, od.OrderQty
FROM Production.Product AS p
LEFT OUTER JOIN Sales.SalesOrderDetail AS od    -- LEFT JOIN is the same as LEFT OUTER JOIN
ON p.ProductID = od.ProductID
ORDER BY p.Name, od.OrderQty;

SELECT p.Name, od.ProductID, od.SalesOrderDetailID, od.OrderQty
FROM Production.Product AS p
LEFT OUTER JOIN Sales.SalesOrderDetail AS od
ON p.ProductID = od.ProductID
WHERE od.ProductID IS NULL               -- NOTICE THE USE OF 'IS' INSTEAD OF '='
ORDER BY p.Name, od.OrderQty;

SELECT p.Name, od.ProductID, od.SalesOrderDetailID, od.OrderQty
FROM Production.Product AS p
LEFT OUTER JOIN Sales.SalesOrderDetail AS od
ON p.ProductID = od.ProductID AND
	od.OrderQty > 2                      -- Evaluated during join condition. Null values will show up in result set.
ORDER BY p.Name, od.SalesOrderID;

SELECT p.Name, od.ProductID, od.SalesOrderDetailID, od.OrderQty
FROM Production.Product AS p
LEFT OUTER JOIN Sales.SalesOrderDetail AS od  -- LEFT JOIN is the same as LEFT OUTER JOIN
ON p.ProductID = od.ProductID
WHERE od.OrderQty > 2                     -- Evaluated after join condition. Null values will not show up in result set.
ORDER BY p.Name, od.SalesOrderID;

SELECT p.Name AS ProductName, ps.Name AS CategoryName, pc.Name AS SubcategoryName
FROM Production.Product AS p
INNER JOIN Production.ProductSubcategory AS ps
ON p.ProductSubcategoryID = ps.ProductSubcategoryID
INNER JOIN Production.ProductCategory AS pc            -- Join with a third table
ON ps.ProductCategoryID = pc.ProductCategoryID
ORDER BY ProductName, CategoryName, SubcategoryName;

-- Adding column for Self Join demo
ALTER TABLE HumanResources.Employee
ADD ManagerID int NULL;
GO

SELECT * FROM HumanResources.Employee;

UPDATE HumanResources.Employee
SET ManagerID = 1
WHERE BusinessEntityID <> 1;         -- Everyone except the CEO

UPDATE HumanResources.Employee       -- Employee 3 works directly for employee 2
SET ManagerID = 2
WHERE BusinessEntityID = 3;

SELECT e.BusinessEntityID, e.HireDate, e.ManagerID, m.HireDate AS ManagerHireDate, m.BusinessEntityID AS ManagerBusinessEntityID
FROM HumanResources.Employee AS e
LEFT JOIN HumanResources.Employee AS m   -- LEFT JOIN is the same as LEFT OUTER JOIN
ON e.ManagerID = m.BusinessEntityID     -- where the employee's MangerID is same as the Manager's BusinessEntityID.	
ORDER BY e.BusinessEntityID;

-- Drop column after Self Join demo
ALTER TABLE HumanResources.Employee
DROP COLUMN ManagerID;
GO

-- Another Self Join demo
SELECT DISTINCT pv1.ProductID, pv1.BusinessEntityID, pv2.ProductID, pv2.BusinessEntityID
FROM Purchasing.ProductVendor pv1
INNER JOIN Purchasing.ProductVendor pv2
ON pv1.ProductID = pv2.ProductID
AND pv1.BusinessEntityID = pv2.BusinessEntityID
ORDER BY pv1.ProductID;
-- End another self join demo

-- Demo: Multi-Attribute Join
SELECT sod.SalesOrderID, sod.SalesOrderDetailID, sod.ProductID, sod.OrderQty, so.SpecialOfferID, 
       so.ModifiedDate, so.StartDate, so.EndDate, so.Description
FROM Sales.SalesOrderDetail AS sod
INNER JOIN Sales.SpecialOffer AS so
ON so.SpecialOfferID = sod.SpecialOfferID  -- predicate is an equi-join
	AND sod.ModifiedDate < so.EndDate      -- predicate is a non equi-join
	AND sod.ModifiedDate >= so.StartDate   -- predicate is a non equi-join
WHERE so.SpecialOfferID > 1;

-- Creating a new table based on Person.BusinessEntityAddress
SELECT BusinessEntityID, AddressID, AddressTypeID, rowguid, ModifiedDate 
INTO Person.BusinessEntityAddressArchive
FROM Person.BusinessEntityAddress;

-- Removing an arbitrary 1,500 rows for this demo
DELETE TOP (1500)
FROM Person.BusinessEntityAddressArchive;

-- Which rows are in the production table that are not in the archive table?
SELECT bea.BusinessEntityID, bea.AddressID, bea.AddressTypeID,
	   bea.rowguid, bea.ModifiedDate
FROM Person.BusinessEntityAddress AS bea
LEFT OUTER JOIN Person.BusinessEntityAddressArchive AS abea
ON bea.BusinessEntityID = abea.BusinessEntityID     -- these 3 columns make up a composite key in the table
	AND bea.AddressID = abea.AddressID
	AND bea.AddressTypeID = abea.AddressTypeID
WHERE abea.BusinessEntityID IS NULL;                -- performed on the left outer join result set

-- For my understanding, this returns no records
SELECT * FROM Person.BusinessEntityAddressArchive AS abea
WHERE abea.BusinessEntityID IS NULL;

-- Remove table after demo
DROP TABLE Person.BusinessEntityAddressArchive;

