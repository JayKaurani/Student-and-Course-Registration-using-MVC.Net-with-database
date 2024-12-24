CREATE TABLE [dbo].[Course] (
    [CourseId]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (20)  NOT NULL,
    [Description] VARCHAR (100) NOT NULL,
    [Logo]        VARCHAR (50)  NULL,
    CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED ([CourseId] ASC)
);


CREATE TABLE [dbo].[Student] (
    [StudentId] INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NULL,
    [Gender]    VARCHAR (50) NULL,
    [Address]   VARCHAR (50) NULL,
    [CourseId]  INT          NULL,
    PRIMARY KEY CLUSTERED ([StudentId] ASC),
    CONSTRAINT [FK_Student_Student] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course] ([CourseId])
);

