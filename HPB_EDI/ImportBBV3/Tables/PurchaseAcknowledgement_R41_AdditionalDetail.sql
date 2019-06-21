CREATE TABLE [ImportBBV3].[PurchaseAcknowledgement_R41_AdditionalDetail] (
    [Id]                     INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                INT          NULL,
    [RecordCode]             VARCHAR (2)  NULL,
    [SequenceNumber]         SMALLINT     NULL,
    [PONumber]               VARCHAR (22) NULL,
    [DCCodeOrSecondaryDC]    CHAR (1)     NULL,
    [AvailabilityDate]       VARCHAR (10) NULL,
    [DCInventoryInformation] VARCHAR (40) NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R41_AdditionalDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);



