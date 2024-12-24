USE [mvc]
GO

/****** Object: Table [dbo].[Course] Script Date: 12/24/2024 10:58:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Course] (
    [CourseId]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (20)  NOT NULL,
    [Description] VARCHAR (100) NOT NULL,
    [Logo]        VARCHAR (50)  NULL
);


