CREATE TABLE [ImportBBV3].[PurchaseOrder_R20_FixedSpecialHandlingInstructions] (
    [Id]                    INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]            VARCHAR (2)  NOT NULL,
    [SequenceNumber]        SMALLINT     NOT NULL,
    [PONumber]              VARCHAR (22) NOT NULL,
    [SpecialHandlingPrefix] CHAR (1)     NOT NULL,
    [SpecialHandlingCodes]  VARCHAR (4)  NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R20_FixedSpecialHandlingInstructions] PRIMARY KEY CLUSTERED ([Id] ASC)
);

