CREATE TABLE [dbo].[Student]
(
	[StudentId] INT NOT NULL PRIMARY KEY Identity, 
    [Name] VARCHAR(50) NOT NULL, 
    [Address] VARCHAR(500) NOT NULL, 
    [Gender] VARCHAR(6) NOT NULL, 
    [CourseId] INT NOT NULL, 
    CONSTRAINT [FK_Student_Course] FOREIGN KEY ([CourseId]) REFERENCES [Course]([CourseId])
)
