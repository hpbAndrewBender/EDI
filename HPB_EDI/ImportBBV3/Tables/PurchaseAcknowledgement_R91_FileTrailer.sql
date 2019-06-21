CREATE TABLE [ImportBBV3].[PurchaseAcknowledgement_R91_FileTrailer] (
    [Id]             INT         IDENTITY (1, 1) NOT NULL,
    [BatchId]        INT         NULL,
    [RecordCode]     VARCHAR (2) NULL,
    [SequenceNumber] SMALLINT    NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R91_FileTrailer] PRIMARY KEY CLUSTERED ([Id] ASC)
);



