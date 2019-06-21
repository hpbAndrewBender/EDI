CREATE TABLE [ImportBBV3].[PurchaseOrder_R90_FileTrailer] (
    [Id]                        INT         IDENTITY (1, 1) NOT NULL,
    [RecordCode]                VARCHAR (2) NULL,
    [SequenceNumber]            SMALLINT    NULL,
    [TotalLineItemsinfile]      SMALLINT    NULL,
    [TotalPurchaseOrderRecords] SMALLINT    NULL,
    [TotalUnitsOrdered]         SMALLINT    NULL,
    [RecordCount00_09]          SMALLINT    NULL,
    [RecordCount10_19]          SMALLINT    NULL,
    [RecordCount20_29]          SMALLINT    NULL,
    [RecordCount30_39]          SMALLINT    NULL,
    [RecordCount40_49]          SMALLINT    NULL,
    [RecordCount50_59]          SMALLINT    NULL,
    [RecordCount60_69]          SMALLINT    NULL,
    [RecordCount70_79]          SMALLINT    NULL,
    [RecordCount80_99]          SMALLINT    NULL,
    CONSTRAINT [PK_PurchaeOrder_R90_FileTrailer] PRIMARY KEY CLUSTERED ([Id] ASC)
);

