CREATE TABLE [importCDFL].[PurchaseAcknowledgement_R11_PurchaseOrderHeader] (
    [Id]                     INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                INT          NULL,
    [RecordCode]             TINYINT      NOT NULL,
    [SequenceNumber]         SMALLINT     NOT NULL,
    [TOC]                    VARCHAR (13) NOT NULL,
    [PONumber]               VARCHAR (22) NOT NULL,
    [ICGShipToAccountNumber] VARCHAR (7)  NOT NULL,
    [ICGSAN]                 VARCHAR (7)  NOT NULL,
    [POStatus]               CHAR (1)     NOT NULL,
    [AcknowledgmentDate]     DATE         NOT NULL,
    [PODate]                 DATE         NOT NULL,
    [POCancellationDate]     DATE         NOT NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R11_PurchaseOrderHeader] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R11_PurchaseOrderHeader.RecordSequence]
    ON [importCDFL].[PurchaseAcknowledgement_R11_PurchaseOrderHeader]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R11_PurchaseOrderHeader.RecordSequencePO]
    ON [importCDFL].[PurchaseAcknowledgement_R11_PurchaseOrderHeader]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

