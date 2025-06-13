USE AdventureWorks2012;

SELECT TransactionID, ProductID, Quantity, ActualCost,
	'Batch1' AS BatchID, ([Quantity] * [ActualCost]) AS [TotalCost]
FROM Production.TransactionHistory;

-- Department Table operations --

-- Drop table if exists
IF OBJECT_ID ('dbo.Department', 'U') IS NOT NULL
    DROP TABLE dbo.Department;

CREATE TABLE [dbo].[Department](
	[Department ID] int NOT NULL,
	[Employee ID] int NOT NULL,
	[Salary] money NULL
	)
GO

INSERT INTO dbo.Department
VALUES
(2009, 7708, 44.00),
(2019, 7709, 54.00),
(2029, 7718, 144.00);
GO

-- Testing a row for a field with a specified value
DECLARE @SalaryChk int;
SELECT @SalaryChk = COUNT(Salary) FROM dbo.Department WHERE Salary = 144.00;	-- Count() returns the number of rows where Salary equals 144
IF(@SalaryChk > 0)
BEGIN
	INSERT INTO dbo.Department([Employee ID], [Department ID])
	VALUES(444, 322.33);	
END
GO

INSERT INTO dbo.Department([Employee ID], [Department ID])
VALUES(400, 300);

-- Table alias
SELECT [Dept].[Department ID], [Dept].[Employee ID], [Dept].[Salary]
FROM [dbo].[Department] AS [Dept];

DROP TABLE dbo.Department;
GO
------------ End Department Table operations --------------

-- Setting a value in a TSQL variable
-- Declare two variables.
DECLARE @FirstNameVariable nvarchar(50),
        @PostalCodeVariable nvarchar(10);

-- Set their values. Only the  number of chars allowed will be assigned
--SET @FirstNameVariable = N'Amy';
--SET @PostalCodeVariable = N'BA5 3HXASDFGTRHYUIOPL';
-- or
SELECT @FirstNameVariable = N'Amy',      -- Can assign values to more than one variable with a single SELECT clause
       @PostalCodeVariable = N'BA5 3HXASDFGTRHYUIOPL';

-- or
-- SELECT @PostalCodeVariable = N'BA5 3HXASDFGTRHYUIOPL'; -- an assignment same as set. No returned result

SET @PostalCodeVariable = '93010';
SELECT @PostalCodeVariable AS N'PostalCode';   --  To get the returned result

-- Use them in the WHERE clause of a SELECT statement.
SELECT LastName, FirstName, JobTitle, City, StateProvinceName, CountryRegionName
FROM HumanResources.vEmployee
WHERE FirstName = @FirstNameVariable
   OR PostalCode = @PostalCodeVariable;
GO
-- End Setting a value in a TSQL variable

-- Declare table variable and access it
DECLARE @CostTracker TABLE
(
	[Quantity] int NOT NULL,
	[TotalCost] money NOT NULL,
	[MyCost] money NULL
);
-- Insert into the table variable
INSERT INTO @CostTracker(Quantity, TotalCost)
SELECT [Quantity], ([Quantity] * [ActualCost])
FROM [Production].[TransactionHistory];

-- Update the table variable
UPDATE @CostTracker
SET [MyCost] = 777.77
WHERE [Quantity] = 550;

-- Select from the table variable
SELECT Quantity, TotalCost, MyCost
FROM @CostTracker
ORDER BY TotalCost DESC;

SELECT DISTINCT Quantity
FROM @CostTracker;

INSERT INTO @CostTracker
VALUES(109, 333.00);

DELETE FROM @CostTracker
WHERE Quantity = 550;

SELECT Quantity, TotalCost * 5 AS TotalCost5
FROM @CostTracker
ORDER BY Quantity DESC;
-- End Declare table variable and access it

-- Get the views within the database
SELECT SCHEMA_NAME(schema_id) AS [Schema], Name
FROM sys.views;

SELECT TOP (30) PERCENT Dept.DepartmentID, Dept.Name
FROM HumanResources.Department AS Dept;

SELECT TOP (2) WITH TIES   -- TIES can only be used with TOP and ORDER BY. Displays matching results to the last result
	FirstName,
	LastName,
	StartDate,
	EndDate
FROM HumanResources.vEmployeeDepartmentHistory AS edh
WHERE edh.StartDate = '2005-07-01'
ORDER BY edh.StartDate;

-- Group By --
-- Get the number of rows for each product ID using the COUNT_BIG  aggregate function
SELECT COUNT_BIG(*) AS [Cnt], [ProductID]	-- Display 1 row for each ProductID
FROM [Sales].[SalesOrderDetail]
GROUP BY [ProductID]
ORDER BY [ProductID];
GO

-- Get the sum of order quantities for each product ID using the SUM aggregate function
SELECT sod.ProductID, SUM(sod.OrderQty) AS OrderQtyByProductID
FROM Sales.SalesOrderDetail AS sod
GROUP BY sod.ProductID
ORDER BY sod.ProductID;

-- Get the Order Qty grouped by ProductID(Primary) and SpecialOfferID(Secondary). 
-- Displays one line for each SpecialOfferID with associated ProductID.
SELECT ProductID, SpecialOfferID, SUM([OrderQty]) AS [OrderQtyByProductID]
FROM Sales.SalesOrderDetail
GROUP BY ProductID, SpecialOfferID
ORDER BY ProductID, SpecialOfferID;

-- Get the Order Qty grouped by SpecialOfferID(Primary) and ProductID(Secondary)
SELECT ProductID,
	   SpecialOfferID,
	   SUM(OrderQty) AS OrderQtyByProductID
FROM Sales.SalesOrderDetail
GROUP BY SpecialOfferID, ProductID 
ORDER BY SpecialOfferID, ProductID;

-- Group one set using GROUPING SETS. 
-- Set 1: Select ProductID, OrderQty and group by ProductID
SELECT sod.ProductID,
	   SUM(sod.OrderQty) AS OrderQtyByProductID
FROM Sales.SalesOrderDetail AS sod
GROUP BY GROUPING SETS((sod.ProductID))
ORDER BY sod.ProductID;

-- Groups two sets using GROUPING SETS.. 
-- Set 1: Select ProductID, OrderQty and group by ProductID
-- Set 2: Select ProductID, SpecialOfferID, OrderQty and group by SpecialOfferID. This set will contain NULL 
-- for ProductID because we are getting a qty for each SpecialOfferID that is made up of many rows with different
-- ProductID's.
SELECT sod.ProductID,
	   sod.SpecialOfferID,
	   SUM(sod.OrderQty) AS OrderQtyByProductID
FROM Sales.SalesOrderDetail AS sod
GROUP BY GROUPING SETS((sod.ProductID), (sod.SpecialOfferID))
ORDER BY sod.ProductID, sod.SpecialOfferID;
-- Output: Grouping by ProductID will output NULL for SpecialOfferID since there are multiple SpecialOfferID's for each ProductID group.
-- Output: Grouping by SpecialOfferID will output NULL for ProductID since there are multiple ProductID's for each SpecialOfferID group.

-- Groups two sets using GROUPING SETS. 
-- Set 1: Select ProductID, SpecialOfferID, OrderQty and group by ProductID and SpecialOfferID
-- Set 2: Select ProductID, SpecialOfferID, OrderQty and group by SpecialOfferID. This set will contain NULL 
-- for ProductID because we are getting a qty for each SpecialOfferID that is made up of many rows with different
-- ProductID's.
SELECT sod.ProductID,
	   sod.SpecialOfferID,
	   SUM(sod.OrderQty) AS OrderQtyByProductID
FROM Sales.SalesOrderDetail AS sod
GROUP BY GROUPING SETS((sod.ProductID, sod.SpecialOfferID), (sod.SpecialOfferID))
ORDER BY sod.ProductID, sod.SpecialOfferID;
-- Output: Grouping by ProductID and SpecialOfferID will not output NULL for for any field.
-- Output: Grouping by SpecialOfferID will output NULL for ProductID since there are multiple ProductID's for each SpecialOfferID group.

SELECT *
FROM Sales.SalesOrderDetail
WHERE ProductID = NULL;

--Practice 2 GROUPING SETS
CREATE TABLE tbl_Employee 
( 
      Employee_Name varchar(25), 
      Region varchar(50), 
      Department varchar(40), 
      sal int,
	  CONSTRAINT UNQ_Employee_sal UNIQUE(sal)
);

INSERT into tbl_Employee
( 
    Employee_Name, 
    Region, 
    Department, 
    sal 
) 
VALUES 
('Shujaat', 'North America', 'Information Technology', 9999), 
('Andrew', 'Asia Pacific', 'Information Technology',  5555), 
('Maria', 'North America', 'Human Resources', 4444), 
('Stephen', 'Middle East & Africa', 'Information Technology', 8889), 
('Stephen', 'Middle East & Africa', 'Human Resources', 8888);

--UPDATE tbl_Employee
--SET SAL = 8889
--WHERE Employee_Name = 'Stephen' AND Department = 'Human Resources';

--ALTER TABLE tbl_Employee
--	ADD CONSTRAINT UNQ_Employee_sal
--	UNIQUE(sal);

SELECT Region, Department, avg(sal) Average_Salary 
from tbl_Employee 
Group BY
      GROUPING SETS 
      ( 
        (Region, Department),   
        (Region), 
        (Department) , 
        ()          
      );

-- Same results as above query
SELECT Region, Department, avg(sal) Average_Salary 
from tbl_Employee 
Group BY 
      CUBE (Region, Department)

DROP TABLE tbl_Employee;
-----------
--  Using IN 
SELECT p.FirstName, p.LastName, e.JobTitle
FROM Person.Person AS p
JOIN HumanResources.Employee AS e
    ON p.BusinessEntityID = e.BusinessEntityID
WHERE e.JobTitle IN ('Design Engineer', 'Tool Designer', 'Marketing Assistant');
GO

--  Using IN with a subquery
SELECT p.FirstName, p.LastName
FROM Person.Person AS p
    JOIN Sales.SalesPerson AS sp
    ON p.BusinessEntityID = sp.BusinessEntityID
WHERE p.BusinessEntityID IN
   (SELECT BusinessEntityID
   FROM Sales.SalesPerson
   WHERE SalesQuota > 250000);
GO
-----------
-- The HAVING clause is like the where clause except that instead of filtering invdividual rows
-- we are filtering groups instead.
SELECT sod.ProductID,
	   sod.SpecialOfferID,
	   SUM(sod.OrderQty) AS OrderQtyByProductID
FROM Sales.SalesOrderDetail AS sod
GROUP BY sod.ProductID, SOD.SpecialOfferID
HAVING SUM(sod.OrderQty) >= 5000
ORDER BY sod.ProductID, SOD.SpecialOfferID;

SELECT sod.ProductID,
	   sod.SpecialOfferID,
	   SUM(sod.OrderQty) AS OrderQtyByProductID
FROM Sales.SalesOrderDetail AS sod
GROUP BY sod.ProductID, SOD.SpecialOfferID
HAVING SUM(sod.SpecialOfferID) IN (1, 2, 3)   -- This should have been applied earlier in a where clause.
ORDER BY sod.ProductID, SOD.SpecialOfferID;

UPDATE HumanResources.Employee 
SET JobTitle = N'Executive'
WHERE NationalIDNumber = '245797967'; --123456789
IF @@ROWCOUNT = 0
PRINT 'Warning: No rows were updated';
GO

--Views
IF OBJECT_ID('vPerson', 'V') IS NOT NULL
	DROP VIEW vPerson;
GO

CREATE VIEW vPerson
AS
SELECT [FirstName], [LastName], [Title]
FROM [Person].[Person]
WHERE Title IS NOT NULL;
GO

SELECT [FirstName], [LastName], [Title]
FROM vPerson;

-- Conversion functions
--PARSE(string_value AS data_type[USING culture])
SELECT PARSE('12/31/2012' AS date) AS YearEndDateUS;

--Error converting this value to en - us
SELECT PARSE('31/12/2012' AS date USING 'en-US') AS YearEndDate;

--This works converting this value to en - GB
SELECT PARSE('31/12/2012' AS date USING 'en-GB') AS YearEndDate;

--TRY_PARSE(string_value AS data_type[USING culture]) from string to date / time and number types
SELECT TRY_PARSE('12/31/2012' AS date) AS YearEndDateUS;

--Returns NULL when attempting to convert this value to en - us
SELECT TRY_PARSE('31/12/2012' AS date USING 'en-US') AS YearEndDate;

--CAST(expression AS data_type[(length)]
	SELECT CAST('12/31/2012' AS date) AS YearEndDate;
--Error converting this value
SELECT CAST('31/12/2012' AS date) AS YearEndDate;
--TRY_CAST(expression AS data_type[(length)]
	SELECT TRY_CAST('12/31/2012' AS date) AS YearEndDate;

--CONVERT(data_type[(length)], expression[, style])
SELECT CONVERT(date, '12/08/2012', 101) AS YearEndDate;

SELECT TRY_CONVERT(date, '12/08/2012', 101) AS YearEndDate;

-- Validating data types
-- ISDATE
DECLARE @Name nvarchar(50) = 'xy14822';
DECLARE @DiscontinuedDate datetime = '12/4/12';

SELECT ISDATE(@Name) AS NameIsDate,
	   ISDATE(@DiscontinuedDate) AS DiscontinuedDateIsDate;
GO

-- ISNUMERIC
DECLARE @Name nvarchar(50) = 'xy14822';
DECLARE @DiscontinuedDate datetime = '12/4/12';
DECLARE @DaysToProcess int = 100;

SELECT ISNUMERIC(@Name) AS NameIsNumeric,
       ISNUMERIC(@DiscontinuedDate) AS DiscontinuedDateIsNumeric,
	   ISNUMERIC(@DaysToProcess) AS DaysToProcessIsNumeric;

-- Creating a local variable with DECLARE/SET syntax.
DECLARE @myid uniqueidentifier
SET @myid = NEWID()
PRINT 'Value of @myid is: '+ CONVERT(varchar(255), @myid);

--------------------------------------------------------------
USE tempdb;

CREATE TABLE Subjects
(
	SubjectID int IDENTITY(1,1) CONSTRAINT PK_Subjects_SubjectID PRIMARY KEY NOT NULL,
	Name nvarchar(30) NOT NULL
);

CREATE TABLE Courses
(
	CourseID int IDENTITY(1,1) CONSTRAINT PK_Courses_CourseID PRIMARY KEY NOT NULL,
	Name nvarchar(30) NOT NULL,
	SubjectID int CONSTRAINT FK_Courses_Subjects_SubjectID FOREIGN KEY REFERENCES Subjects(SubjectID) NOT NULL
);

CREATE TABLE Videos
(
	VideoID int IDENTITY(1,1) CONSTRAINT PK_Videos_VideoID PRIMARY KEY NOT NULL,
	Name nvarchar(30) NOT NULL,
	CourseID int CONSTRAINT FK_Videos_Courses_CourseID FOREIGN KEY REFERENCES Courses(CourseID) NOT NULL
);

INSERT INTO Subjects(Name) values('House Cleaning'), ('Dog Sitting'), ('Car Washing');
INSERT INTO Courses(Name) values('House Cleaning', 'Dog Sitting', 'Car Washing');

DROP TABLE Courses;
DROP TABLE Videos;

--------------------------------------------------------------
-- Practise: Create a default password
DECLARE @DefaultPwd AS Nchar(8);
SET @DefaultPwd = CAST(Left( NEWID(), 8) AS Nchar(8)); 
PRINT N'DefaultPwd is: ' + RTRIM(CAST(@DefaultPwd AS Nchar(8)))
--------------------------------------------------------------
/* The following example inserts all rows from the Contact table from the AdventureWorks2012database 
into a new table called NewContact. The IDENTITY function is used to start identification numbers at 
100 instead of 1 in the NewContact table.
*/
USE AdventureWorks2012;
GO
IF OBJECT_ID (N'Person.NewContact', N'U') IS NOT NULL
    DROP TABLE Person.NewContact;
GO
ALTER DATABASE AdventureWorks2012 SET RECOVERY BULK_LOGGED; -- TO REDUCE LOGGING
GO
SELECT  IDENTITY(smallint, 100, 1) AS ContactNum,
		Title, 
        FirstName AS First,
        LastName AS Last
INTO Person.NewContact
FROM Person.Person
WHERE Title IS NOT NULL;
GO
ALTER DATABASE AdventureWorks2012 SET RECOVERY FULL; -- LOG ALL TRANSACTIONS
GO
SELECT ContactNum, Title, First, Last FROM Person.NewContact;
GO

--------------------------------------------------------------
USE AdventureWorks2012;
GO
EXEC dbo.uspGetEmployeeManagers @BusinessEntityID = 50;

--------------------------------------------------------------
USE AdventureWorks2012;
GO

IF OBJECT_ID ('ProductInfo', 'U') IS NOT NULL
DROP TABLE ProductInfo;
 
CREATE TABLE ProductInfo
(
  ProductID NVARCHAR(10) NOT NULL PRIMARY KEY,
  ProductName NVARCHAR(50) NOT NULL
);
GO
 
INSERT INTO ProductInfo
SELECT ProductID, Name
FROM Production.Product;

SET STATISTICS IO ON;

SELECT ProductID, ProductName
FROM ProductInfo
WHERE ProductID = '350';
-- WHERE ProductID = 350; -- Using an int cause the value of ProductID to undergo an implicit conversion. 
                          -- This forces a table scan rather than a seek.


--------------------------
-- Example to update multiple rows from another table as a source.
update tbl1
set col1 = a.col1, col2 = a.col2, col3 = a.col3
from tbl2 a
where tbl1.Id = 'someid'and a.Id = 'differentid'


 UPDATE TOP(6 )dbo.Notifications
  SET dbo.Notifications.ClientUID = '8F83A36D-BDD3-4B20-8452-C833DC7673BD';
  GO









