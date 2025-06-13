USE AdventureWorks2012;
---------------------------------------------------------
-- Compare results from both NEWID() and NEWSEQUENTIALID()
IF OBJECT_ID('NEWID_TEST', 'U') IS NOT NULL
	DROP TABLE NEWID_TEST;
GO

CREATE TABLE NEWID_TEST
(
    ID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    TESTCOLUMN CHAR(2000) DEFAULT REPLICATE('X',2000)
)
GO

IF OBJECT_ID('NEWSEQUENTIALID_TEST', 'U') IS NOT NULL
	DROP TABLE NEWSEQUENTIALID_TEST;
GO

CREATE TABLE NEWSEQUENTIALID_TEST
(
ID UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() PRIMARY KEY,
TESTCOLUMN CHAR(2000) DEFAULT REPLICATE('X',2000)
)
GO

-- INSERT 1000 ROWS INTO EACH TEST TABLE 
DECLARE @COUNTER INT = 1;
--SET @COUNTER = 1

WHILE (@COUNTER <= 1000)
BEGIN
   INSERT INTO NEWID_TEST DEFAULT VALUES 
   INSERT INTO NEWSEQUENTIALID_TEST DEFAULT VALUES 
   SET @COUNTER = @COUNTER + 1
END
GO

SELECT TOP 3 ID FROM NEWID_TEST
SELECT TOP 3 ID FROM NEWSEQUENTIALID_TEST
GO
---------------------------------------------------------
-- Working with money
DECLARE @mymoney_sm smallmoney = 3148.29,
        @mymoney    money = 3148.29;
SELECT  CAST(@mymoney_sm AS varchar) AS SM_MONEY,
        CAST(@mymoney AS decimal)    AS 'MONEY DECIMAL';
GO
---------------------------------------------------------
-- Assign a string to a variable.
DECLARE @myvar char(20) = 'This is a test';
--SET @myvar = 'This is a test';
SELECT @myvar;
GO
--------------------------------------------------
-- Example of a CTE making a recursive call.
WITH ShowMessage(STATEMENT, LENGTH)
AS
(
    SELECT STATEMENT = CAST('I Like ' AS VARCHAR(300)), LEN('I Like ')
    UNION ALL
    SELECT
          CAST(STATEMENT + 'CodeProject! ' AS VARCHAR(300))
          , LEN(STATEMENT) FROM ShowMessage
    WHERE LENGTH < 300
)
SELECT STATEMENT, LENGTH FROM ShowMessage
--------------------------------------------------
-- Looping through a data set using Dynamic SQL. Selects a list of all the databases.
USE master;
-- Select * from sysdatabases;

Create table #temp 
(
	name nvarchar(max)
)

Declare @dsql as nvarchar(2000),
 @CountLoop as int,
 @Seed as int,
 @databasename as varchar(50)
 
--The @seed value gives us a starting point for our loop. 
--The @countloop value gives us the number of times we will need to iterate through the loop.
 Select @Seed = 1; 
 
 WITH c(Total)
 AS
 (
    Select count(*) from sysdatabases
 )
 select @CountLoop = (select Total from c);
-- OR 
--Select @CountLoop = (Select count(*) from sysdatabases)
 
 While (@Seed < @CountLoop)
 Begin 
    --Select the individual database associated with the current @countloop
     Select @Databasename = (Select name from sysdatabases where [dbid] = @Seed)
 
    --Define the dynamic SQL statement to be executed. @Databasename is the name of the database associated with the current @countloop
     Select @dsql = ('select ''' + @databasename + '''')
 
    --Execute the the genereated dynamic sql statement and populate each @Databasename into the temp table.
     Insert into #tempTable    -- creates the temporary table
     Exec sp_executesql @dsql
 
    --Increment the count
     select @seed = (@seed +1) 
 END
 
--When the loop completes we can then query our temp table
 Select * from #tempTable
 drop table #tempTable
--------------------------------------------------
-- Dropping a local Temporary Table if it exists. Remember underscores and numbers appended to the name of the table in the tempdb.
IF OBJECT_ID(N'tempdb..#temp_Drivers') IS NOT NULL
	DROP TABLE dbo.#temp_Drivers;

Create table dbo.#temp_Drivers
(
	driverName nvarchar(max)
)
--------------------------------------------------
Select custid, region INTO dbo.#tempRegion    -- creates the temporary table
from Sales.Customers
where region is not null
order by region;

Select * from dbo.#tempRegion;

DROP TABLE #tempRegion;

















