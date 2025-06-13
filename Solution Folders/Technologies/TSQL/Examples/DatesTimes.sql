-- Convert Datetime To String http://www.sqlservertutorial.net/sql-server-system-functions/convert-datetime-to-string/
-- How to format datetime & date in Sql Server 2005 https://anubhavg.wordpress.com/2009/06/11/how-to-format-datetime-date-in-sql-server-2005/
------------------------------------------------------------------
-- Shows rounding up of the minute value by assigning a time value to a 
-- smalldatetime which has no fractional part.
DECLARE @StartTime time(4) = '12:15:59.9999'; 
DECLARE @RoundedSmalldatetime smalldatetime= @StartTime;
SELECT @StartTime AS '@StartTime', @RoundedSmalldatetime AS '@RoundedSmalldatetime'; 
GO
------------------------------------------------------------------
-- Assigning the current date and time to a datetime and datetime2 variable.
Declare @NowDate datetime;
Declare @NowDate2 datetime2; 
set @NowDate = (SELECT GETDATE());
set @NowDate2 = (SELECT GETDATE());
Print @NowDate							-- Result: Nov 11 2019  8:21AM
Print @NowDate2							-- 2019-11-11 08:21:46.1500000
GO
------------------------------------------------------------------
DECLARE @dt DATETIME2 = '2019-12-31 14:43:35.863';
SELECT 
    CONVERT(VARCHAR(20),@dt,0) s1,		-- Dec 31 2019  2:43PM
    CONVERT(VARCHAR(20),@dt,120) s2;	-- 2019-12-31 14:43:35
GO
------------------------------------------------------------------
-- To remove time part value of datetime. 
select DATEADD(day, DATEDIFF(day, 0, getdate()), 0)		-- The time is still displayed as all zeros.
--or
CONVERT(DATE, getdate())								-- Only the date is displayed 2008-04-03

-- Only the date is displayed 2008-04-01 for each order and the day is the first day of each month
SELECT CONVERT(DATE, DATEADD(month, DATEDIFF(month, 0, orderdate), 0)) AS ordermonth  
FROM Sales.Orders;
------------------------------------------------------------------
-- Get Only Year
SELECT DATEPART(year, GETDATE()) AS 'Year'
-- Get Only Month
SELECT DATEPART(month, GETDATE()) AS 'Month'
-- Get Only hour
SELECT DATEPART(hour, GETDATE()) AS 'Hour'
GO
------------------------------------------------------------------
-- Examples using DATEADD() and DATEDIFF
Declare @CurrentDate datetime2; 
Declare @Date2 datetime2;
Declare @Date3 datetime2; 
Declare @Date4 datetime2;
 
-- Set @CurrentDate with Current Date
set @CurrentDate = (SELECT GETDATE());
-- Set @Date2 with 5 days more than @CurrentDate
set @Date2 = (SELECT DATEADD(day, 5, @CurrentDate))
-- Get The Date Difference
SELECT DATEDIFF(day, @CurrentDate, @Date2) AS DifferenceInDays;

set @Date3 = (SELECT DATEADD(month, 6, @CurrentDate))
SELECT DATEDIFF(month, @CurrentDate, @Date3) AS DifferenceInMonths;

set @Date4 = (SELECT DATEADD(year, 13, @CurrentDate))
SELECT DATEDIFF(year, @CurrentDate, @Date4) AS DifferenceInYears;
---
-- Get the number of years, weeks and days from a start year to the current date
declare @startYear datetime2 = '2005-11-21';
select DATEDIFF(year, @startYear, CURRENT_TIMESTAMP) as 'Year Difference';
select DATEDIFF(week, @startYear, CURRENT_TIMESTAMP) as 'Week Difference';
declare @NumDaysToPresent INT = DATEDIFF(day, '1958-03-07', GETDATE());
select @NumDaysToPresent AS 'Days of my life';
---
SELECT GETDATE();
SELECT DATEADD(hour, 5, GETDATE());
------------------------------------------------------------------
-- Date and time conversions
-- Converting a date value to a datetime2 value. You get a datetime2 with a midnight time component.
DECLARE @MyDate date = '12-21-05';
DECLARE @MyDatetime2 datetime2 = @MyDate;
SELECT @MyDatetime2 AS '@MyDatetime2', @MyDate AS '@MyDate';
---
-- Converting a time value to a datetime2 value. You get a datetime2 with a default time component of 1900-01-01.
DECLARE @MyTime time(4) = '12:10:05.12';			-- time(4) specifies a scale of 4 digits.
DECLARE @MyDatetime2 datetime2 = @MyTime;
SELECT @MyDatetime2 AS '@MyDatetime2', @MyTime AS '@MyTime';
------------------------------------------------------------------
-- Get records based on a particular Date regardless of the time.
-- Return customers with orders placed on Feb 12, 2007 along with their orders
declare @OrderDate datetime2 = DATEADD(day, DATEDIFF(day, 0, '2007-02-12 03:20:00.000'), 0);  -- Specified time is removed
declare @OrderDatePlusOne datetime2 = DATEADD(DAY, 1, @OrderDate)		
select c.custid, c.companyname, o.orderid, o.orderdate
from Sales.Customers c
inner join Sales.Orders o
on c.custid = o.custid
where o.orderdate >= @OrderDate AND o.orderdate < @OrderDatePlusOne;
------------------------------------------------------------------
--Last Day of Previous Month
SELECT DATEADD(second,-1,DATEADD(month, DATEDIFF(month,0,GETDATE()),0))
LastDay_PreviousMonth
----Last Day of Current Month
SELECT DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,GETDATE())+1,0))
LastDay_CurrentMonth
----Last Day of Next Month
SELECT DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,GETDATE())+2,0))
LastDay_NextMonth
------------------------------------------------------------------
-- Format the display of dates and times
FORMAT(value,format[,culture])

-- Example
select o.empid, format(orderdate,'yyyy-MM-dd') as orderdate from Sales.Orders o;

--Options for the date and time formatting.
	--dd - this is day of month from 01-31
	--dddd - this is the day spelled out
	--MM - this is the month number from 01-12
	--MMM - month name abbreviated
	--MMMM - this is the month spelled out
	--yy - this is the year with two digits
	--yyyy - this is the year with four digits
	--hh - this is the hour from 01-12
	--HH - this is the hour from 00-23
	--mm - this is the minute from 00-59
	--ss - this is the second from 00-59
	--tt - this shows either AM or PM
	--d - this is day of month from 1-31 (if this is used on its own it will display the entire date)




