CREATE TABLE [ImportBBV3].[ShipNotice_OD_ASNShipmentDetail] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [BatchId]                 INT            NULL,
    [DetailRecordIdentifier]  VARCHAR (2)    NULL,
    [LineItemIdNumber]        VARCHAR (22)   NULL,
    [ISBN13OrEAN]             VARCHAR (13)   NULL,
    [QuantityPredictedtoShip] SMALLINT       NULL,
    [QuantityShipped]         SMALLINT       NULL,
    [IngramItemListPrice]     NUMERIC (7, 2) NULL,
    [NetOrDiscountedPrice]    NUMERIC (7, 2) NULL,
    CONSTRAINT [PK_ShipNotice_OD_ASNShipmentDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);



