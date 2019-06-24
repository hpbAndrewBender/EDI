CREATE TABLE [importCDFL].[PurchaseOrder_R21_PurchaseOrderOptions] (
    [Id]                         INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                    INT          NULL,
    [RecordCode]                 TINYINT      NOT NULL,
    [SequenceNumber]             INT          NOT NULL,
    [PONumber]                   VARCHAR (22) NOT NULL,
    [IngramShipToAccountNumber]  VARCHAR (7)  NOT NULL,
    [POType]                     CHAR (1)     NOT NULL,
    [OrderType]                  VARCHAR (2)  NOT NULL,
    [DCCode]                     CHAR (1)     NULL,
    [Greenlight]                 CHAR (1)     NOT NULL,
    [POAType]                    CHAR (1)     NOT NULL,
    [ShipToPassword]             VARCHAR (8)  NOT NULL,
    [CarrierOrShippingMethod]    VARCHAR (25) NULL,
    [SplitOrderAcrossDCsAllowed] BIT          NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R21_PurchaseOrderOptions] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R21_PurchaseOrderOptions.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R21_PurchaseOrderOptions]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R21_PurchaseOrderOptions.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R21_PurchaseOrderOptions]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

