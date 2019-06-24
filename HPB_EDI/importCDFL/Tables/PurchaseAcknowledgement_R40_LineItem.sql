CREATE TABLE [importCDFL].[PurchaseAcknowledgement_R40_LineItem] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]          INT          NULL,
    [RecordCode]       TINYINT      NOT NULL,
    [SequenceNumber]   SMALLINT     NOT NULL,
    [PONumber]         VARCHAR (22) NOT NULL,
    [LineItemPONumber] VARCHAR (10) NULL,
    [ItemNumber]       VARCHAR (20) NOT NULL,
    [POAStatusCode]    VARCHAR (2)  NOT NULL,
    [DCCode]           CHAR (1)     NOT NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R40_LineItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R40_LineItem.RecordSequence]
    ON [importCDFL].[PurchaseAcknowledgement_R40_LineItem]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R40_LineItem.RecordSequencePO]
    ON [importCDFL].[PurchaseAcknowledgement_R40_LineItem]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

