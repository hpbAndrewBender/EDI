CREATE TABLE [importCDFL].[PurchaseOrder_R10_ClientHeader] (
    [Id]                                INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                           INT          NULL,
    [RecordCode]                        TINYINT      NOT NULL,
    [SequenceNumber]                    INT          NOT NULL,
    [PONumber]                          VARCHAR (22) NOT NULL,
    [IngramBillToAccountNumber]         VARCHAR (7)  NOT NULL,
    [VendorSAN]                         VARCHAR (7)  NOT NULL,
    [OrderDate]                         DATE         NOT NULL,
    [BackorderCancelDate]               DATE         NOT NULL,
    [BackorderCode]                     CHAR (1)     NOT NULL,
    [DDCFulfillmentOrSplitLineOrdering] CHAR (1)     NOT NULL,
    [ShipToIndicator]                   BIT          NOT NULL,
    [BillToIndicator]                   BIT          NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R10_ClientHeader] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R10_ClientHeader.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R10_ClientHeader]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R10_ClientHEader.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R10_ClientHeader]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

