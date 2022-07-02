-- http://technet.microsoft.com/en-us/library/ms188783.aspx

USE AdventureWorks2012;

--------- Creating a simple nonclustered(by default) index on the BusinessEntityID column -----
IF EXISTS (SELECT name FROM sys.indexes
            WHERE name = N'IX_ProductVendor_BusinessEntityID')
    DROP INDEX IX_ProductVendor_BusinessEntityID ON Purchasing.ProductVendor;
GO

CREATE INDEX IX_ProductVendor_BusinessEntityID
    ON Purchasing.ProductVendor (BusinessEntityID); 


--------- Creating a simple unique nonclustered index on the Name field ---------
-- There is no significant difference between a unique index and a unique constraint
IF EXISTS (SELECT name from sys.indexes
             WHERE name = N'AK_UnitMeasure_Name')
    DROP INDEX AK_UnitMeasure_Name ON Production.UnitMeasure;
GO

CREATE UNIQUE INDEX AK_UnitMeasure_Name
	ON Production.UnitMeasure(Name);


--------- Creating a simple nonclustered composite index ------
IF EXISTS (SELECT name FROM sys.indexes
            WHERE name = N'IX_SalesPerson_SalesQuota_SalesYTD')
    DROP INDEX IX_SalesPerson_SalesQuota_SalesYTD ON Sales.SalesPerson ;
GO

CREATE NONCLUSTERED INDEX IX_SalesPerson_SalesQuota_SalesYTD
    ON Sales.SalesPerson (SalesQuota, SalesYTD);

---------- Creates indexes by default when table is created ------------------
CREATE TABLE [dbo].[TestAutoCreateIndexesTable]
(ID INT IDENTITY(1,1) PRIMARY KEY, -- Non-clustered index created by default
Col1 INT NOT NULL UNIQUE)          -- Clustered index created by default

-- Different inserted values into Col1 will stay in order of their value(Clustered table)
INSERT INTO [dbo].[TestAutoCreateIndexesTable]
(
	Col1
)
VALUES(14);

SELECT * FROM [dbo].[TestAutoCreateIndexesTable];

-- Check Indexes
SELECT OBJECT_NAME(OBJECT_ID) AS TableObject, [name] AS IndexName, [Type_Desc] AS TypeDescription
FROM sys.indexes
WHERE OBJECT_NAME(OBJECT_ID) = 'TestAutoCreateIndexesTable'

-- Clean up
DROP TABLE [dbo].[TestAutoCreateIndexesTable]


--------- 


