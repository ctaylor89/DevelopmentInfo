SELECT name, type_desc from sys.all_objects WHERE name like '%Address%' order by type_desc;

-- Search for a string within all stored procedures
SELECT *
 FROM sys.procedures
 WHERE OBJECT_DEFINITION(OBJECT_ID) LIKE '%department%'
 
 -- Returns information on table usage. Ex: Ave-Min-Max row size, number of rows, etc.
 dbcc showcontig ('[Notifications].[CustomerFiles2]') with tableresults;