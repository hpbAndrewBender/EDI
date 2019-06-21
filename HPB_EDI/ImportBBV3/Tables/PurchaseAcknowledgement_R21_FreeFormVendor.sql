CREATE TABLE [ImportBBV3].[PurchaseAcknowledgement_R21_FreeFormVendor] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]        INT          NULL,
    [RecordCode]     VARCHAR (2)  NULL,
    [SequenceNumber] SMALLINT     NULL,
    [PONumber]       VARCHAR (22) NULL,
    [VendorMessage]  VARCHAR (50) NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R21_FreeFormVendor] PRIMARY KEY CLUSTERED ([Id] ASC)
);



