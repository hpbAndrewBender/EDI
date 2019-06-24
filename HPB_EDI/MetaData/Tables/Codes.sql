CREATE TABLE [MetaData].[Codes] (
    [Id]              SMALLINT       IDENTITY (1, 1) NOT NULL,
    [CodeTypeId]      SMALLINT       NOT NULL,
    [Code]            VARCHAR (100)  NULL,
    [CodeName]        VARCHAR (100)  NULL,
    [CodeDescription] VARCHAR (1000) NULL,
    CONSTRAINT [PK_Codes] PRIMARY KEY CLUSTERED ([Id] ASC)
);



