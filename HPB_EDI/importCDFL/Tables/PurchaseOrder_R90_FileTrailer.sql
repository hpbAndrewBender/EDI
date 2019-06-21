CREATE TABLE [importCDFL].[PurchaseOrder_R90_FileTrailer] (
    [Id]                        INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]                TINYINT      NOT NULL,
    [SequenceNumber]            SMALLINT     NOT NULL,
    [TotalLineItemsinfile]      VARCHAR (22) NOT NULL,
    [TotalPurchaseOrderRecords] SMALLINT     NOT NULL,
    [TotalUnitsOrdered]         SMALLINT     NOT NULL,
    [RecordCount00To09]         SMALLINT     NOT NULL,
    [RecordCount10To19]         SMALLINT     NOT NULL,
    [RecordCount20To29]         SMALLINT     NOT NULL,
    [RecordCount30To39]         SMALLINT     NOT NULL,
    [RecordCount40To49]         SMALLINT     NOT NULL,
    [RecordCount50To59]         SMALLINT     NOT NULL,
    [RecordCount60To69]         SMALLINT     NOT NULL,
    [RecordCount70To79]         SMALLINT     NOT NULL,
    [RecordCount80To99]         SMALLINT     NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R90_FileTrailer] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R90_FileTrailer.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R90_FileTrailer]([RecordCode] ASC, [SequenceNumber] ASC);

