CREATE TABLE [ImportBBV3].[PurchaseOrder_R21_PurchaseOrderOptions] (
    [Id]                               INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]                       VARCHAR (2)  NOT NULL,
    [SequenceNumber]                   SMALLINT     NOT NULL,
    [PONumber]                         VARCHAR (22) NOT NULL,
    [IngramShipToAccountNumber]        VARCHAR (7)  NOT NULL,
    [POType]                           CHAR (1)     NOT NULL,
    [OrderTypeCode]                    VARCHAR (2)  NOT NULL,
    [DCCode]                           CHAR (1)     NULL,
    [BackorderHoldAndReleaseIndicator] CHAR (1)     NOT NULL,
    [ExtendedPOAStatusCodes]           CHAR (1)     NOT NULL,
    [DCPairs]                          CHAR (1)     NOT NULL,
    [POATypeCode]                      CHAR (1)     NOT NULL,
    [IngramShipToAccountPassword]      VARCHAR (8)  NOT NULL,
    [CarrierOrShippingMethod]          VARCHAR (25) NOT NULL,
    [SplitLineIndicatorOrderLevel]     CHAR (1)     NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R21_PurchaseOrderOptions] PRIMARY KEY CLUSTERED ([Id] ASC)
);

