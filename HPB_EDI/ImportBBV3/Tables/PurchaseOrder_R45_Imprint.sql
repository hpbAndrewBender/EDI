CREATE TABLE [ImportBBV3].[PurchaseOrder_R45_Imprint] (
    [Id]                    INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]            VARCHAR (2)  NOT NULL,
    [SequenceNumber]        SMALLINT     NOT NULL,
    [PONumber]              VARCHAR (22) NOT NULL,
    [ImprintCode]           CHAR (1)     NOT NULL,
    [ImprintTextandSymbols] VARCHAR (30) NOT NULL,
    [ImprintFontCode]       CHAR (1)     NULL,
    [ImprintColorCode]      CHAR (1)     NULL,
    [ImprintPositionCode]   CHAR (1)     NULL,
    [ImprintAppendCode]     CHAR (1)     NULL,
    CONSTRAINT [PK_PurchaseOrder_R45_Imprint] PRIMARY KEY CLUSTERED ([Id] ASC)
);

