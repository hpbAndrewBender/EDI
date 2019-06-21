CREATE TABLE [importCDFL].[PurchaseAcknowledgement_R91_FileTrailer] (
    [Id]                     INT      IDENTITY (1, 1) NOT NULL,
    [RecordCode]             TINYINT  NOT NULL,
    [SequenceNumber]         SMALLINT NOT NULL,
    [TotalLineItemsinFile]   SMALLINT NOT NULL,
    [TotalPOsAcknowledged]   SMALLINT NOT NULL,
    [TotalUnitsAcknowledged] SMALLINT NOT NULL,
    [RecordCount01To09]      SMALLINT NOT NULL,
    [RecordCount10To19]      SMALLINT NOT NULL,
    [RecordCount20To29]      SMALLINT NOT NULL,
    [RecordCount30To39]      SMALLINT NOT NULL,
    [RecordCount40To49]      SMALLINT NOT NULL,
    [RecordCount50To59]      SMALLINT NOT NULL,
    [RecordCount60To99]      SMALLINT NOT NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R91_FileTrailer] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R91_FileTrailer.RecordSequence]
    ON [importCDFL].[PurchaseAcknowledgement_R91_FileTrailer]([RecordCode] ASC, [SequenceNumber] ASC);

