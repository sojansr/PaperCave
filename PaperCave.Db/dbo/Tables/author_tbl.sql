CREATE TABLE [dbo].[author_tbl] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50) NOT NULL,
    [LastName]  VARCHAR (50) NOT NULL,
    [Language]  VARCHAR (50) NULL,
    [CreatedTs] DATETIME     NOT NULL,
    [UpdatedTs] DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

