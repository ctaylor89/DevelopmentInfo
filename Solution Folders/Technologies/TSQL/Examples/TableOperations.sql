-- DDL Data Definition Language
--http://blog.sqlauthority.com/2008/09/08/sql-server-%E2%80%93-2008-creating-primary-key-foreign-key-and-default-constraint/
USE [VehicleManagement]
GO

/****** Object:  Table [dbo].[dbo.Employees]    Script Date: 2/14/2014 3:56:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Table level primary key constraint
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [nchar](10) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[HireDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

-- Drop the table
DROP TABLE [dbo].[dbo.Employees];

-- Add new column
ALTER TABLE [dbo].[Employees]
ADD VehicleID INT NULL;

-- Alter column. Set to NOT NULL
ALTER TABLE [dbo].[Employees]
ALTER COLUMN VehicleID INT NOT NULL;

-- Update column with default
UPDATE [dbo].[Employees]
SET VehicleID = 0;

-- Add a foreign key to an existing table. Set name as FK_ParentTable_ChildTable_ColumnName. Mix column name is different in each table.
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT fk_Employees_Vehicles_VehicleIDId
FOREIGN KEY(VehicleID) REFERENCES Vehicles(Id);

