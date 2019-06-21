CREATE TABLE [ImportBBV3].[PurchaseOrder_R50_PurchaseOrderTrailer] (
    [Id]                        INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]                VARCHAR (2)  NULL,
    [SequenceNumber]            SMALLINT     NULL,
    [PONumber]                  VARCHAR (22) NULL,
    [TotalPurchaseOrderRecords] SMALLINT     NULL,
    [TotalLineItemsinfile]      SMALLINT     NULL,
    [TotalUnitsOrdered]         SMALLINT     NULL,
    CONSTRAINT [PK_PurchaesOrder_R50PurchaseOrderTrailer] PRIMARY KEY CLUSTERED ([Id] ASC)
);

