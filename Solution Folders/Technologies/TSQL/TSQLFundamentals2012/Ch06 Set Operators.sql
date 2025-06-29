---------------------------------------------------------------------
-- Microsoft SQL Server 2012 T-SQL Fundamentals
-- Chapter 06 - Set Operators
-- � Itzik Ben-Gan 
---------------------------------------------------------------------

SET NOCOUNT ON
USE TSQL2012;

---------------------------------------------------------------------
-- The UNION Operator
---------------------------------------------------------------------

-- The UNION ALL Multiset Operator
SELECT country, region, city FROM HR.Employees
UNION ALL
SELECT country, region, city FROM Sales.Customers;

-- The UNION Distinct Set Operator
SELECT country, region, city FROM HR.Employees
UNION
SELECT country, region, city FROM Sales.Customers;

---------------------------------------------------------------------
-- The INTERSECT Operator
---------------------------------------------------------------------

-- The INTERSECT Distinct Set Operator
SELECT country, region, city FROM HR.Employees
INTERSECT
SELECT country, region, city FROM Sales.Customers;

-- The INTERSECT ALL Multiset Operator (Optional, Advanced)
SELECT
  ROW_NUMBER() 
    OVER(PARTITION BY country, region, city
         ORDER BY (SELECT 0)) AS rownum,
  country, region, city
FROM HR.Employees

INTERSECT

SELECT
  ROW_NUMBER() 
    OVER(PARTITION BY country, region, city
         ORDER BY (SELECT 0)),
  country, region, city
FROM Sales.Customers;


WITH INTERSECT_ALL
AS
(
  SELECT
    ROW_NUMBER() 
      OVER(PARTITION BY country, region, city
           ORDER     BY (SELECT 0)) AS rownum,
    country, region, city
  FROM HR.Employees

  INTERSECT

  SELECT
    ROW_NUMBER() 
      OVER(PARTITION BY country, region, city
           ORDER     BY (SELECT 0)),
    country, region, city
  FROM Sales.Customers
)
SELECT country, region, city
FROM INTERSECT_ALL;

---------------------------------------------------------------------
-- The EXCEPT Operator
---------------------------------------------------------------------

-- The EXCEPT Distinct Set Operator

-- Employees EXCEPT Customers
SELECT country, region, city FROM HR.Employees
EXCEPT
SELECT country, region, city FROM Sales.Customers;

-- Customers EXCEPT Employees
SELECT country, region, city FROM Sales.Customers
EXCEPT
SELECT country, region, city FROM HR.Employees;

-- The EXCEPT ALL Multiset Operator (Optional, Advanced)
WITH EXCEPT_ALL
AS
(
  SELECT
    ROW_NUMBER() 
      OVER(PARTITION BY country, region, city
           ORDER BY (SELECT 0)) AS rownum,
    country, region, city
  FROM HR.Employees

  EXCEPT

  SELECT
    ROW_NUMBER() 
      OVER(PARTITION BY country, region, city
           ORDER BY (SELECT 0)),
    country, region, city
  FROM Sales.Customers
)
SELECT country, region, city
FROM EXCEPT_ALL;

---------------------------------------------------------------------
-- Precedence
---------------------------------------------------------------------

-- INTERSECT Precedes EXCEPT
SELECT country, region, city FROM Production.Suppliers
EXCEPT
SELECT country, region, city FROM HR.Employees
INTERSECT
SELECT country, region, city FROM Sales.Customers;

-- Using Parenthesis. Parenthesis have the highest precedece.
(SELECT country, region, city FROM Production.Suppliers
 EXCEPT
 SELECT country, region, city FROM HR.Employees)
INTERSECT
SELECT country, region, city FROM Sales.Customers;

---------------------------------------------------------------------
-- Circumventing Unsupported Logical Phases
-- (Optional, Advanced)
---------------------------------------------------------------------

-- Number of Cities per country Covered by Both Customers
-- and Employees
SELECT country, COUNT(*) AS numlocations
FROM (SELECT country, region, city FROM HR.Employees
      UNION
      SELECT country, region, city FROM Sales.Customers) AS U
GROUP BY country;

-- Two most recent orders for employees 3 and 5
SELECT empid, orderid, orderdate
FROM (SELECT TOP (2) empid, orderid, orderdate
      FROM Sales.Orders
      WHERE empid = 3
      ORDER BY orderdate DESC, orderid DESC) AS D1

UNION ALL

SELECT empid, orderid, orderdate
FROM (SELECT TOP (2) empid, orderid, orderdate
      FROM Sales.Orders
      WHERE empid = 5
      ORDER BY orderdate DESC, orderid DESC) AS D2;

-- in SQL Server 2012
SELECT empid, orderid, orderdate
FROM (SELECT empid, orderid, orderdate
      FROM Sales.Orders
      WHERE empid = 3
      ORDER BY orderdate DESC, orderid DESC
      OFFSET 0 ROWS FETCH FIRST 2 ROWS ONLY) AS D1

UNION ALL

SELECT empid, orderid, orderdate
FROM (SELECT empid, orderid, orderdate
      FROM Sales.Orders
      WHERE empid = 5
      ORDER BY orderdate DESC, orderid DESC
      OFFSET 0 ROWS FETCH FIRST 2 ROWS ONLY) AS D2;