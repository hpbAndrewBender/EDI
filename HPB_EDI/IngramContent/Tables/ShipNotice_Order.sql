CREATE TABLE [IngramContent].[ShipNotice_Order] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [CompanyID]            INT            NULL,
    [OrderStatusCode]      SMALLINT       NULL,
    [OrderSubtotal]        NUMERIC (7, 2) NULL,
    [OrderDiscountAmount]  NUMERIC (7, 2) NULL,
    [SalesTax]             NUMERIC (7, 2) NULL,
    [ShippingHandling]     NUMERIC (7, 2) NULL,
    [OrderTotal]           NUMERIC (8, 2) NULL,
    [FreightCharge]        DECIMAL (8, 2) NULL,
    [TotalItemDetailCount] SMALLINT       NULL,
    [ShipmentDate]         DATE           NULL,
    [ConsumerPONumber]     VARCHAR (22)   NULL,
    CONSTRAINT [PK_ShipNotice_Header] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MetaData.Codes~IngramContent.ShipNotice-OrderStatusCode] FOREIGN KEY ([OrderStatusCode]) REFERENCES [MetaData].[Codes] ([Id]),
    CONSTRAINT [FK_ShipNotice_Company~ShipNotice_Header] FOREIGN KEY ([CompanyID]) REFERENCES [IngramContent].[ShipNotice_Company] ([Id])
);

