CREATE TABLE [ImportBBV3].[Batch] (
    [Id]                     INT           IDENTITY (1, 1) NOT NULL,
    [BatchItemId]            TINYINT       NULL,
    [VendorID]               VARCHAR (20)  NULL,
    [DateCreatedUTC]         DATETIME      CONSTRAINT [DF_Batch_DateCreated] DEFAULT (getutcdate()) NOT NULL,
    [DateCreatedServerLocal] AS            (dateadd(minute,datediff(minute,getutcdate(),getdate()),[DateCreatedUTC])),
    [DateProcessedUTC]       DATETIME      NULL,
    [Filename]               VARCHAR (255) NULL,
    CONSTRAINT [PK_Batch] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Batch~BatchItem] FOREIGN KEY ([BatchItemId]) REFERENCES [ImportBBV3].[BatchItem] ([Id])
);



