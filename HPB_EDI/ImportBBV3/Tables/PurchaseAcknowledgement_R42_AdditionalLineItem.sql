CREATE TABLE [ImportBBV3].[PurchaseAcknowledgement_R42_AdditionalLineItem] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]        INT          NULL,
    [RecordCode]     VARCHAR (2)  NULL,
    [SequenceNumber] SMALLINT     NULL,
    [PONumber]       VARCHAR (22) NULL,
    [Title]          VARCHAR (30) NULL,
    [Author]         VARCHAR (20) NULL,
    [BindingCode]    CHAR (1)     NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R42_AdditionalLineItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);



