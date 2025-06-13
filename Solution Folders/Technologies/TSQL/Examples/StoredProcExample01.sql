USE AdventureWorks2012;
GO
select BusinessEntityID Title, FirstName, LastName
from Person.Person
where Title = 'Mr.';

----------------------------
-- Create proc to get persons
IF OBJECT_ID('dbo.GetPerson', 'P') IS NOT NULL
	DROP PROC dbo.GetPerson;
GO

CREATE PROCEDURE dbo.GetPerson
@Key int
AS
BEGIN	
	SET NOCOUNT ON;
	--SELECT BusinessEntityID, Title, FirstName, LastName
	SELECT *
	FROM Person.Person WITH (NOLOCK)
	WHERE BusinessEntityID = @Key;
END;
GO

----------------------------
-- Call GetPerson proc
Exec dbo.GetPerson @Key = 139;

----------------------------
--Create proc to call proc dbo.GetPerson
IF OBJECT_ID('dbo.GetPersonInfo', 'P') IS NOT NULL
	DROP PROC dbo.GetPersonInfo;
GO

CREATE PROCEDURE dbo.GetPersonInfo
@IdKey int
AS
BEGIN		 
	EXEC dbo.GetPerson @Key = @IdKey;
END;
GO

----------------------------
-- Call GetPerson proc
Exec dbo.GetPersonInfo @IdKey = 139;

-- Test
SELECT BusinessEntityID, Title, FirstName, LastName
	FROM (dbo.GetPerson @Key = 139);