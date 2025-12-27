CREATE TABLE [dbo].[book_tbl] (
    [Id]        BIGINT       IDENTITY (1, 1) NOT NULL,
    [Title]     VARCHAR (50) NOT NULL,
    [AuthorId]  INT          NOT NULL,
    [PageCount] SMALLINT     NULL,
    [GenreId]   VARCHAR (50) NOT NULL,
    [CreatedTs] DATETIME     NOT NULL,
    [UpdatedTs] DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[author_tbl] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [NCX_book_tbl_AuthorId]
    ON [dbo].[book_tbl]([AuthorId] ASC);


GO
CREATE NONCLUSTERED INDEX [NCX_book_tbl_Title]
    ON [dbo].[book_tbl]([Title] ASC);


GO
CREATE NONCLUSTERED INDEX [NCX_book_tbl_Genre]
    ON [dbo].[book_tbl]([GenreId] ASC);

