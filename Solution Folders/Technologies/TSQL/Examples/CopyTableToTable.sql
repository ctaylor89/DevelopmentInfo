USE TSQL2012;

-- My way to duplicate a row in the HR.Employees table but change the last name
Select * Into #TempEmployee
from HR.Employees
Where lastname Like 'B%';

Select * From #TempEmployee;

Update #TempEmployee
SET lastname = 'Buster'
Where empid = 5;

Insert Into HR.Employees
Select lastname, firstname, title, titleofcourtesy, birthdate, hiredate, address,
       city, region, postalcode, country, phone, mgrid From #TempEmployee
Where lastname = 'Buster';

drop table #TempEmployee
-- Note that an explicit value for the identity column in table 'HR.Employees' can only be specified 
-- when a column list is used and IDENTITY_INSERT is ON.
-- Example:
-- Set Identity insert on so that value can be inserted into this column
-- SET IDENTITY_INSERT YourTable ON
-- https://stackoverflow.com/questions/19155775/how-to-update-identity-column-in-sql-server
----------------------------------------------------
IF OBJECT_ID('dbo.SourceRecords', 'U') IS NOT NULL
DROP TABLE dbo.SourceRecords;

CREATE TABLE dbo.SourceRecords
(
  itemid   INT NOT NULL,
  itemname VARCHAR(30) NOT NULL,
  itemqty  INT NOT NULL
  CONSTRAINT PK_SourceRecords
    PRIMARY KEY(itemid)
);

Insert into dbo.SourceRecords
values
(10, 'Name1', 15),
(20, 'Name2', 25),
(30, 'Name3', 35),
(40, 'Name4', 45),
(50, 'Name5', 55),
(60, 'Name6', 65);

-- Test
select * from dbo.SourceRecords;

IF OBJECT_ID('dbo.TargetRecords', 'U') IS NOT NULL
DROP TABLE dbo.TargetRecords;

CREATE TABLE dbo.TargetRecords
(
  itemid   INT NOT NULL,
  itemname VARCHAR(30) NOT NULL,
  itemqty  INT NOT NULL
  CONSTRAINT PK_TargetRecords
    PRIMARY KEY(itemid)
);

Insert into dbo.TargetRecords
values
(101, 'Name101', 150),
(201, 'Name201', 250),
(301, 'Name301', 350),
(401, 'Name401', 450),
(501, 'Name501', 550),
(601, 'Name601', 650);

-- Test
select * from dbo.TargetRecords;

IF OBJECT_ID('dbo.CrossWalk', 'U') IS NOT NULL
DROP TABLE dbo.CrossWalk;

CREATE TABLE dbo.CrossWalk
(
  sourceitemid   INT NOT NULL,
  targetitemid   INT NOT NULL  
);

insert into dbo.CrossWalk
values
(10, 101),
(20, 201),
(30, 301),
(40, 401),
(50, 501),
(60, 601)

-- Test
select * from dbo.CrossWalk;

declare @itemid_trg INT, @itemname_trg VARCHAR(30), @itemqty INT;

declare cur CURSOR FAST_FORWARD for
	select cw.targetitemid, sr.itemname, sr.itemqty
	from dbo.SourceRecords sr
	join dbo.CrossWalk cw
	on sr.itemid = cw.sourceitemid;

open cur
fetch next from cur into @itemid_trg, @itemname_trg, @itemqty
while @@FETCH_STATUS = 0
begin
	update dbo.TargetRecords
	set itemname = @itemname_trg, itemqty = @itemqty
	where itemid = @itemid_trg

	fetch next from cur into @itemid_trg, @itemname_trg, @itemqty
end
CLOSE cur;
DEALLOCATE cur;
-- Result
select 'Result: ' as  Result, tr.* from dbo.TargetRecords as tr;