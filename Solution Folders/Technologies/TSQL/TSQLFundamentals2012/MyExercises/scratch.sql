-- Write a query that returns for each customer
-- all orders placed on the customer's last day of activity
-- Tables involved: TSQL2012 database, Orders table

select c.custid, c.companyname, o.orderid, o.orderdate, o.empid
from Sales.Orders o
inner join Sales.Customers c
on o.custid = c.custid
where o.orderdate = (
			select MAX(o2.orderdate)
			from Sales.Orders o2
			where o2.custid = o.custid)
order by o.custid;

-- What are the orders that were placed on the customer's last day of activity?
-- List customers and their orders for the last day of activity by that customer.
--  What orders were placed on the last day of activity for each customer

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
---------------------------------------------------------------------------------------------
-- 6
-- Write a query that returns customers
-- who placed orders in 2007 but not in 2008
-- Tables involved: TSQL2012 database, Customers and Orders tables
-- What customer placed orders in 2007 and not in 2008

select custid, companyname
from Sales.Customers c
where exists
		(select *
		 from Sales.orders o
		 where o.orderdate >= '20070101' and o.orderdate < '20080101' and c.custid = o.custid)
	  and not exists
	    (select *
		 from Sales.orders o
		 where o.orderdate >= '20080101' and o.orderdate < '20090101' and c.custid = o.custid);		


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
---------------------------------------------------------------------------------------------
-- 4
-- Write a query that returns
-- countries where there are customers but not employees
-- Tables involved: TSQL2012 database, Customers and Employees tables
-- List countries where there are customers and no employees
--  List customers who's country is not found in employees

select distinct country
from Sales.Customers c
where c.country not in(
		select e.country 
		from HR.Employees e)
order by c.country;



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
-------------------------------------------------------------------------------------
-- 3
-- Write a query that returns employees
-- who did not place orders on or after May 1st, 2008
-- Tables involved: TSQL2012 database, Employees and Orders tables
-- 
-- List employees who did not place orders on or after May 1st, 2008
select empid, firstname + ' ' + lastname as Name 
from hr.Employees e
where not exists(
		select * 
		from Sales.Orders o
		where o.empid = e.empid and (o.orderdate >= '20080501'));

-- Desired output:
empid       FirstName  lastname
----------- ---------- --------------------
3           Judy       Lew
5           Sven       Buck
6           Paul       Suurs
9           Zoya       Dolgopyatova

(4 row(s) affected)
-----------------------------------------------------------------------------------------------
-- 2 (Optional, Advanced)
-- Write a query that returns all orders placed
-- by the customer(s) who placed the highest number of orders
-- * Note: there may be more than one customer
--   with the same number of orders
-- Tables involved: TSQL2012 database, Orders table
-- List all the orders placed by customer(s) who placed the highest number of orders.

select custid, orderid, orderdate, empid	-- Selects orders for the top customer
from Sales.Orders o
where o.custid IN (							-- Select the top customer(s)
		select top 1 with ties o2.custid
		from Sales.Orders o2
		where o2.orderid = 10248      --o.orderid
		group by o2.custid
		order by count(o2.orderid));

select count(*) from Sales.Orders where custid = 71;

-- Desired output:
custid      orderid     orderdate               empid
----------- ----------- ----------------------- -----------
71          10324       2006-10-08 00:00:00.000 9
71          10393       2006-12-25 00:00:00.000 1
71          10398       2006-12-30 00:00:00.000 2
71          10440       2007-02-10 00:00:00.000 4
71          10452       2007-02-20 00:00:00.000 8
71          10510       2007-04-18 00:00:00.000 6
71          10555       2007-06-02 00:00:00.000 6
71          10603       2007-07-18 00:00:00.000 8
71          10607       2007-07-22 00:00:00.000 5
71          10612       2007-07-28 00:00:00.000 1
71          10627       2007-08-11 00:00:00.000 8
71          10657       2007-09-04 00:00:00.000 2
71          10678       2007-09-23 00:00:00.000 7
71          10700       2007-10-10 00:00:00.000 3
71          10711       2007-10-21 00:00:00.000 5
71          10713       2007-10-22 00:00:00.000 1
71          10714       2007-10-22 00:00:00.000 5
71          10722       2007-10-29 00:00:00.000 8
71          10748       2007-11-20 00:00:00.000 3
71          10757       2007-11-27 00:00:00.000 6
71          10815       2008-01-05 00:00:00.000 2
71          10847       2008-01-22 00:00:00.000 4
71          10882       2008-02-11 00:00:00.000 4
71          10894       2008-02-18 00:00:00.000 1
71          10941       2008-03-11 00:00:00.000 7
71          10983       2008-03-27 00:00:00.000 2
71          10984       2008-03-30 00:00:00.000 1
71          11002       2008-04-06 00:00:00.000 4
71          11030       2008-04-17 00:00:00.000 7
71          11031       2008-04-17 00:00:00.000 6
71          11064       2008-05-01 00:00:00.000 1

(31 row(s) affected)
