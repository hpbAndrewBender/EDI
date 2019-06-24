CREATE TABLE [importCDFL].[PurchaseAcknowledgement_R21_FreeFormVendor] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]        INT          NULL,
    [RecordCode]     TINYINT      NOT NULL,
    [SequenceNumber] SMALLINT     NOT NULL,
    [PONumber]       VARCHAR (22) NOT NULL,
    [VendorMessage]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R21_FreeFormVendor] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R21_FreeFormVendor.RecordSequence]
    ON [importCDFL].[PurchaseAcknowledgement_R21_FreeFormVendor]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R21_FreeFormVendor.RecordSequencePO]
    ON [importCDFL].[PurchaseAcknowledgement_R21_FreeFormVendor]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

