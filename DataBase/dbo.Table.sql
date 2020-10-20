CREATE TABLE [dbo].[Customers] (
    [CId]   INT IDENTITY (19101, 1) NOT NULL,
    [Name]  NVARCHAR (30) NULL,
    [DoB]   TIME            NOT NULL,
    [Email] NVARCHAR (50) NULL,
    [Phone] NVARCHAR(30) NULL, 
    CONSTRAINT [PK_dbo.Students] PRIMARY KEY CLUSTERED ([CId] ASC)
);
