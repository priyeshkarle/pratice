CREATE DATABASE MyApps
GO
USE MyApps

GO
CREATE TABLE GlobalUsers
(ID			uniqueidentifier	PRIMARY KEY
,Username	nvarchar(20)		NOT NULL
,Password	nvarchar(20)		NOT NULL
,Name		nvarchar(250)		NOT NULL
,Token		uniqueidentifier	UNIQUE
,IsActive	bit					NOT NULL DEFAULT 1)
GO

CREATE TABLE Tasks
(ID			uniqueidentifier	PRIMARY KEY
,Title		nvarchar(250)		NOT NULL
,DueDate	datetime			NOT NULL DEFAULT GETDATE()
,Priority	nvarchar(20)		NOT NULL
,Status		nvarchar(20)		NOT NULL
,Notes		nvarchar(500)		NOT NULL
,UserID		uniqueidentifier	NOT NULL CONSTRAINT FK_GlobalUser_UserID FOREIGN KEY REFERENCES GlobalUsers(ID))

GO
--INSERT INTO GlobalUsers VALUES (NEWID(), 'priyesh', 'chitta', 'Priyesh Karle', NEWID(), 1)
SELECT * FROM GlobalUsers