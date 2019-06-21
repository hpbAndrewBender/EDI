CREATE TABLE [ImportBBV3].[PurchaseOrder_R10_ClientHeader] (
    [Id]                                            INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]                                    VARCHAR (2)  NOT NULL,
    [SequenceNumber]                                SMALLINT     NOT NULL,
    [PONumber]                                      VARCHAR (22) NOT NULL,
    [IngramBillToAccountNumber]                     VARCHAR (7)  NOT NULL,
    [VendorSAN]                                     VARCHAR (7)  NOT NULL,
    [OrderDate]                                     DATE         NOT NULL,
    [BackorderCancellationDate]                     DATE         NULL,
    [BackorderCode]                                 VARCHAR (2)  NOT NULL,
    [DDCFulfillmentorSplitLineOrderingOrderlevel]   CHAR (1)     NOT NULL,
    [RecipientOrShiptoAddressIndicator]             CHAR (1)     NOT NULL,
    [PurchasingConsumerOrOrderedByAddressIndicator] CHAR (1)     NOT NULL,
    [DoNotShipbeforedate]                           DATE         NULL,
    CONSTRAINT [PK_PurchaseOrder_R10_ClientHeader] PRIMARY KEY CLUSTERED ([Id] ASC)
);

