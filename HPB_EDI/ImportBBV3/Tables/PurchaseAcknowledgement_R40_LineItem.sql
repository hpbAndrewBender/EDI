CREATE TABLE [ImportBBV3].[PurchaseAcknowledgement_R40_LineItem] (
    [Id]                INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]           INT          NULL,
    [RecordCode]        VARCHAR (2)  NULL,
    [SequenceNumber]    SMALLINT     NULL,
    [PONumber]          VARCHAR (22) NULL,
    [LineItemPONumber]  VARCHAR (22) NULL,
    [ItemNumber]        VARCHAR (20) NULL,
    [POAStatusCode]     VARCHAR (2)  NULL,
    [DCCodeOrPrimaryDC] CHAR (1)     NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R40_LineItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);



