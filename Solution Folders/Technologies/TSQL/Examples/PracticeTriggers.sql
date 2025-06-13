
------------- TRIGGERS ----------------------------
-- Create a trigger that monitors insertions
SET NOCOUNT ON 

CREATE TABLE Source (Sou_ID int IDENTITY, Sou_Desc varchar(10)) 
go 

CREATE TRIGGER tr_Source_INSERT
ON Source 
FOR INSERT 
AS 
PRINT  GETDATE() 
go 
 
INSERT Source (Sou_Desc) VALUES ('Test 1') 
 
 -- Remove table after demo
DROP TABLE dbo.Source;
DROP TRIGGER tr_Source_INSERT;



