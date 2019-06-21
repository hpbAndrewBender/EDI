CREATE TABLE [Logging].[SQLMessages] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [DateTimeStamp] DATETIME       CONSTRAINT [DF_SQLMessages_DateTimeStamp] DEFAULT (getutcdate()) NULL,
    [ErrorMessage]  VARCHAR (2500) NULL,
    [ProcedureName] VARCHAR (200)  NULL,
    CONSTRAINT [PK_SQLMessages] PRIMARY KEY CLUSTERED ([Id] ASC)
);

