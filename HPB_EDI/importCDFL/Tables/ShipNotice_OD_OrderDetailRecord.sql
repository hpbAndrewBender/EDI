CREATE TABLE [importCDFL].[ShipNotice_OD_OrderDetailRecord] (
    [Id]                                          INT            IDENTITY (1, 1) NOT NULL,
    [OrderRecordIdentifier]                       VARCHAR (2)    NOT NULL,
    [ClientOrderID]                               VARCHAR (22)   NOT NULL,
    [ShippingWarehouseCode]                       VARCHAR (2)    NOT NULL,
    [IngramOrderEntryNumber]                      VARCHAR (10)   NOT NULL,
    [QuantityCancelled]                           SMALLINT       NOT NULL,
    [ISBN10Ordered]                               VARCHAR (10)   NOT NULL,
    [ISBN10Shipped]                               VARCHAR (10)   NOT NULL,
    [QuantityPredicted]                           SMALLINT       NOT NULL,
    [QuantitySlashed]                             SMALLINT       NOT NULL,
    [QuantityShipped]                             SMALLINT       NOT NULL,
    [ItemDetailStatusCode]                        VARCHAR (2)    NOT NULL,
    [TrackingNumber]                              VARCHAR (25)   NOT NULL,
    [SCAC]                                        VARCHAR (5)    NOT NULL,
    [IngramItemListPrice]                         NUMERIC (7, 2) NOT NULL,
    [NetOrDiscountedPrice]                        NUMERIC (7, 2) NOT NULL,
    [LineItemIDNumber]                            VARCHAR (10)   NOT NULL,
    [SSL]                                         VARCHAR (20)   NOT NULL,
    [Weight]                                      DECIMAL (9, 2) NOT NULL,
    [ShippingMethodCodeorSlashOrCancelReasonCode] VARCHAR (2)    NOT NULL,
    [ISBN13OrEAN]                                 VARCHAR (15)   NOT NULL,
    CONSTRAINT [PK_ShipNotice_OD_OrderDetailRecord ] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_ShipNotice_OD_OrderDetailRecord.OrderRecIDClientOrd]
    ON [importCDFL].[ShipNotice_OD_OrderDetailRecord]([OrderRecordIdentifier] ASC, [ClientOrderID] ASC);

