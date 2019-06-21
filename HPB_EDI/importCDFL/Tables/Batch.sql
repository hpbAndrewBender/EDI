CREATE TABLE [importCDFL].[Batch] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [BatchItemId]      TINYINT       NULL,
    [VendorID]         VARCHAR (10)  NULL,
    [DateCreatedUTC]   DATETIME      CONSTRAINT [DF_BAtch_DateCreated] DEFAULT (getutcdate()) NOT NULL,
    [DateProcessedUTC] DATETIME      NULL,
    [Filename]         VARCHAR (255) NULL,
    CONSTRAINT [PK_Batch] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Batch~BatchItem] FOREIGN KEY ([BatchItemId]) REFERENCES [importCDFL].[BatchItem] ([Id])
);



