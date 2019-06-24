CREATE TABLE [EDI].[SourceLocation] (
    [Id]        TINYINT       IDENTITY (1, 1) NOT NULL,
    [SourceApp] VARCHAR (250) NULL,
    CONSTRAINT [PK_SourceLocation] PRIMARY KEY CLUSTERED ([Id] ASC)
);

