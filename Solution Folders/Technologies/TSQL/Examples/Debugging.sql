USE [AdventureWorks2012]

IF (SELECT SUM(i.Quantity)
    FROM Production.ProductInventory i
    JOIN Production.Product p 
    ON i.ProductID = p.ProductID
    WHERE Name = 'Hex Nut 17'
    ) < 1100
    PRINT N'There are less than 1100 units of Hex Nut 17 in stock.'
GO
---------------------------------------
-- Test the value of a temp variable
DECLARE @HexNutCount int;

SET @HexNutCount = (SELECT SUM(i.Quantity)
    FROM Production.ProductInventory i
    JOIN Production.Product p 
    ON i.ProductID = p.ProductID
    WHERE Name = 'Hex Nut 17');

SELECT @HexNutCount - 100;
---------------------------------------
-- This shows building a character variable that is used to print a message.
DECLARE @Msg NVARCHAR(300);

SELECT @Msg = N'The Database Engine instance '
    + RTRIM(@@SERVERNAME)
    + N' is running SQL Server build '
    + RTRIM(CAST(SERVERPROPERTY(N'ProductVersion') AS NVARCHAR(128)));

PRINT @Msg;

---------------------------------------
-- A few ways to display the value of a variable
DECLARE @MsgTest NVARCHAR(100);
DECLARE @MyValue int;
SET @MyValue = 559;

--This outputs a message with a value
SELECT @MsgTest = N'The value of MsgTest is '
    + RTRIM(CAST(@MyValue AS NVARCHAR(10)));

PRINT @MsgTest;
GO

-- This outputs a single column result set with a value
SET @MsgTest = N'The value of MsgTest is '
    + RTRIM(CAST(@MyValue AS NVARCHAR(10)));

SELECT @MsgTest;

-- Can also just select the variable
SELECT @MyValue;
GO




