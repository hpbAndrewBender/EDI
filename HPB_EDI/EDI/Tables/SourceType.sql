CREATE TABLE [EDI].[SourceType] (
    [SourceTypeID] TINYINT       IDENTITY (1, 1) NOT NULL,
    [SourceType]   VARCHAR (250) NULL,
    CONSTRAINT [PK_SourceType] PRIMARY KEY CLUSTERED ([SourceTypeID] ASC)
);



