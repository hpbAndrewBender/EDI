CREATE TABLE [ImportBBV3].[PurchaseAcknowledgement_R59_PurchaseOrderControlTotals] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]        INT          NULL,
    [RecordCode]     VARCHAR (2)  NULL,
    [SequenceNumber] SMALLINT     NULL,
    [PONumber]       VARCHAR (22) NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R59_PurchaseOrderControlTotals] PRIMARY KEY CLUSTERED ([Id] ASC)
);



