--http://blog.sqlauthority.com/2008/08/28/sql-server-2008-introduction-to-merge-statement-one-statement-for-insert-update-delete/
--http://msdn.microsoft.com/en-us/library/bb510625.aspx

USE [VehicleManagement]

CREATE TABLE StudentDetails
(
StudentID INTEGER PRIMARY KEY,
StudentName VARCHAR(15)
)
GO

INSERT INTO StudentDetails(
StudentID,
StudentName
)
VALUES(1,'SMITH')
INSERT INTO StudentDetails
VALUES(2,'ALLEN')
INSERT INTO StudentDetails
VALUES(3,'JONES')
INSERT INTO StudentDetails
VALUES(4,'MARTIN')
INSERT INTO StudentDetails
VALUES(5,'JAMES')
GO

CREATE TABLE StudentTotalMarks
(
StudentID INTEGER REFERENCES StudentDetails,
StudentMarks INTEGER
)
GO

INSERT INTO StudentTotalMarks
VALUES(1,230)
INSERT INTO StudentTotalMarks
VALUES(2,255)
INSERT INTO StudentTotalMarks
VALUES(3,200)
GO
/*
In our example we will consider three main conditions while we merge this two tables.
Delete the records whose marks are more than 250.
Update marks and add 25 to each as internals if records exist.
Insert the records if record does not exists.
*/
MERGE StudentTotalMarks AS stm
USING (SELECT StudentID, StudentName FROM StudentDetails) AS sd
ON stm.StudentID = sd.StudentID
WHEN MATCHED AND stm.StudentMarks > 250 THEN DELETE
WHEN MATCHED THEN UPDATE SET stm.StudentMarks += 25
WHEN NOT MATCHED THEN
INSERT(StudentID, StudentMarks)
VALUES(sd.StudentID, 25);
GO 

-- Reset the example
DROP TABLE StudentTotalMarks;
DROP TABLE StudentDetails;



