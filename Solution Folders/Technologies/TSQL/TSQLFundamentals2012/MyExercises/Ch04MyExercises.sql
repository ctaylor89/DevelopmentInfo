---------------------------------------------------------------------
-- My practice work CT
-- Chapter 04 - Subqueries
---------------------------------------------------------------------
-- Pratice work

if OBJECT_ID('dbo.EmployeeIDs', 'U') IS NOT NULL
begin
	--ALTER TABLE dbo.EmployeeIDs
	--DROP CONSTRAINT PK_EmployeeIDs_empid;   

	drop table dbo.EmployeeIDs;
end
GO

create table dbo.EmployeeIDs(empid INT NOT NULL CONSTRAINT PK_EmployeeIDs_empid PRIMARY KEY);
GO

insert into dbo.EmployeeIDs
select distinct o.empid
from Sales.Orders o
where o.empid % 2 = 0;
GO

select * from dbo.EmployeeIDs;
GO

-- Clean up

delete from dbo.EmployeeIDs
where empid % 2 = 0;
GO
--------------------------------------
-- Scratch

---------------------------------------------------------------------
-- 1 
-- Write a query that returns all orders placed on the last day of
-- activity that can be found in the Orders table
-- Tables involved: TSQL2012 database, Orders table
-- My Solution
select orderid as 'Order ID', CONVERT(DATE, orderdate) as 'Order Date', 
	   custid as 'Customer ID', empid as 'Employee ID'
from Sales.Orders
where orderdate = (select max(o.orderdate) from Sales.Orders o)
order by orderid desc;

select orderid, orderdate, custid, empid
from Sales.Orders 
where orderdate = (select MAX(orderdate) from Sales.Orders)
order by orderid desc;

--Desired output
orderid     orderdate               custid      empid
----------- ----------------------- ----------- -----------
11077       2008-05-06 00:00:00.000 65          1
11076       2008-05-06 00:00:00.000 9           4
11075       2008-05-06 00:00:00.000 68          8
11074       2008-05-06 00:00:00.000 73          7

(4 row(s) affected)

-- 2 (Optional, Advanced)
-- Write a query that returns all orders placed
-- by the customer who placed the highest number of orders
-- * Note: there may be more than one customer with the same number of orders
-- Tables involved: TSQL2012 database, Orders table

-- My Solution
select custid, orderid, orderdate, empid
from Sales.Orders
where custid IN (select top 1 with ties o.custid
					from Sales.Orders o
					group by o.custid
					order by count(o.orderid) desc);
-- Selects from the Orders table where the custid is equal to any of the custid's in the 
-- subquery result set. Think "IS IN" not "IF IN". Where it matches up in the sub-query.

-- My solution
select custid as 'Customer ID', orderid as 'Order ID', CONVERT(DATE, orderdate) as 'Order Date', 
	   empid as 'Employee ID'
from Sales.Orders
where custid IN (select top 1 with ties custid
					from Sales.Orders o
					group by custid
					order by count(o.orderid) desc);
-- Book Solution
SELECT custid, orderid, orderdate, empid
FROM Sales.Orders
WHERE custid IN
  (SELECT TOP (1) WITH TIES O.custid
   FROM Sales.Orders AS O
   GROUP BY O.custid
   ORDER BY COUNT(*) DESC);

-- scratch

-- Desired output:
custid      orderid     orderdate               empid
----------- ----------- ----------------------- -----------
71          10324       2006-10-08 00:00:00.000 9
71          10393       2006-12-25 00:00:00.000 1
71          10398       2006-12-30 00:00:00.000 2
71          10440       2007-02-10 00:00:00.000 4
...
71          10984       2008-03-30 00:00:00.000 1
71          11002       2008-04-06 00:00:00.000 4
71          11030       2008-04-17 00:00:00.000 7
71          11031       2008-04-17 00:00:00.000 6
71          11064       2008-05-01 00:00:00.000 1
(31 row(s) affected)

-- 3
-- Write a query that returns employees who did not place orders on or after May 1st, 2008
-- Tables involved: TSQL2012 database, Employees and Orders tables

-- My Solution
select empid, firstname, lastname
from HR.Employees 
where empid NOT IN
	(select o.empid
	from Sales.Orders o
	where o.orderdate >= '2008-05-01');
--Or
with cte as
(
	select *
	from Sales.Orders o
	where o.orderdate >= '2008-05-01'
)
select e.empid, firstName, lastname
from HR.Employees e
where e.empid NOT IN (select empid from cte)
order by e.empid;

--Book Solution
SELECT empid, FirstName, lastname
FROM HR.Employees
WHERE empid NOT IN						-- NOT IN will exclude everything if there’s a null in the subquery results.
  (SELECT O.empid
   FROM Sales.Orders AS O
   WHERE O.orderdate >= '20080501');

-- Desired output:
empid       FirstName  lastname
----------- ---------- --------------------
3           Judy       Lew
5           Sven       Buck
6           Paul       Suurs
9           Zoya       Dolgopyatova
(4 row(s) affected)

-- 4
-- Write a query that returns
-- countries where there are customers but not employees
-- Tables involved: TSQL2012 database, Customers and Employees tables
--My Solution
select distinct country
from Sales.Customers
where country NOT IN (
	select e.country as 'Countries w/o employees'
	from HR.Employees e)
ORDER BY country asc;
-- or
With empCountries as (select country from HR.Employees)
select distinct country as 'Countries w/o employees'
from Sales.Customers
where country not in (select country from empCountries)
order by country;

--Book Solution
SELECT DISTINCT country
FROM Sales.Customers
WHERE country NOT IN
  (SELECT E.country FROM HR.Employees AS E);

-- Desired output:
country
---------------
Argentina
Austria
Belgium
Brazil
Canada
Denmark
Finland
France
Germany
Ireland
Italy
Mexico
Norway
Poland
Portugal
Spain
Sweden
Switzerland
Venezuela

(19 row(s) affected)

-- 5
-- Write a query that returns for each customer
-- all orders placed on the customer's last day of activity
-- Tables involved: TSQL2012 database, Orders table

--My Solution
select custid, orderid, convert(date, orderdate) as 'Order Date', empid
from Sales.Orders o1
where o1.orderdate = (
	select MAX(o2.orderdate)
	from Sales.Orders o2
	where o1.custid = o2.custid)
order by o1.custid asc;

--Book Solution
SELECT custid, orderid, orderdate, empid
FROM Sales.Orders AS O1
WHERE orderdate =
  (SELECT MAX(O2.orderdate)
   FROM Sales.Orders AS O2
   WHERE O2.custid = O1.custid)
ORDER BY custid;

-- Desired output:
custid      orderid     orderdate               empid
----------- ----------- ----------------------- -----------
1           11011       2008-04-09 00:00:00.000 3
2           10926       2008-03-04 00:00:00.000 4
3           10856       2008-01-28 00:00:00.000 3
4           11016       2008-04-10 00:00:00.000 9
5           10924       2008-03-04 00:00:00.000 3
...
87          11025       2008-04-15 00:00:00.000 6
88          10935       2008-03-09 00:00:00.000 4
89          11066       2008-05-01 00:00:00.000 7
90          11005       2008-04-07 00:00:00.000 2
91          11044       2008-04-23 00:00:00.000 4

(90 row(s) affected)

-- 6
-- Write a query that returns customers
-- who placed orders in 2007 but not in 2008
-- Tables involved: TSQL2012 database, Customers and Orders tables

--My Solution
select c.custid, c.companyname
from Sales.Customers c
where EXISTS
	(select * 
	 from Sales.Orders o
	 where o.orderdate >= '2007-01-01' and o.orderdate < '2008-01-01' and c.custid = o.custid)
AND NOT EXISTS
	(select * 
	 from Sales.Orders o
	 where o.orderdate between '2008-01-01' and '2008-12-31' and c.custid = o.custid)
	 --where o.orderdate >= '2008-01-01' and o.orderdate < '2009-01-01' and c.custid = o.custid)
order by c.custid;

--Book Solution
SELECT custid, companyname
FROM Sales.Customers AS C
WHERE EXISTS
  (SELECT *
   FROM Sales.Orders AS O
   WHERE O.custid = C.custid
     AND O.orderdate >= '20070101'
     AND O.orderdate < '20080101')
  AND NOT EXISTS
  (SELECT *
   FROM Sales.Orders AS O
   WHERE O.custid = C.custid
     AND O.orderdate >= '20080101'
     AND O.orderdate < '20090101');

-- Desired output:
custid      companyname
----------- ----------------------------------------
21          Customer KIDPX
23          Customer WVFAF
33          Customer FVXPQ
36          Customer LVJSO
43          Customer UISOJ
51          Customer PVDZC
85          Customer ENQZT

(7 row(s) affected)

-- 7 (Optional, Advanced)
-- Write a query that returns customers who ordered product 12
-- Tables involved: TSQL2012 database, Customers, Orders and OrderDetails tables
--My Solution
--My Solution(not as good as book but same results)
select distinct c.custid, c.companyname
from Sales.Customers c
--join Sales.orders o			-- because I used a join here, I had to use 'distinct'.
--on c.custid = o.custid
where exists ( 
	select * 
	from Sales.OrderDetails od
	join Sales.Orders o2
	on o2.orderid = od.orderid
	where od.productid = 12 and o2.custid = c.custid);

--Book Solution *Better
SELECT custid, companyname
FROM Sales.Customers AS C
WHERE EXISTS				-- As I sweep through the table I am going to test each record for a true/false condition
  (SELECT *					-- depending on if any records were found in the subquery.
   FROM Sales.Orders AS O
   WHERE O.custid = C.custid
     AND EXISTS
       (SELECT *
        FROM Sales.OrderDetails AS OD
        WHERE OD.orderid = O.orderid
          AND OD.ProductID = 12));


-- Scratch
select *
from Sales.Orders od
where od.productid = 12;

-- Desired output:
custid      companyname
----------- ----------------------------------------
48          Customer DVFMB
39          Customer GLLAG
71          Customer LCOUJ
65          Customer NYUHS
44          Customer OXFRU
51          Customer PVDZC
86          Customer SNXOJ
20          Customer THHDP
90          Customer XBBVR
46          Customer XPNIK
31          Customer YJCBX
87          Customer ZHYOS

(12 row(s) affected)

-- 8 (Optional, Advanced)
-- Write a query that calculates a running total qty
-- for each customer and month using subqueries
-- Tables involved: TSQL2012 database, Sales.CustOrders view

-- My solution
select custid, ordermonth, qty,
	(select sum(o2.qty) as runqty
	 from Sales.CustOrders o2
	 where o2.custid = o.custid 
	   and o2.ordermonth <= o.ordermonth) AS runqty
from Sales.CustOrders o
order by custid, ordermonth; 

-- Book Solution
SELECT custid, ordermonth, qty,
  (SELECT SUM(O2.qty)
   FROM Sales.CustOrders AS O2
   WHERE O2.custid = O1.custid
     AND O2.ordermonth <= O1.ordermonth) AS runqty
FROM Sales.CustOrders AS O1
ORDER BY custid, ordermonth;


-- Desired output:
custid      ordermonth              qty         runqty
----------- ----------------------- ----------- -----------
1           2007-08-01 00:00:00.000 38          38
1           2007-10-01 00:00:00.000 41          79
1           2008-01-01 00:00:00.000 17          96
1           2008-03-01 00:00:00.000 18          114
1           2008-04-01 00:00:00.000 60          174
2           2006-09-01 00:00:00.000 6           6
2           2007-08-01 00:00:00.000 18          24
2           2007-11-01 00:00:00.000 10          34
2           2008-03-01 00:00:00.000 29          63
3           2006-11-01 00:00:00.000 24          24
3           2007-04-01 00:00:00.000 30          54
3           2007-05-01 00:00:00.000 80          134
3           2007-06-01 00:00:00.000 83          217
3           2007-09-01 00:00:00.000 102         319
3           2008-01-01 00:00:00.000 40          359
...

(636 row(s) affected)
