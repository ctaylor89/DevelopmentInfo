-- http://stackoverflow.com/questions/12708579/foreignkey-referencing-same-table

USE master;

IF DB_ID('PractiseQuerys') IS NOT NULL DROP DATABASE PracticeQuerys;

CREATE DATABASE PracticeQuerys;
GO

-- If database could not be created due to open connections, abort
IF @@ERROR = 3702 
   RAISERROR('Database cannot be dropped because there are still open connections.', 127, 127) WITH NOWAIT, LOG;


USE PracticeQuerys;
GO

CREATE SCHEMA People AUTHORIZATION dbo;
GO

CREATE TABLE People.Person
(
	id int Identity(1,1),
	name nvarchar(40) NOT NULL,
	dob Date NOT NULL,
	mother_id int NULL,
	father_id int NULL,
	CONSTRAINT PK_Person_id PRIMARY KEY(id),
	CONSTRAINT Fk_Person_mother_id_Person_id FOREIGN KEY(mother_id) 
	REFERENCES People.Person(id),
	CONSTRAINT PK_Person_father_id_Person_id FOREIGN KEY(father_id)
	REFERENCES People.Person(id)	
);

INSERT INTO People.Person
VALUES
(N'Person_8', '19850316', NULL, NULL),
(N'Person_1', '19850316', NULL, NULL),
(N'Person_2', '19850316', NULL, NULL),
(N'Person_3', '19850316', NULL, NULL),
(N'Person_4', '19850316', NULL, NULL),
(N'Person_5', '19850316', NULL, NULL),
(N'Person_6', '19850316', NULL, NULL);

UPDATE People.Person
SET mother_id = 9 WHERE name = 'Person_1';
UPDATE People.Person
SET mother_id = 5 WHERE name = 'Person_2';
UPDATE People.Person
SET mother_id = 6 WHERE name = 'Person_3';

UPDATE People.Person
SET mother_id = 1 WHERE name = 'Person_4';
UPDATE People.Person
SET mother_id = 2 WHERE name = 'Person_5';
UPDATE People.Person
SET mother_id = 3 WHERE name = 'Person_6';

UPDATE People.Person
SET father_id = 4 WHERE name = 'Person_1';
UPDATE People.Person
SET father_id = 5 WHERE name = 'Person_2';
UPDATE People.Person
SET father_id = 6 WHERE name = 'Person_3';
UPDATE People.Person
SET father_id = 1 WHERE name = 'Person_4';
UPDATE People.Person
SET father_id = 2 WHERE name = 'Person_5';
UPDATE People.Person
SET father_id = 3 WHERE name = 'Person_6';

SELECT * 
FROM People.Person
WHERE name = 'pErson_1';          -- SQL Server is case insensitive

-- Select all who are mothers. Returns a sub-set of rows that have an id that exists somewhere in the column mother_id.
-- Any row that has a mother_id(refs the child) is guaranteed to have a valid child because of the FK constraint.
SELECT p.* 
FROM People.Person AS p
JOIN People.Person as m
ON p.id = m.mother_id;       -- create a subset of rows from this table where this condition is true

SELECT * 
FROM People.Person;

-- select those children who have a mother and father
SELECT * 
FROM People.Person
WHERE mother_id IS NOT NULL AND father_id IS NOT NULL;

SELECT * 
FROM People.Person;

-- Select those children who are children of 'Person_1' and 'Person_2
SELECT p.* 
FROM People.Person AS p
JOIN People.Person as m ON p.id = m.mother_id
JOIN People.Person as f ON p.id = f.father_id
WHERE m.name = 'Person_1' AND f.name = 'Person_2';



