USE AdventureWorks2012;

-- Using the AVG() aggregate function.
SELECT p.Name AS ProductName, AVG(pin.Quantity) AS AvgQuantity
FROM [Production].[Product] AS p
INNER JOIN [Production].[ProductInventory] AS pin
ON p.ProductID = pin.ProductID
GROUP BY p.Name
ORDER BY p.Name;

-- One row checksum.  Note: HashBytes may be a better change detector.
SELECT CHECKSUM(*), p.ProductID
FROM [Production].[Product] AS p
WHERE p.ProductID = 1;

-- Check if a table has changed
SELECT CHECKSUM_AGG(CHECKSUM(*)) TableCheckSum
FROM [Production].[Product] AS p;

--Get the checksum value of the column which is type smallint.
SELECT CHECKSUM_AGG(CAST(Quantity AS int))
FROM Production.ProductInventory;

-- Will also select a NULL value (10 items)
SELECT DISTINCT p.Color
FROM [Production].[Product] AS p;

-- Notice the count does not include NULL value (9 items counted)
SELECT COUNT(DISTINCT p.Color)
FROM [Production].[Product] AS p;

-- Count by group. Count the Shelf's based on ProductName.
SELECT p.Name AS ProductName, COUNT(pin.Shelf) AS ShelfCount
FROM [Production].[Product] AS p
INNER JOIN [Production].[ProductInventory] AS pin
ON p.ProductID = pin.ProductID
GROUP BY p.Name
ORDER BY p.Name;

-- MIN and MAX of the same column
SELECT  p.Name AS ProductName, 
		MIN(pin.Quantity) AS MinQty,
		MAX(pin.Quantity) AS MaxQty
FROM [Production].[Product] AS p
INNER JOIN [Production].[ProductInventory] AS pin
ON p.ProductID = pin.ProductID
GROUP BY p.Name
ORDER BY p.Name;

-- CEILING (numeric expression)
-- smallest integer greater than or equal to numeric expression
SELECT plph.ProductID, plph.StartDate, plph.ListPrice,
       CEILING(plph.ListPrice) AS TaxableListPrice
FROM [Production].[ProductListPriceHistory] AS plph;

-- FLOOR (numeric expression)
-- Largest integer less than or equal to the specified expression
SELECT plph.ProductID, plph.StartDate, plph.ListPrice,
       FLOOR(plph.ListPrice) AS MinTaxableListPrice
FROM [Production].[ProductListPriceHistory] AS plph;

-- ROUND (numeric_expression, length [ , function])
SELECT plph.ProductID, plph.StartDate, plph.ListPrice,
       ROUND(plph.ListPrice, 1) AS Round1,
	   ROUND(plph.ListPrice, 2) AS Round2,
	   ROUND(plph.ListPrice, 3) AS Round3,
	   ROUND(plph.ListPrice, -1) AS RoundNeg1  -- Opposite direction from decimal point
FROM [Production].[ProductListPriceHistory] AS plph;

-- RAND
SELECT RAND() AS RandomVals;
GO 5

-- RAND(with seed value)
SELECT RAND(1) AS RandomVals;
GO 5  -- with seed will generate the same value each time

SELECT PI(), POWER(100.00, 2), SQRT(25);

-- ROW_NUMBER () OVER ([ <partition_by_clause] <order_by_clause>)
-- Apply row numbers over each window(data subset) that is ordered by ProductID. This is like grouping
-- but the subsets are reduced to a single row. 
SELECT p.ProductID, p.Name,
       ROW_NUMBER() OVER (ORDER BY p.ProductID) AS RowNum
FROM [Production].[Product] AS p
ORDER BY p.ProductID;

-- Apply row numbers over each window(data subset) that is partitioned by color and ordered by Name within the partition. 
SELECT p.Color, p.Name, ROW_NUMBER() OVER (PARTITION BY p.Color ORDER BY p.Name) AS RowNum
FROM [Production].[Product] AS p
WHERE p.Color IS NOT NULL
ORDER BY p.Color, p.Name;

-- Apply a dense rank over standard cost for the entire table
SELECT p.Name, p.StandardCost, DENSE_RANK() OVER(ORDER BY p.StandardCost DESC) AS CostRank
FROM [Production].[Product] AS p
ORDER BY p.StandardCost DESC;

-- NTILE IS A RANKING FUNCTION THAT BREAKS THE RESULT SET UP INTO EQUAL SECTIONS. NUMBER OF SECTIONS IS THE PARAM TO NTILE()
SELECT p.Name, p.StandardCost, NTILE(50) OVER(ORDER BY p.StandardCost DESC) AS CostRank
FROM [Production].[Product] AS p
ORDER BY p.StandardCost DESC;

