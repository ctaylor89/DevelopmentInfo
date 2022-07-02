USE [AdventureWorks2012]

-- This query demonstrates the importance of using the correct data type
-- and not relying on conversions.
SELECT  e.BusinessEntityID,
        e.NationalIDNumber
FROM    HumanResources.Employee AS e
WHERE   e.NationalIDNumber = '112457891';  -- Correct. Data type is a nvarchar()
-- WHERE   e.NationalIDNumber = 112457891; -- Incorrect. Forces a conversion. Index cannot be used. 
                                           -- Results in a table scan

-- Using function in where clause prevents the use of indexes.
SELECT  a.AddressLine1,
        a.AddressLine2,
        a.City
FROM    Person.Address AS a
WHERE   a.AddressLine1 LIKE '4444';
-- WHERE   '4444' = LEFT(a.AddressLine1, 4) ; -- This forces a table scan according to the execution plan.



