USE [mvc]
GO

/****** Object: Table [dbo].[Student] Script Date: 12/24/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student] (
    [StudentId] INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NULL,
    [Gender]    VARCHAR (50) NULL,
    [Address]   VARCHAR (50) NULL,
    [CourseId]  INT          NULL
);


