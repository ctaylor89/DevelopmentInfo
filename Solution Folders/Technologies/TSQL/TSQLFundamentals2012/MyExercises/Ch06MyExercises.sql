---------------------------------------------------------------------
-- Microsoft SQL Server 2012 T-SQL Fundamentals
-- Chapter 06 - Set Operators
-- MyExercises
---------------------------------------------------------------------
-- 1
-- Write a query that generates a virtual auxiliary table of 10 numbers in the range 1 through 10
-- Tables involved: no table
select n
from (VALUES(1),(2),(3),(4),(5),(6),(7),(8),(9),(10)) as Nums(n);

--Desired output
n
-----------
1
2
3
4
5
6
7
8
9
10

(10 row(s) affected)

-- 2
-- Write a query that returns customer and employee pairs 
-- that had order activity in January 2008 but not in February 2008
-- Tables involved: TSQL2012 database, Orders table
-- Note: There is no difference between Oracle MINUS and SQL Server EXCEPT
-- My solution *Returns 5 more rows than book solution
select custid, empid
from Sales.Orders
where orderdate in (select orderdate 
			from Sales.Orders
			where orderdate >= '2008-01-01' AND orderdate < '2008-02-01')
	and orderdate not in (select orderdate 
			from Sales.Orders
			where orderdate >= '2008-02-01' AND orderdate < '2008-03-01')
order by custid asc;

-- Book solution
SELECT custid, empid
FROM Sales.Orders
WHERE orderdate >= '20080101' AND orderdate < '20080201'
 EXCEPT
SELECT custid, empid
FROM Sales.Orders
WHERE orderdate >= '20080201' AND orderdate < '20080301';
--Desired output
custid      empid
----------- -----------
1           1
3           3
5           8
5           9
6           9
7           6
9           1
12          2
16          7
17          1
20          7
24          8
25          1
26          3
32          4
38          9
39          3
40          2
41          2
42          2
44          8
47          3
47          4
47          8
49          7
55          2
55          3
56          6
59          8
63          8
64          9
65          3
65          8
66          5
67          5
70          3
71          2
75          1
76          2
76          5
80          1
81          1
81          3
81          4
82          6
84          1
84          3
84          4
88          7
89          4

(50 row(s) affected)

-- 3
-- Write a query that returns customer and employee pairs 
-- that had order activity in both January 2008 and February 2008
-- Tables involved: TSQL2012 database, Orders table

--Desired output
custid      empid
----------- -----------
20          3
39          9
46          5
67          1
71          4

(5 row(s) affected)

-- 4
-- Write a query that returns customer and employee pairs 
-- that had order activity in both January 2008 and February 2008
-- but not in 2007
-- Tables involved: TSQL2012 database, Orders table

--Desired output
custid      empid
----------- -----------
67          1
46          5

(2 row(s) affected)

-- 5 (Optional, Advanced)
-- You are given the following query:
SELECT country, region, city
FROM HR.Employees

UNION ALL

SELECT country, region, city
FROM Production.Suppliers;

-- You are asked to add logic to the query 
-- such that it would guarantee that the rows from Employees
-- would be returned in the output before the rows from Suppliers,
-- and within each segment, the rows should be sorted
-- by country, region, city
-- Tables involved: TSQL2012 database, Employees and Suppliers tables

--Desired output
country         region          city
--------------- --------------- ---------------
UK              NULL            London
UK              NULL            London
UK              NULL            London
UK              NULL            London
USA             WA              Kirkland
USA             WA              Redmond
USA             WA              Seattle
USA             WA              Seattle
USA             WA              Tacoma
Australia       NSW             Sydney
Australia       Victoria        Melbourne
Brazil          NULL            Sao Paulo
Canada          Qu�bec          Montr�al
Canada          Qu�bec          Ste-Hyacinthe
Denmark         NULL            Lyngby
Finland         NULL            Lappeenranta
France          NULL            Annecy
France          NULL            Montceau
France          NULL            Paris
Germany         NULL            Berlin
Germany         NULL            Cuxhaven
Germany         NULL            Frankfurt
Italy           NULL            Ravenna
Italy           NULL            Salerno
Japan           NULL            Osaka
Japan           NULL            Tokyo
Netherlands     NULL            Zaandam
Norway          NULL            Sandvika
Singapore       NULL            Singapore
Spain           Asturias        Oviedo
Sweden          NULL            G�teborg
Sweden          NULL            Stockholm
UK              NULL            London
UK              NULL            Manchester
USA             LA              New Orleans
USA             MA              Boston
USA             MI              Ann Arbor
USA             OR              Bend

(38 row(s) affected)
