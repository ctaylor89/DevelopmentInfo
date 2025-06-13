USE TSQL2012;

-- Ex 1
-- Return orders placed in June 2007
SELECT orderid, orderdate, custid, empid FROM Sales.Orders WHERE orderdate >= '20070601' AND orderdate < '20070701';

-- Ex 2
-- Return orders placed on the last day of the month
SELECT orderid, orderdate, custid, empid 
FROM Sales.Orders 
WHERE orderdate = DATEADD(dd, -DAY(DATEADD(m,1,orderdate)), DATEADD(m,1,orderdate));
-- OR
SELECT orderid, orderdate, custid, empid 
FROM Sales.Orders 
WHERE orderdate = EOMONTH(orderdate);

--EX 3
-- Return employees with last name containing the letter 'a' twice or more
-- Tables involved: HR.Employees table
SELECT empid, firstname, lastname
FROM HR.Employees
WHERE lastname like '%a%a%';

--EX 4
-- Return orders with total value(qty*unitprice) greater than 10000
-- sorted by total value
-- Tables involved: Sales.OrderDetails table
SELECT orderid, SUM(unitprice * qty) totalvalue
FROM Sales.OrderDetails
GROUP BY orderid
HAVING SUM(unitprice * qty) > 10000
ORDER BY totalvalue DESC;

--Ex 5
-- Return the three ship countries with the highest average freight in 2007
-- Tables involved: Sales.Orders table

-- Desired output:
shipcountry     avgfreight
--------------- ---------------------
Austria         178.3642
Switzerland     117.1775
Sweden          105.16

SELECT shipcountry, AVG(freight) as avgfreight
FROM Sales.Orders
WHERE orderdate >= '2007-01-01' AND orderdate < '2008-01-01'
Group BY shipcountry
ORDER BY avgfreight DESC
OFFSET 0 ROWS FETCH NEXT 3 ROWS ONLY;

-- 6 
-- Calculate row numbers for orders
-- based on order date ordering (using order id as tiebreaker)
-- for each customer separately
-- Tables involved: Sales.Orders table

-- Desired output:
custid      orderdate               orderid     rownum
----------- ----------------------- ----------- --------------------
1           2007-08-25 00:00:00.000 10643       1
1           2007-10-03 00:00:00.000 10692       2
1           2007-10-13 00:00:00.000 10702       3
1           2008-01-15 00:00:00.000 10835       4
1           2008-03-16 00:00:00.000 10952       5
1           2008-04-09 00:00:00.000 11011       6
2           2006-09-18 00:00:00.000 10308       1
2           2007-08-08 00:00:00.000 10625       2
2           2007-11-28 00:00:00.000 10759       3
2           2008-03-04 00:00:00.000 10926       4
...

(830 row(s) affected)

select custid, orderdate, orderid,
	ROW_NUMBER() Over (PARTITION BY custid ORDER BY orderdate, orderid) AS rownum
from Sales.Orders;

-- 7
-- Figure out and return for each employee the gender based on the title of courtesy
-- Ms., Mrs. - Female, Mr. - Male, Dr. - Unknown
-- Tables involved: HR.Employees table

-- Desired output:
empid       firstname  lastname             titleofcourtesy           gender
----------- ---------- -------------------- ------------------------- -------
1           Sara       Davis                Ms.                       Female 
2           Don        Funk                 Dr.                       Unknown
3           Judy       Lew                  Ms.                       Female 
4           Yael       Peled                Mrs.                      Female 
5           Sven       Buck                 Mr.                       Male   
6           Paul       Suurs                Mr.                       Male   
7           Russell    King                 Mr.                       Male   
8           Maria      Cameron              Ms.                       Female 
9           Zoya       Dolgopyatova         Ms.                       Female 

(9 row(s) affected)

select empid, firstname, lastname, titleofcourtesy,
	case titleofcourtesy
		when 'Ms.' then 'Female'
		when 'Mr.' then 'Male'
		when 'Mrs.' then 'Female'
		else 'Unknown'
	end as gender
from HR.Employees;	
	 
-- 8 (advanced, optional)
-- Return for each customer the customer ID and region
-- sort the rows in the output by region
-- having NULLs sort last (after non-NULL values)
-- Note that the default in T-SQL is that NULL sorts first
-- Tables involved: Sales.Customers table

-- Desired output:
custid      region
----------- ---------------
55          AK
10          BC
42          BC
45          CA
37          Co. Cork
33          DF
71          ID
38          Isle of Wight
46          Lara
78          MT
...
1           NULL
2           NULL
3           NULL
4           NULL

SELECT custid, region
FROM Sales.Customers
ORDER BY case when region is NULL then 1 else 0 end, region;
