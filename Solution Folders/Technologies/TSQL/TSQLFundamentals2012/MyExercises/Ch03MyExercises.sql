---------------------------------------------------------------------
-- My practice work CT
-- Chapter 03 - Joins
---------------------------------------------------------------------
USE TSQL2012;

select empid, firstname, lastname from HR.Employees
-- 1
-- 1-1
-- Write a query that generates 5 copies out of each employee row
-- Tables involved: TSQL2012 database, Employees and Nums tables
-- My solution
select e.empid, e.firstname, e.lastname, nms.n
from HR.Employees e
join dbo.Nums nms
on nms.n < 6;

-- Book's Solution
SELECT E.empid, E.firstname, E.lastname, N.n
FROM HR.Employees AS E
  CROSS JOIN dbo.Nums AS N	-- notice that it uses a cross join
WHERE N.n <= 5		-- notice that it uses a where clause instead of an ON clause
ORDER BY n, empid;	-- removing this line does not change result

--Desired output
empid       firstname  lastname             n
----------- ---------- -------------------- -----------
1           Sara       Davis                1
2           Don        Funk                 1
3           Judy       Lew                  1
4           Yael       Peled                1
5           Sven       Buck                 1
6           Paul       Suurs                1
7           Russell    King                 1
8           Maria      Cameron              1
9           Zoya       Dolgopyatova         1
1           Sara       Davis                2
2           Don        Funk                 2
3           Judy       Lew                  2
4           Yael       Peled                2
5           Sven       Buck                 2
6           Paul       Suurs                2
7           Russell    King                 2
8           Maria      Cameron              2
9           Zoya       Dolgopyatova         2
1           Sara       Davis                3
2           Don        Funk                 3
3           Judy       Lew                  3
4           Yael       Peled                3
5           Sven       Buck                 3
6           Paul       Suurs                3
7           Russell    King                 3
8           Maria      Cameron              3
9           Zoya       Dolgopyatova         3
1           Sara       Davis                4
2           Don        Funk                 4
3           Judy       Lew                  4
4           Yael       Peled                4
5           Sven       Buck                 4
6           Paul       Suurs                4
7           Russell    King                 4
8           Maria      Cameron              4
9           Zoya       Dolgopyatova         4
1           Sara       Davis                5
2           Don        Funk                 5
3           Judy       Lew                  5
4           Yael       Peled                5
5           Sven       Buck                 5
6           Paul       Suurs                5
7           Russell    King                 5
8           Maria      Cameron              5
9           Zoya       Dolgopyatova         5

(45 row(s) affected)

-- 1-2 (Optional, Advanced)
-- Write a query that returns a row for each employee and day 
-- in the range June 12, 2009 – June 16 2009.
-- Tables involved: TSQL2012 database, Employees and Nums tables

------------------Prac
--My Solution
--declare @JuneDate datetime2 = '06-11-2009';
select e.empid, DATEADD(day, nms.n, '06-11-2009') as dt
from HR.Employees e
cross join dbo.Nums nms
where nms.n <= 5 
Order By e.empid;
GO
--------------------
--Book Solution
SELECT E.empid, DATEADD(day, D.n - 1, '20090612') AS dt
FROM HR.Employees AS E
  CROSS JOIN Nums AS D
WHERE D.n <= DATEDIFF(day, '20090612', '20090616') + 1
ORDER BY empid, dt

--Desired output
empid       dt
----------- -----------------------
1           2009-06-12 00:00:00.000
1           2009-06-13 00:00:00.000
1           2009-06-14 00:00:00.000
1           2009-06-15 00:00:00.000
1           2009-06-16 00:00:00.000
2           2009-06-12 00:00:00.000
2           2009-06-13 00:00:00.000
2           2009-06-14 00:00:00.000
2           2009-06-15 00:00:00.000
2           2009-06-16 00:00:00.000
3           2009-06-12 00:00:00.000
3           2009-06-13 00:00:00.000
3           2009-06-14 00:00:00.000
3           2009-06-15 00:00:00.000
3           2009-06-16 00:00:00.000
4           2009-06-12 00:00:00.000
4           2009-06-13 00:00:00.000
4           2009-06-14 00:00:00.000
4           2009-06-15 00:00:00.000
4           2009-06-16 00:00:00.000
5           2009-06-12 00:00:00.000
5           2009-06-13 00:00:00.000
5           2009-06-14 00:00:00.000
5           2009-06-15 00:00:00.000
5           2009-06-16 00:00:00.000
6           2009-06-12 00:00:00.000
6           2009-06-13 00:00:00.000
6           2009-06-14 00:00:00.000
6           2009-06-15 00:00:00.000
6           2009-06-16 00:00:00.000
7           2009-06-12 00:00:00.000
7           2009-06-13 00:00:00.000
7           2009-06-14 00:00:00.000
7           2009-06-15 00:00:00.000
7           2009-06-16 00:00:00.000
8           2009-06-12 00:00:00.000
8           2009-06-13 00:00:00.000
8           2009-06-14 00:00:00.000
8           2009-06-15 00:00:00.000
8           2009-06-16 00:00:00.000
9           2009-06-12 00:00:00.000
9           2009-06-13 00:00:00.000
9           2009-06-14 00:00:00.000
9           2009-06-15 00:00:00.000
9           2009-06-16 00:00:00.000

(45 row(s) affected)

-- 2
-- Return US customers, and for each customer the total number of orders and total quantities.
-- Tables involved: TSQL2012 database, Customers, Orders and OrderDetails tables.
-- * This query returns 22 orders for custid 32 and not the expected 11 count if I don't use distinct.
--   Without Distinct count returns the count of all orders details for the custid. I expect it to return the count
--   of all orders within the grouping.

-- My test and experimentation
select c.custid, count(distinct o.orderid), sum(od.qty) as 'Total Qty', max(od.qty) as 'Max Value'
from Sales.Customers c
join Sales.Orders o
on c.custid = o.custid
join Sales.OrderDetails od
on o.orderid = od.orderid
where c.country = N'USA'
group by c.custid
order by 'Total Qty' desc;

-- Solution
select c.custid, count(distinct o.orderid) countnumorders, sum(od.qty) 'Total Qty'
from Sales.customers c
join Sales.Orders o
on c.custid = o.custid
join Sales.OrderDetails od
on o.orderid = od.orderid
where c.country = N'USA'
group by c.custid
order by c.custid;

-- Debug
select c.custid, count(distinct o.orderid) numorders, count(od.orderid) numorderdetails
from Sales.customers c
join Sales.Orders o
on c.custid = o.custid
join Sales.OrderDetails od		-- Joining OrderDetails with Orders will produce an orderid for each OrderDetail into 
on o.orderid = od.orderid		-- the result set for a particular orderid. The COUNT then counts the orderids in the 
where o.custid = 32				-- result set, not the Orders table.
group by c.custid;

--Desired output
custid      numorders   totalqty
----------- ----------- -----------
32          11          345
36          5           122
43          2           20
45          4           181
48          8           134
55          10          603
65          18          1383
71          31          4958
75          9           327
77          4           46
78          3           59
82          3           89
89          14          1063
(13 row(s) affected)

-- 3
-- Return customers(custid and companyname) and their orders(orderid and orderdate) including customers who placed no orders
-- Tables involved: TSQL2012 database, Customers and Orders tables

select c.custid, c.companyname, o.orderid, o.orderdate
from Sales.Customers c
left join Sales.Orders o
on c.custid = o.custid
order by c.custid;

-- Desired output
custid      companyname     orderid     orderdate
----------- --------------- ----------- ------------------------
85          Customer ENQZT  10248       2006-07-04 00:00:00.000
79          Customer FAPSM  10249       2006-07-05 00:00:00.000
34          Customer IBVRG  10250       2006-07-08 00:00:00.000
84          Customer NRCSK  10251       2006-07-08 00:00:00.000
...
73          Customer JMIKW  11074       2008-05-06 00:00:00.000
68          Customer CCKOT  11075       2008-05-06 00:00:00.000
9           Customer RTXGC  11076       2008-05-06 00:00:00.000
65          Customer NYUHS  11077       2008-05-06 00:00:00.000
22          Customer DTDMN  NULL        NULL
57          Customer WVAXS  NULL        NULL

(832 row(s) affected)

-- 4
-- Return customers who placed no orders
-- Tables involved: TSQL2012 database, Customers and Orders tables(custid, companyname

select c.custid, c.companyname, o.orderid
from Sales.Customers c
left join Sales.Orders o		-- have to left join this
on c.custid = o.custid
where o.custid is null;			-- use 'is null' not '= null'

-- Desired output
custid      companyname
----------- ---------------
22          Customer DTDMN
57          Customer WVAXS
(2 row(s) affected)

-- 5
-- Return customers with orders placed on Feb 12, 2007 along with their orders
-- Tables involved: TSQL2012 database, Customers and Orders tables
-- My solution
declare @OrderDate datetime2 = DATEADD(day, DATEDIFF(day, 0, '2007-02-12 03:20:00.000'), 0);
declare @OrderDatePlusOne datetime2 = DATEADD(DAY, 1, @OrderDate)
select c.custid, c.companyname, o.orderid, o.orderdate
from Sales.Customers c
inner join Sales.Orders o
on c.custid = o.custid
where o.orderdate >= @OrderDate AND o.orderdate < @OrderDatePlusOne;

-- Desired output
custid      companyname     orderid     orderdate
----------- --------------- ----------- -----------------------
66          Customer LHANT  10443       2007-02-12 00:00:00.000
5           Customer HGVLZ  10444       2007-02-12 00:00:00.000
(2 row(s) affected)
-- Additional Notes. Some examples inspired by this solution.
Use DATEDIFF to get the number of days to the given date. Can also use months, years, weeks, hours, minutes, seconds etc.
	Declare @dayCount int = DATEDIFF(day, 0, '20070212');

Use DATEADD to add 2 days to @dayCount. day is the date part being the unit of measurement.
	Declare @datePlusTwoDays DateTime2 = DATEADD(day, 2, @dayCount);

Use DATEDIFF to get the number of days to the given date. Then add those days to 1 day.
	Declare @datePlusOneDay DateTime2 = DATEADD(day, 1, DATEDIFF(day, 0, '20070212'));

Select CONVERT(date, @datePlusOneDay) 'datePlusOneDay', 
	@dayCount 'dateCount', CONVERT(date, @datePlusTwoDays) 'datePlusTwoDays';

-- 6 (Optional, Advanced)
-- Return customers and company name, with orders placed on Feb 12, 2007 along with their orders
-- Also return customers who didn't place orders on Feb 12, 2007 
-- Tables involved: TSQL2012 database, Customers and Orders tables

-- My solution. Note that filtering is done in the ON clause. Otherwise the where clause would filter out the NULL values
select c.custid, c.companyname, o.orderid, o.orderdate
from Sales.Customers c
left join Sales.Orders o
on c.custid = o.custid AND (o.orderdate >= '2007-02-12' and o.orderdate < DATEADD(day, 1, DATEDIFF(day, 0, '2007-02-12')));

-- Desired output
custid      companyname     orderid     orderdate
----------- --------------- ----------- -----------------------
72          Customer AHPOP  NULL        NULL
58          Customer AHXHT  NULL        NULL
25          Customer AZJED  NULL        NULL
18          Customer BSVAR  NULL        NULL
91          Customer CCFIZ  NULL        NULL
...
33          Customer FVXPQ  NULL        NULL
53          Customer GCJSG  NULL        NULL
39          Customer GLLAG  NULL        NULL
16          Customer GYBBY  NULL        NULL
4           Customer HFBZG  NULL        NULL
5           Customer HGVLZ  10444       2007-02-12 00:00:00.000
42          Customer IAIJK  NULL        NULL
34          Customer IBVRG  NULL        NULL
63          Customer IRRVL  NULL        NULL
73          Customer JMIKW  NULL        NULL
15          Customer JUWXK  NULL        NULL
...
21          Customer KIDPX  NULL        NULL
30          Customer KSLQF  NULL        NULL
55          Customer KZQZT  NULL        NULL
71          Customer LCOUJ  NULL        NULL
77          Customer LCYBZ  NULL        NULL
66          Customer LHANT  10443       2007-02-12 00:00:00.000
38          Customer LJUCA  NULL        NULL
59          Customer LOLJO  NULL        NULL
36          Customer LVJSO  NULL        NULL
64          Customer LWGMD  NULL        NULL
29          Customer MDLWA  NULL        NULL
...

(91 row(s) affected)

-- 7 (Optional, Advanced)
-- Return all customers, and for each return a Yes/No value
-- depending on whether the customer placed an order on Feb 12, 2007
-- Tables involved: TSQL2012 database, Customers and Orders tables

-- My Solution
select c.custid, c.companyname,
	case 
		when o.orderdate = '2007-02-12' then 'Yes' 
		else 'No' 
	end as HasOrderOn20070212
from Sales.Customers c
left join Sales.Orders o
on c.custid = o.custid and o.orderdate = '2007-02-12'
order by c.custid;
-- Notes
-- There are only 2 records that are 'Yes'. If you make the join an inner join, only 2 records will be returned.
-- The left join returns all custid's and null values for the right table rows that do not have a '20070212' date.
-- If you put the date condition in a Where clause instead of the On clause, the return records will be filtered
-- down to 2 records that contain the desired date.

-- Solution
SELECT DISTINCT C.custid, C.companyname, 
  CASE WHEN O.orderid IS NOT NULL THEN 'Yes' ELSE 'No' END AS [HasOrderOn20070212]
FROM Sales.Customers AS C
  LEFT OUTER JOIN Sales.Orders AS O
    ON O.custid = C.custid
    AND O.orderdate = '20070212';

-- My solution
Select c.custid, c.companyname, 
	case
		when exists (Select * from Sales.Orders os where os.orderdate = '20070212' 
														  and os.custid = c.custid)
		then 'Yes' else 'No'
		end as HasOrderOn20070212
from Sales.Customers c;

-- Desired output
custid      companyname     HasOrderOn20070212
----------- --------------- ------------------
1           Customer NRZBB  No
2           Customer MLTDN  No
3           Customer KBUDE  No
4           Customer HFBZG  No
5           Customer HGVLZ  Yes
6           Customer XHXJV  No
7           Customer QXVLA  No
8           Customer QUHWH  No
9           Customer RTXGC  No
10          Customer EEALV  No
...

(91 row(s) affected)