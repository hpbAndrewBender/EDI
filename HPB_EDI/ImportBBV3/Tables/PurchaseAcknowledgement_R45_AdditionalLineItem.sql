CREATE TABLE [ImportBBV3].[PurchaseAcknowledgement_R45_AdditionalLineItem] (
    [Id]                          INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                     INT          NULL,
    [RecordCode]                  VARCHAR (2)  NULL,
    [SequenceNumber]              SMALLINT     NULL,
    [PONumber]                    VARCHAR (22) NULL,
    [ClientPropiertaryItemNumber] VARCHAR (20) NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R45_AdditionalLineItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);



