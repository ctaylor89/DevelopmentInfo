CREATE DATABASE AdventureWorks2012
ON (FILENAME = 'C:\Users\Databases\AdventureWorksLT2012_Data.mdf')
FOR ATTACH_REBUILD_LOG ;

exec sp_configure 'user instances enabled', 1.
Go
Reconfigure