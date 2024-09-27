CREATE TABLE [dbo].[Course]
(
	[ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Subject] NVARCHAR(50) NOT NULL, 
    [CourseNumber] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL,
    CONSTRAINT UQ_Course UNIQUE (Subject, CourseNumber)
)
