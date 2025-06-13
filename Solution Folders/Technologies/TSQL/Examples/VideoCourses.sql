--http://blog.sqlauthority.com/2008/09/08/sql-server-%E2%80%93-2008-creating-primary-key-foreign-key-and-default-constraint/
USE [VehicleManagement]

CREATE TABLE Courses(
CourseId INT CONSTRAINT pk_courses_pid PRIMARY KEY,
CourseName nvarchar(20),
-- Table level primary key
--CONSTRAINT pk_courses_pid PRIMARY KEY(CourseId)
);

CREATE TABLE Subects(
SubjectId INT CONSTRAINT pk_Subjects_pid PRIMARY KEY,
SubjectName nvarchar(20),
-- Table level primary key
--CONSTRAINT pk_courses_pid PRIMARY KEY(SubjectId)
);

CREATE TABLE Videos(
VideoId INT CONSTRAINT pk_Videos_pid PRIMARY KEY,
VideoName nvarchar(20),
-- Table level primary key
--CONSTRAINT pk_courses_pid PRIMARY KEY(VideoId)
);

