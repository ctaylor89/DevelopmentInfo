-- http://blog.sqlauthority.com/2008/09/08/sql-server-%E2%80%93-2008-creating-primary-key-foreign-key-and-default-constraint/
USE [VehicleManagement]

-- Column Level create primary key
CREATE TABLE Products
(
ProductID INT NOT NULL IDENTITY (1,1) CONSTRAINT pk_products_pid PRIMARY KEY,
ProductName VARCHAR(25)
);

-- Create Table Statement to create Foreign Key
CREATE TABLE ProductSales
(
SalesID INT NOT NULL IDENTITY (3,5) CONSTRAINT pk_productSales_sid PRIMARY KEY,
ProductID INT CONSTRAINT fk_productSales_pid FOREIGN KEY REFERENCES Products(ProductID),
SalesPerson VARCHAR(25)
);

-- Populate the tables
INSERT INTO Products(ProductName) VALUES('Product1');
INSERT INTO Products(ProductName) VALUES('Product2');
INSERT INTO Products(ProductName) VALUES('Product3');
INSERT INTO Products(ProductName) VALUES('Product4');

INSERT INTO ProductSales(ProductID, SalesPerson) VALUES(1, 'Sammy');
INSERT INTO ProductSales(ProductID, SalesPerson) VALUES(1, 'Dorothy');
INSERT INTO ProductSales(ProductID, SalesPerson, SalesPersonNickName) VALUES(1, 'Robert', 'Bob');

-- Gets the product id based on the product name and then inserts product id and sales person name into ProductSales table.
DECLARE @ProductId int;
set @ProductId = (SELECT ProductID FROM Products WHERE ProductName = 'Product3');
INSERT INTO ProductSales(ProductID, SalesPerson) VALUES (@ProductId, 'GWEN');
GO

-- Next two Violates FK constraint
INSERT INTO ProductSales(ProductID, SalesPerson) VALUES(88, 'Bobby');
DELETE FROM Products WHERE ProductID = 1;

SELECT ProductID, ProductName FROM Products;
SELECT SalesID, ProductID, SalesPerson, SalesPersonNickName FROM ProductSales;

DROP TABLE ProductSales;
DROP TABLE Products;

/*
-- Table Level create primary key
CREATE TABLE Products
(
ProductID INT,
ProductName VARCHAR(25)
CONSTRAINT pk_products_pid PRIMARY KEY(ProductID)
);

-- Table Level primary and foreign key
CREATE TABLE ProductSales
(
SalesID INT,
ProductID INT,
SalesPerson VARCHAR(25)
CONSTRAINT pk_productSales_sid PRIMARY KEY CLUSTERED(SalesID),
CONSTRAINT fk_productSales_pid FOREIGN KEY(ProductID) REFERENCES Products(ProductID)
);


-- Alter Table Statement to create Primary Key
ALTER TABLE Products
ADD CONSTRAINT pk_products_pid PRIMARY KEY(ProductID)

-- Alter Statement to Drop Primary key
ALTER TABLE Products
DROP CONSTRAINT pk_products_pid;
*/

-- Alter Statement to add a column and then add a default constraint
ALTER TABLE ProductSales
ADD SalesPersonNickName nvarchar(20); 

ALTER TABLE ProductSales
ADD CONSTRAINT df_salesperson_nickname DEFAULT N'Not known' FOR SalesPersonNickName;

-- Update values in existing rows that are currently NULL
UPDATE ProductSales
SET SalesPersonNickName = N'Not known' WHERE SalesPersonNickName IS NULL;

-- Remove row that has NULL for ProductID
DELETE FROM ProductSales WHERE ProductID IS NULL;
