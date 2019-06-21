CREATE TABLE [importCDFL].[PurchaseOrder_R45_Imprint] (
    [Id]                    INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]            TINYINT      NOT NULL,
    [SequenceNumber]        SMALLINT     NOT NULL,
    [PONumber]              VARCHAR (22) NOT NULL,
    [ImprintOrIndexCode]    CHAR (1)     NOT NULL,
    [ImprintTextandSymbols] VARCHAR (30) NULL,
    [ImprintFontCode]       CHAR (1)     NULL,
    [ImprintColorCode]      CHAR (1)     NULL,
    [ImprintPositionCode]   CHAR (1)     NULL,
    [ImprintAppendCode]     CHAR (1)     NULL,
    CONSTRAINT [PK_PurchaseOrder_R45_Imprint] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R45_Imprint.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R45_Imprint]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R45_Imprint.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R45_Imprint]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

