"Conversion_Functions"
"Date_Time"
"GUID_Statements"
"Grouping_Statements"
"Insert_Statements"
"Select_Statements"
"Update_Statements"
"Validation_Statements"
"Variables"
"VIEW_Statements"

"_Statements"
//********************************************  
// "_Statements"
//********************************************

//********************************************  
// "Conversion_Functions"
//********************************************
// PARSE(string_value AS data_type[USING culture])
SELECT PARSE('12/31/2012' AS date) AS YearEndDateUS;

// Error converting this value to en - us
SELECT PARSE('31/12/2012' AS date USING 'en-US') AS YearEndDate;

// This works converting this value to en - GB
SELECT PARSE('31/12/2012' AS date USING 'en-GB') AS YearEndDate;

// TRY_PARSE(string_value AS data_type[USING culture]) from string to date / time and number types
SELECT TRY_PARSE('12/31/2012' AS date) AS YearEndDateUS;

// Returns NULL when attempting to convert this value to en - us
SELECT TRY_PARSE('31/12/2012' AS date USING 'en-US') AS YearEndDate;

// CAST(expression AS data_type[(length)]
	SELECT CAST('12/31/2012' AS date) AS YearEndDate;
// Error converting this value
SELECT CAST('31/12/2012' AS date) AS YearEndDate;
// TRY_CAST(expression AS data_type[(length)]
	SELECT TRY_CAST('12/31/2012' AS date) AS YearEndDate;

// CONVERT(data_type[(length)], expression[, style])
SELECT CONVERT(date, '12/08/2012', 101) AS YearEndDate;

SELECT TRY_CONVERT(date, '12/08/2012', 101) AS YearEndDate;

// Practise: Create a default password
DECLARE @DefaultPwd AS Nchar(8);
SET @DefaultPwd = CAST(Left(NEWID(), 8) AS Nchar(8));
PRINT N'DefaultPwd is: ' + RTRIM(CAST(@DefaultPwd AS Nchar(8))


//********************************************  
// "Date_Time"
//********************************************


//********************************************  
// "GUID_Statements"
//********************************************
// Assign uniqueidentifier in a variable
DECLARE @EmployeeID uniqueidentifier
SET @EmployeeID = NEWID()

// Inserting data in Employees table.
INSERT INTO Employees
(EmployeeID, Name, Phone)
VALUES
(NEWID(), 'John Kris', '99-99999')

//********************************************  
// "Grouping_Statements"
//********************************************
// Get the Order Qty grouped by ProductID(Primary) and SpecialOfferID(Secondary)
SELECT ProductID, SpecialOfferID, SUM([OrderQty]) AS[OrderQtyByProductID]
FROM Sales.SalesOrderDetail
GROUP BY ProductID, SpecialOfferID
ORDER BY ProductID, SpecialOfferID;
// Having clause example
SELECT sod.ProductID,
sod.SpecialOfferID,
SUM(sod.OrderQty) AS OrderQtyByProductID
FROM Sales.SalesOrderDetail AS sod
GROUP BY sod.ProductID, SOD.SpecialOfferID
HAVING SUM(sod.OrderQty) >= 5000
ORDER BY sod.ProductID, SOD.SpecialOfferID;
______________________________________

// Complete example for grouping sets
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
('Andrew', 'Asia Pacific', 'Information Technology', 5555),
('Maria', 'North America', 'Human Resources', 4444),
('Stephen', 'Middle East & Africa', 'Information Technology', 8889),
('Stephen', 'Middle East & Africa', 'Human Resources', 8888);

SELECT Region, Department, avg(sal) Average_Salary
from tbl_Employee
Group BY
	GROUPING SETS
	(
	    (Region, Department),     -- Avg salary for each within each region.department = null
		(Region),                 -- Avg salary for each region
		(Department),             -- Avg salary for each department. region = null
		()                        -- Avg salary for all employees. region = null, department = null
	);
________________________________________________________________

// Get the Order Qty grouped by ProductID(Primary) and SpecialOfferID(Secondary)
SELECT ProductID, SpecialOfferID, SUM([OrderQty]) AS[OrderQtyByProductID]
FROM Sales.SalesOrderDetail
GROUP BY ProductID, SpecialOfferID
ORDER BY ProductID, SpecialOfferID;

// Groups two sets.
// Set 1: Select ProductID, SpecialOfferID, OrderQty and group by ProductID and SpecialOfferID
// Set 2 : Select ProductID, SpecialOfferID, OrderQty and group by SpecialOfferID. This set will contain NULL for 
// ProductID because were getting a qty for each SpecialOfferID that is made up of many rows with different ProductID's.
SELECT sod.ProductID,
sod.SpecialOfferID,
SUM(sod.OrderQty) AS OrderQtyByProductID
FROM Sales.SalesOrderDetail AS sod
GROUP BY GROUPING SETS((sod.ProductID, sod.SpecialOfferID), (sod.SpecialOfferID))
ORDER BY sod.ProductID, sod.SpecialOfferID;

//********************************************  
// "Insert_Statements"
//********************************************
INSERT INTO dbo.Department
VALUES
(2009, 7708, 44.00),
(2019, 7709, 54.00),
(2029, 7718, 144.00);

// Insert from table into table variable
INSERT INTO @CostTracker(Quantity, TotalCost)
SELECT[Quantity], ([Quantity] * [ActualCost])
FROM[Production].[TransactionHistory];

//********************************************  
// "Select_Statements"
//********************************************
-- Total Number of Rows in Table
SELECT COUNT(*) TotalRows
FROM Sales.SalesOrderDetail
 
-- Total Count of Rows Grouped by ORDERQty
SELECT COUNT(*) Cnt, OrderQty
FROM Sales.SalesOrderDetail
GROUP BY OrderQty
ORDER BY OrderQty

-- Example of Top 10 Records
SELECT TOP 10 *
FROM Sales.SalesOrderDetail
ORDER BY OrderQty

-- Example of Top 10 WITH TIES
SELECT TOP 10 WITH TIES *
FROM Sales.SalesOrderDetail
ORDER BY OrderQty

//********************************************  
// "Update_Statements"
//********************************************
UPDATE HumanResources.Employee
SET JobTitle = N'Executive'
WHERE NationalIDNumber = 123456789
IF @@ROWCOUNT = 0
PRINT 'Warning: No rows were updated';

//********************************************  
// "Validation_Statements"
//********************************************
// Validating data types
// ISDATE  returns 0 or 1
DECLARE @Name nvarchar(50) = 'xy14822';
DECLARE @DiscontinuedDate datetime = '12/4/12';

SELECT ISDATE(@Name) AS NameIsDate,
ISDATE(@DiscontinuedDate) AS DiscontinuedDateIsDate;
GO

// ISNUMERIC  returns 0 or 1
DECLARE @Name nvarchar(50) = 'xy14822';
DECLARE @DiscontinuedDate datetime = '12/4/12';
DECLARE @DaysToProcess int = 100;

SELECT ISNUMERIC(@Name) AS NameIsNumeric,
ISNUMERIC(@DiscontinuedDate) AS DiscontinuedDateIsNumeric,
ISNUMERIC(@DaysToProcess) AS DaysToProcessIsNumeric;

//********************************************  
// Variables
//********************************************
http://odetocode.com/articles/365.aspx

// Declare two variables.
DECLARE @FirstNameVariable nvarchar(50), @PostalCodeVariable nvarchar(15);

// Set their values. You can also assign these values using = when declared.
SET @FirstNameVariable = N'Amy';
SET @PostalCodeVariable = N'BA5 3HX';
_____________________________________

// Create a Table Variable
DECLARE @CostTracker TABLE
(
	[Quantity] int NOT NULL,
	[TotalCost] money NOT NULL,
	[MyCost] money NULL
);

// Insert data from TransactionHistory table into Table Variable
INSERT INTO @CostTracker(Quantity, TotalCost)
SELECT Quantity, ([Quantity] * [ActualCost]) AS [TotalCost]
FROM Production.TransactionHistory;

// Select contents of the Table Variable
SELECT Quantity, TotalCost
FROM @CostTracker

// Update a table variable
UPDATE @CostTracker
SET[MyCost] = 777.77
WHERE[Quantity] = 550;

// Delete from a table variable
DELETE FROM @CostTracker
WHERE Quantity = 550;

//********************************************  
// "VIEW_Statements"
//********************************************
IF OBJECT_ID('vPerson', 'V') IS NOT NULL
DROP VIEW vPerson;
GO

CREATE VIEW vPerson
AS
SELECT[FirstName], [LastName], [Title]
FROM[Person].[Person]
WHERE Title IS NOT NULL;
GO

SELECT[FirstName], [LastName], [Title]
FROM vPerson;
__________________________________

